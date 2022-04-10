using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MessageBox.Avalonia.DTO;
using PropertyChanged;
using MessageBox.Avalonia.Enums;
using QuectelController.Communication;
using System.Threading.Tasks;
using QuectelController.Communication.Commands.Network;
using System;
using ScottPlot.Avalonia;
using System.Collections.Generic;
using System.Drawing;
using ScottPlot.Plottable;
using System.Text;
using System.IO;
using System.Linq;
using System.Drawing.Imaging;
using CsvHelper;
using ScottPlot.Renderable;

namespace QuectelController.Views
{
    [DoNotNotify]
    public partial class MeasurementWindow : Window
    {
        public SerialCommunication serial;
        public bool ConnectionTimeout = false;

        private static int MEASURE_FREQUENCY = 5;

        private AvaPlot RSRQplot;
        private AvaPlot RSRPplot;
        private StringBuilder StringBufferBuilder { get; set; } = new StringBuilder();
        private IDisposable SerialCharactersSubscriptions { get; set; }

        private List<double> Time = new List<double>();

        private List<double> RSRP_5G = new List<double>();
        private List<double> RSRQ_5G = new List<double>();
        private List<double> SINR_5G = new List<double>();

        private List<double> RSRP_LTE = new List<double>();
        private List<double> RSRQ_LTE = new List<double>();
        private List<double> SINR_LTE = new List<double>();

        private ScatterPlot RSRQPlot;
        private ScatterPlot RSRPPlot;
        private ScatterPlot SINRPlot;

        private ScatterPlot SecondRSRQPlot;
        private ScatterPlot SecondRSRPPlot;
        private ScatterPlot SecondSINRPlot;

        private Button StartBtn;
        private Button CloseBtn;

        private RadioButton SAMode;
        private RadioButton ENDCMode;
        private RadioButton LTEMode;

        private int counter = 0;

        public MeasurementWindow()
        {
            InitializeComponent();

            Closing += MeasurementWindow_Closing;
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void MeasurementWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PeriodicTask.Stop();
            SerialCharactersSubscriptions?.Dispose();
            SerialCharactersSubscriptions = null;
        }


