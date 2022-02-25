using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using QuectelController.Communication;
using ReactiveUI;
using RJCP.IO.Ports;
using QuectelController.Communication.Commands.Phonebook;

namespace QuectelController.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        SerialCommunication serialCommunication;
        public List<IATCommand> CommandsList  { get; }
        public string Greeting => "Welcome to Avalonia!";
        public string Button => "Muj butttonek";

        //Listy
        public List<string> SerialPorts => SerialCommunication.GetSerialPorts();
        public List<int> Baudrates { get; } = new List<int>() { 4800, 9600, 19200, 38400, 57600, 115200 };
        public List<int> DataBitsList { get; } = new List<int>() { 5, 6, 7, 8, 16 };
        public List<Parity> Parities { get; } = Enum.GetValues<Parity>().ToList();
        public List<StopBits> StopBitsList { get; } = Enum.GetValues<StopBits>().ToList();

        //Commandy
        public ReactiveCommand<Unit, Unit> ConnectCommand { get; }
        public ReactiveCommand<Unit, Unit> DisconnectCommand { get; }
        public ReactiveCommand<Unit, Unit> SendCommand { get; }

        //Zvolené
        public string SerialPort { get; set; }
        public int Baudrate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public string ToSendValue { get; set; }


        public MainWindowViewModel()
        {
            ConnectCommand = ReactiveCommand.Create(Connect);
            DisconnectCommand = ReactiveCommand.Create(Disconnect);
            SendCommand = ReactiveCommand.Create(Send);
            CommandsList = FillList();
        }

        private void Connect()
        {
            serialCommunication = new SerialCommunication(SerialPort, Baudrate, DataBits, Parity, StopBits);
        }
        private void Disconnect()
        {
            if (serialCommunication == null)
            {
                return;
            }
            serialCommunication.Dispose();
        }
        private void Send()
        {
            if(serialCommunication==null)
            {
                return;
            }
            serialCommunication.Write(ToSendValue);
            
        }
        private List<IATCommand> FillList()
        {
            List<IATCommand> commands = new List<IATCommand>();
            commands.Add(new FindPhonebookEntriesCommand());
            return commands;
        }
    }
}
