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

namespace QuectelController.Views
{
    [DoNotNotify]
    public partial class MeasurementWindow : Window
    {
        public SerialCommunication serial;

        private IDisposable SerialCharactersSubscriptions { get; set; }

        private PeriodicTask PeriodicTask = new PeriodicTask();

        private List<double> RSRPx = new List<double>();
        private List<double> RSRPy = new List<double>();

        private List<double> RSRQx = new List<double>();
        private List<double> RSRQy = new List<double>();

        private List<double> SINRx = new List<double>();
        private List<double> SINRy = new List<double>();
        int counter = 0;


        private AvaPlot plot;
        public MeasurementWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public MeasurementWindow(SerialCommunication serial) : this()
        {
            this.serial = serial;
            plot = this.Find<AvaPlot>("AvaPlot1");
            SerialCharactersSubscriptions = serial.ReceivedCharactersObservable
    .Subscribe(ReceiveAndParse);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }




        private async void Start(object sender, RoutedEventArgs e)
        {
            if(!serial.isOpen())
            {
                var mb = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(
                    new MessageBoxStandardParams
                    {
                        ContentTitle = "Error",
                        ContentMessage = "Connection error",
                        Icon = MessageBox.Avalonia.Enums.Icon.Error,
                    });
                await mb.Show();
                return;
            }
            await PeriodicTask.Run(Measure, TimeSpan.FromSeconds(5));
        }



        private void Measure()
        {
            QueryPrimaryServingCell command = new QueryPrimaryServingCell();
            var temp = command.CreateWriteCommand(Array.Empty<ICommandParameter>());
            serial.Write(temp);
        }

        private void ReceiveAndParse(string output)
        {
            RSRQx.Add(counter);
            counter++;
            RSRQy.Add(1);
            plot.Plot.AddScatterLines(RSRQx.ToArray(), RSRQy.ToArray());
        }

        private void Stop(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Pause(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Export(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Import(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
