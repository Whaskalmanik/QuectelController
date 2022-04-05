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

namespace QuectelController.Views
{
    [DoNotNotify]
    public partial class MeasurementWindow : Window
    {
        public SerialCommunication serial;

        private AvaPlot plot;
        private StringBuilder StringBufferBuilder { get; set; } = new StringBuilder();
        private IDisposable SerialCharactersSubscriptions { get; set; }

        private List<double> RSRPx = new List<double>();
        private List<double> RSRPy = new List<double>();

        private List<double> RSRQx = new List<double>();
        private List<double> RSRQy = new List<double>();

        private List<double> SINRx = new List<double>();
        private List<double> SINRy = new List<double>();

        private ScatterPlot RSRQPlot;
        private ScatterPlot RSRPPlot;
        private ScatterPlot SINRPlot;

        private RadioButton SAMode;
        private RadioButton ENDCMode;
        private RadioButton LTEMode;
        private RadioButton WCDMAMode;

        private int counter = 0;

        public MeasurementWindow()
        {
            InitializeComponent();
            
            this.Closing += MeasurementWindow_Closing;
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

            plot = this.Find<AvaPlot>("AvaPlot1");
            plot.Plot.Legend(true, ScottPlot.Alignment.LowerRight);
            plot.Plot.Title("RSRQ, RSRP, SINR");
            plot.Plot.XLabel("Time [sec]");
            plot.Plot.YLabel("Ratio [DB]");

            RSRQPlot = RenderGraph("RSRQ", Color.Green, RSRQx, RSRQy);
            RSRPPlot = RenderGraph("RSRP", Color.Red, RSRPx, RSRPy);
            SINRPlot = RenderGraph("SINR", Color.Blue, SINRx, SINRy);

            SAMode = this.Find<RadioButton>("SAMode");
            ENDCMode = this.Find<RadioButton>("ENDCMode");
            LTEMode = this.Find<RadioButton>("LTEMode");
            WCDMAMode = this.Find<RadioButton>("WCDMAMode");

            SerialCharactersSubscriptions = serial.ReceivedCharactersObservable
    .Subscribe(ReceiveAndParse);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        private ScatterPlot RenderGraph(string Label, Color color, List<double> x, List<double> y)
        {
            ScatterPlot plot = new ScatterPlot(x.ToArray(), y.ToArray())
            {
                Label = Label,
                LineColor = color,
                LineWidth = 1,
                MarkerShape = ScottPlot.MarkerShape.filledCircle,
                MarkerColor = color,
                MarkerSize = 5
            };
            return plot;
        }

        private async void Start(object sender, RoutedEventArgs e)
        {
            if (!serial.isOpen())
            {
                MessageBoxes.ShowError("Connection error", "Connection is not established");
                return;
            }
            counter = 0;
            ActivateRadioButton(false);
            await PeriodicTask.Run(Measure, TimeSpan.FromSeconds(5));
        }

        private void ActivateRadioButton(bool action)
        {
            SAMode.IsEnabled = action;
            ENDCMode.IsEnabled = action;
            LTEMode.IsEnabled = action;
            WCDMAMode.IsEnabled = action;
        }


        private void Measure()
        {
            QueryPrimaryServingCell command = new QueryPrimaryServingCell();
            var temp = command.CreateWriteCommand(Array.Empty<ICommandParameter>());
            serial.Write(temp);
        }

        private void ReceiveAndParse(string output)
        {
            try
            {
                StringBufferBuilder.Append(output);
                if (StringBufferBuilder.ToString().Trim().EndsWith("OK"))
                {
                    if (SAMode.IsChecked == true)
                    {
                        var separated = StringBufferBuilder.ToString().Split(',');

                        RSRQy.Add(Double.Parse(separated[12]));
                        RSRPy.Add(Double.Parse(separated[13]));
                        SINRy.Add(Double.Parse(separated[14]));

                        RSRQx.Add(counter);
                        RSRPx.Add(counter);
                        SINRx.Add(counter);
                    }
                    StringBufferBuilder.Clear();
                    Refresh();
                }
            }
            catch(Exception ex)
            {
                StringBufferBuilder.Clear();
            }
            counter += 5;
            
        }

        private void Refresh()
        {
            plot.Plot.Clear();

            RSRQPlot.Update(RSRQx.ToArray(), RSRQy.ToArray());
            RSRPPlot.Update(RSRPx.ToArray(), RSRPy.ToArray());
            SINRPlot.Update(SINRx.ToArray(), SINRy.ToArray());

            plot.Plot.Add(RSRQPlot);
            plot.Plot.Add(RSRPPlot);
            plot.Plot.Add(SINRPlot);

            plot.Plot.AxisAuto();
            plot.Refresh();
        }


        private void Stop(object sender, RoutedEventArgs e)
        {
            PeriodicTask.Stop();
            ActivateRadioButton(true);

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
                            "csv"
                        }
                    } 
                }
            };
            var path = await saveFileBox.ShowAsync(this);

            if (path == null)
            {
                return;
            }

            var records = Enumerable.Range(0, RSRPx.Count).Select(x => 
                new MeasurementRow(RSRPx[x], RSRPy[x],RSRQx[x], RSRQy[x], SINRx[x],SINRy[x]));
            using var writer = new StreamWriter(path);
            using var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(records);
        }

        private async void Import(object sender, RoutedEventArgs e)
        {
            OpenFileDialog saveFileBox = new OpenFileDialog
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
                            "csv"
                        }
                    }
                }
            };
            var path = await saveFileBox.ShowAsync(this);

            if (path == null)
            {
                return;
            }
            
            using var reader = new StreamReader(path.FirstOrDefault());
            using var csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture); 
            MeasurementRow[] records;
            try
            {
                records = csvReader.GetRecords<MeasurementRow>().ToArray();
            }
            catch (Exception ex)
            {
                MessageBoxes.ShowError("Import error", "Error while importing the file, check if the file is in the right csv format");
                return;
            }

            if (records?.Any() == false)
            {
                MessageBoxes.ShowError("Import error", "Imported list is empty");
                return;
            }
            RSRPx = records.Select(x => x.RSRPx).ToList();
            RSRPy = records.Select(x => x.RSRPy).ToList();
            RSRQx = records.Select(x => x.RSRQx).ToList();
            RSRQy = records.Select(x => x.RSRQy).ToList();
            SINRx = records.Select(x => x.SINRx).ToList();
            SINRy = records.Select(x => x.SINRy).ToList();

            Refresh();
        }

        private async void ExportImage(object sender, RoutedEventArgs e)
        {
            //todo zamést

            SaveFileDialog SaveFileBox = new SaveFileDialog();
            SaveFileBox.Title = "Save image As...";
            List<FileDialogFilter> Filters = new List<FileDialogFilter>();
            FileDialogFilter filter = new FileDialogFilter();
            List<string> extension = new List<string>();
            extension.Add("png");
            filter.Extensions = extension;
            filter.Name = "PNG file";
            Filters.Add(filter);
            SaveFileBox.Filters = Filters;
            SaveFileBox.DefaultExtension = "png";
            var path = await SaveFileBox.ShowAsync(this);

            if (path != null)
            {
                Bitmap img = new Bitmap(plot.Plot.GetBitmap()); //!May not work in some operating systems like Rasbian for RPI etc (Bitmap not fully implemented on these platforms)
                img.Save(path, ImageFormat.Png);
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