        public MeasurementWindow(SerialCommunication serial) : this()
        {
            this.serial = serial;

            SetGraphs();

            RSRQPlot = RenderGraph("5G Reference Signal Received Quality (RSRQ)", Color.Green, Time, RSRQ_5G, 0);
            RSRPPlot = RenderGraph("5G Reference Signal Received Power (RSRP)", Color.Red, Time, RSRP_5G, 0);
            SINRPlot = RenderGraph("5G Signal-to-Interface plus Noise Ratio (SINR)", Color.Blue, Time, SINR_5G, 0);
            SecondRSRQPlot = RenderGraph("LTE Reference Signal Received Quality (RSRQ)", Color.OrangeRed, Time, RSRQ_LTE, 0);
            SecondRSRPPlot = RenderGraph("LTE Reference Signal Received Power (RSRP)", Color.DarkCyan, Time, RSRP_LTE, 0);
            SecondSINRPlot = RenderGraph("LTE Signal-to-Interface plus Noise Ratio (SINR", Color.DarkBlue, Time, SINR_LTE, 0);

            SAMode = this.Find<RadioButton>("SAMode");
            ENDCMode = this.Find<RadioButton>("ENDCMode");
            LTEMode = this.Find<RadioButton>("LTEMode");
            CloseBtn = this.Find<Button>("CloseBtn");
            StartBtn = this.Find<Button>("StartBtn");

            SerialCharactersSubscriptions = serial.ReceivedCharactersObservable
    .Subscribe(Receive);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void SetGraphs()
        {
            RSRQplot = this.Find<AvaPlot>("AvaPlot1");
            RSRQplot.Plot.Legend(true, ScottPlot.Alignment.LowerRight);
            RSRQplot.Plot.Title("RSRQ, SINR");
            RSRQplot.Plot.XLabel("Time [sec]");
            RSRQplot.Plot.YLabel("Value [dB]");

            RSRPplot = this.Find<AvaPlot>("AvaPlot2");
            RSRPplot.Plot.Legend(true, ScottPlot.Alignment.LowerRight);
            RSRPplot.Plot.Title("RSRP");
            RSRPplot.Plot.XLabel("Time [sec]");
            RSRPplot.Plot.YLabel("Value [dBm]");
        }

        public void ResetPlots()
        {
            RSRQplot.Reset();
            RSRPplot.Reset();

            SetGraphs();
        }

        private void ClearLists()
        {
            RSRP_5G.Clear();
            RSRQ_5G.Clear();
            SINR_5G.Clear();

            RSRP_LTE.Clear();
            RSRQ_LTE.Clear();
            SINR_LTE.Clear();
        }

        private ScatterPlot RenderGraph(string label, Color color, List<double> x, List<double> y, int index)
        {
            ScatterPlot plot = new ScatterPlot(x.ToArray(), y.ToArray())
            {
                Label = label,
                LineColor = color,
                LineWidth = 1,
                MarkerShape = ScottPlot.MarkerShape.filledCircle,
                MarkerColor = color,
                MarkerSize = 5,
                YAxisIndex = index,
                XAxisIndex = 0,
            };
            return plot;
        }

        private async void Start(object sender, RoutedEventArgs e)
        {
            if (!serial.IsOpen())
            {
                MessageBoxes.ShowError(this,"Connection error", "Connection is not established");
                return;
            }

            ActivateRadioButton(false);
            try
            {
                AllowStart(false);
                await PeriodicTask.Run(Measure, TimeSpan.FromSeconds(MEASURE_FREQUENCY));
            }
            catch (TimeoutException ex)
            {
                PeriodicTask.Stop();
                ConnectionTimeout = true;
                CloseBtn.IsEnabled = false;
                StartBtn.IsEnabled = false;
                MessageBoxes.ShowError(this, "Connection timeout", "Connection to the serial port timed out.");
            }

        }

        private void AllowStart(bool action)
        {
            CloseBtn.IsEnabled = !action;
            StartBtn.IsEnabled = action;
        }

        private void ActivateRadioButton(bool action)
        {
            SAMode.IsEnabled = action;
            ENDCMode.IsEnabled = action;
            LTEMode.IsEnabled = action;
        }

        private void Measure()
        {
            QueryPrimaryServingCell command = new QueryPrimaryServingCell();
            var temp = command.CreateWriteCommand(Array.Empty<ICommandParameter>());
            serial.Write(temp);
        }

        private void Receive(string output)
        {
            try
            {
                StringBufferBuilder.Append(output);
                if (StringBufferBuilder.ToString().Trim().EndsWith("OK"))
                {
                    Parse(StringBufferBuilder.ToString());
                    Refresh();
                    StringBufferBuilder.Clear();
                    counter += MEASURE_FREQUENCY;
                }
            }
            catch (Exception ex)
            {
                StringBufferBuilder.Clear();
            }

        }

        private double ParseValue(string value, int from, int to)
        {
            try
            {
                double temp = double.Parse(value);
                if (from <= temp && temp <= to)
                {
                    return temp;
                }
                else
                {
                    return int.MaxValue;
                }
            }
            catch (FormatException ex)
            {
                return int.MaxValue;
            }
        }

        private void Parse(string toParse)
        {
            var separated = toParse.Split(',', StringSplitOptions.TrimEntries);
            if (SAMode.IsChecked == true)
            {
                RSRP_5G.Add(ParseValue(separated[12], -140, -44));
                RSRQ_5G.Add(ParseValue(separated[13], -20, -3));
                SINR_5G.Add(ParseValue(separated[14], -20, 30));

                RSRP_LTE.Add(int.MaxValue);
                SINR_LTE.Add(int.MaxValue);
                RSRQ_LTE.Add(int.MaxValue);
            }

            if (ENDCMode.IsChecked == true)
            {
                RSRP_5G.Add(ParseValue(separated[22], -140, -44));
                RSRQ_5G.Add(ParseValue(separated[23], -20, -3));
                SINR_5G.Add(ParseValue(separated[24], -20, 30));

                RSRP_LTE.Add(ParseValue(separated[12], -140, -44));
                RSRQ_LTE.Add(ParseValue(separated[13], -20, -3));
                SINR_LTE.Add(ParseValue(separated[15], -20, 30));
            }

            if (LTEMode.IsChecked == true)
            {
                RSRP_5G.Add(int.MaxValue);
                RSRQ_5G.Add(int.MaxValue);
                SINR_5G.Add(int.MaxValue);

                RSRP_LTE.Add(ParseValue(separated[12], -140, -44));
                RSRQ_LTE.Add(ParseValue(separated[13], -20, -3));
                SINR_LTE.Add(ParseValue(separated[15], -20, 30));
            }

            Time.Add(counter);
        }

        private void Refresh()
        {
            RSRQplot.Plot.Clear();
            RSRPplot.Plot.Clear();

            if (SAMode.IsChecked == true)
            {
                RSRQPlot.Update(Time.ToArray(), RSRQ_5G.ToArray());
                RSRPPlot.Update(Time.ToArray(), RSRP_5G.ToArray());
                SINRPlot.Update(Time.ToArray(), SINR_5G.ToArray());

                RSRQplot.Plot.Add(RSRQPlot);
                RSRPplot.Plot.Add(RSRPPlot);
                RSRQplot.Plot.Add(SINRPlot);
            }
            else if (ENDCMode.IsChecked == true)
            {
                RSRQPlot.Update(Time.ToArray(), RSRQ_5G.ToArray());
                RSRPPlot.Update(Time.ToArray(), RSRP_5G.ToArray());
                SINRPlot.Update(Time.ToArray(), SINR_5G.ToArray());

                SecondRSRQPlot.Update(Time.ToArray(), RSRQ_LTE.ToArray());
                SecondRSRPPlot.Update(Time.ToArray(), RSRP_LTE.ToArray());
                SecondSINRPlot.Update(Time.ToArray(), SINR_LTE.ToArray());

                RSRQplot.Plot.Add(RSRQPlot);
                RSRPplot.Plot.Add(RSRPPlot);
                RSRQplot.Plot.Add(SINRPlot);

                RSRQplot.Plot.Add(SecondRSRQPlot);
                RSRPplot.Plot.Add(SecondRSRPPlot);
                RSRQplot.Plot.Add(SecondSINRPlot);
            }
            else if (LTEMode.IsChecked == true)
            {
                SecondRSRQPlot.Update(Time.ToArray(), RSRQ_LTE.ToArray());
                SecondRSRPPlot.Update(Time.ToArray(), RSRP_LTE.ToArray());
                SecondSINRPlot.Update(Time.ToArray(), SINR_LTE.ToArray());

                RSRQplot.Plot.Add(SecondRSRQPlot);
                RSRPplot.Plot.Add(SecondRSRPPlot);
                RSRQplot.Plot.Add(SecondSINRPlot);
            }

            RSRQplot.Plot.AxisAuto();
            RSRPplot.Plot.AxisAuto();
            RSRQplot.Refresh();
            RSRPplot.Refresh();
        }

        private void Stop(object sender, RoutedEventArgs e)
        {
            PeriodicTask.Stop();
            AllowStart(true);
        }

        private void Reload(object sender, RoutedEventArgs e)
        {
            ResetPlots();
            ClearLists();
            ActivateRadioButton(true);
            AllowStart(true);
            PeriodicTask.Stop();
        }

        private async void Export(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileBox = new SaveFileDialog
            {
                Title = "Save Log As...",
                DefaultExtension = "csv",
                Filters = new List<FileDialogFilter>()
                {
                    new FileDialogFilter()
                    {
                        Name = "CSV file",
                        Extensions = new List<string>
                        {
                            "csv",
                        },
                    },
                },
            };
            var path = await saveFileBox.ShowAsync(this);

            if (path == null)
            {
                return;
            }

            using var writer = new StreamWriter(path);
            using var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture);
            if (SAMode.IsChecked == true)
            {
               var records = Enumerable.Range(0, Time.Count).Select(x => new MeasurementRow5G(Time[x], RSRP_5G[x], RSRQ_5G[x], SINR_5G[x]));
               csvWriter.WriteRecords(records);
            }

            if (ENDCMode.IsChecked == true)
            {
                var records = Enumerable.Range(0, Time.Count).Select(x => new MeasurementRowENDC(Time[x], RSRP_5G[x], RSRQ_5G[x], SINR_5G[x], RSRP_LTE[x], RSRQ_LTE[x], SINR_LTE[x]));
                csvWriter.WriteRecords(records);
            }

            if (LTEMode.IsChecked == true)
            {
                var records = Enumerable.Range(0, Time.Count).Select(x => new MeasurementRowLTE(Time[x], RSRP_LTE[x], RSRQ_LTE[x], SINR_LTE[x]));
                csvWriter.WriteRecords(records);
            }
        }

