using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using QuectelController.Communication;
using ReactiveUI;
using RJCP.IO.Ports;
using QuectelController.Communication.Commands.Phonebook;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;

namespace QuectelController.ViewModels
{
    public class MainWindowViewModel : ViewModelBase,INotifyPropertyChanged
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
        public ReactiveCommand<IATCommand, Unit> ExecuteCommand { get; }
        public ReactiveCommand<IATCommand, Unit> ReadCommand { get; }
        public ReactiveCommand<IATCommand, Unit> WriteCommand { get; }
        public ReactiveCommand<IATCommand, Unit> TestCommand { get; }

        //Zvolené
        public string SerialPort { get; set; }
        public int Baudrate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public string ToSendValue { get; set; }

        public ObservableCollection<TreeViewCategory> Categories { get; init; }



        public MainWindowViewModel()
        {
         
            ConnectCommand = ReactiveCommand.Create(Connect);
            DisconnectCommand = ReactiveCommand.Create(Disconnect);
            SendCommand = ReactiveCommand.Create(Send);
            ExecuteCommand = ReactiveCommand.Create<IATCommand>(Execute);
            WriteCommand = ReactiveCommand.Create<IATCommand>(Write);
            ReadCommand = ReactiveCommand.Create<IATCommand>(Read);
            TestCommand = ReactiveCommand.Create<IATCommand>(Test);
            CommandsList = FillList();
            Categories = GetCategories();
        }

        private ObservableCollection<TreeViewCategory> GetCategories()
        {
            return new ObservableCollection<TreeViewCategory>(
                typeof(IATCommand).Assembly.GetTypes()
                .Where(x => !x.IsAbstract && typeof(IATCommand).IsAssignableFrom(x) && x.GetConstructor(Type.EmptyTypes) != null)
                .Select(x => Activator.CreateInstance(x) as IATCommand)
                .GroupBy(x => x.Category)
                .Select(x =>
                    new TreeViewCategory()
                    {
                        CommandCategory = x.Key,
                        Items = new ObservableCollection<TreeViewItem>(
                            x.Select(y =>
                            new TreeViewItem()
                            {
                                Command = y
                            })
                            .ToList())
                    })
                .OrderBy(x => x.CommandCategory)
                );
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

        private void Execute(IATCommand command)
        {
            ToSendValue = command.CreateExecuteCommand();
        }
        private void Write(IATCommand command)
        {

        }
        private void Read(IATCommand command)
        {

        }
        private void Test(IATCommand command)
        {

        }


        private List<IATCommand> FillList()
        {
            List<IATCommand> commands = new List<IATCommand>();
            commands.Add(new FindPhonebookEntriesCommand());
            return commands;
        }
    }
}