        private async void Import(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileBox = new OpenFileDialog
            {
                Title = "Open csv file...",
                AllowMultiple = false,
                Filters = new List<FileDialogFilter>()
                {
                    new FileDialogFilter()
                    {
                        Name = "CSV file",
                        Extensions = new List<string>
                        {
                            "csv",
                        },
                    },
                },
            };
            var path = await openFileBox.ShowAsync(this);

            if (path == null)
            {
                return;
            }

            using var reader = new StreamReader(path.FirstOrDefault());
            using var csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
            try
            {
                if (SAMode.IsChecked == true)
                {
                    var records = csvReader.GetRecords<MeasurementRow5G>().ToArray();
                    if (records?.Any() == false)
                    {
                        MessageBoxes.ShowError(this, "Import error", "Imported list is empty");
                        return;
                    }

                    RSRP_5G = records.Select(x => x.RSRP_5G).ToList();
                    RSRQ_5G = records.Select(x => x.RSRQ_5G).ToList();
                    SINR_5G = records.Select(x => x.SINR_5G).ToList();
                    Time = records.Select(x => x.Time).ToList();
                }

                if (ENDCMode.IsChecked == true)
                {
                    var records = csvReader.GetRecords<MeasurementRowENDC>().ToArray();
                    if (records?.Any() == false)
                    {
                        MessageBoxes.ShowError(this, "Import error", "Imported list is empty");
                        return;
                    }

                    RSRP_5G = records.Select(x => x.RSRP_5G).ToList();
                    RSRQ_5G = records.Select(x => x.RSRQ_5G).ToList();
                    SINR_5G = records.Select(x => x.SINR_5G).ToList();

                    RSRP_LTE = records.Select(x => x.RSRP_LTE).ToList();
                    RSRQ_LTE = records.Select(x => x.RSRQ_LTE).ToList();
                    SINR_LTE = records.Select(x => x.SINR_LTE).ToList();
                    Time = records.Select(x => x.Time).ToList();
                }

                if (LTEMode.IsChecked == true)
                {
                    var records = csvReader.GetRecords<MeasurementRowLTE>().ToArray();
                    if (records?.Any() == false)
                    {
                        MessageBoxes.ShowError(this, "Import error", "Imported list is empty");
                        return;
                    }

                    RSRP_LTE = records.Select(x => x.RSRP_LTE).ToList();
                    RSRQ_LTE = records.Select(x => x.RSRQ_LTE).ToList();
                    SINR_LTE = records.Select(x => x.SINR_LTE).ToList();
                    Time = records.Select(x => x.Time).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBoxes.ShowError(this, "Import error", "Error while importing the file, check if the file is in the right csv format");
                return;
            }

            ActivateRadioButton(false);
            Refresh();
        }

        private async void ExportImage(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog()
            {
                Title = "Save Images As PNG",
            };
            var path = await openFolderDialog.ShowAsync(this);

            if (path != null)
            {
                Bitmap img = new Bitmap(RSRQplot.Plot.GetBitmap());
                Bitmap img2 = new Bitmap(RSRPplot.Plot.GetBitmap()); // May not work in some operating systems like Rasbian for RPI etc (Bitmap not fully implemented on these platforms)

                img.Save(path + "RSRQ_SINR.png", ImageFormat.Png);
                img2.Save(path + "RSRP.png", ImageFormat.Png);
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}