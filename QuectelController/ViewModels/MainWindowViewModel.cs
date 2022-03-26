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
using PropertyChanged;
using System.Reactive.Linq;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Models;
using Avalonia.Controls;
using Avalonia.Styling;
using MessageBox.Avalonia.Enums;
using QuectelController.Views;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using System.IO;
using Avalonia;
using Avalonia.Platform;
using System.Threading;

namespace QuectelController.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        SerialCommunication serialCommunication;

        public List<IATCommand> CommandsList { get; }
        public List<string> CommandsHistory { get; set; }

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
        public ReactiveCommand<IATCommand, Task> WriteCommand { get; }
        public ReactiveCommand<IATCommand, Unit> TestCommand { get; }
        public ReactiveCommand<Unit, Task> ExportLogCommand { get; }
        public ReactiveCommand<Unit, Task> ExportHistoryCommand { get; }
        public ReactiveCommand<Unit, Task> ImportHistoryCommand { get; }
        public ReactiveCommand<Unit, Task> ShowHistoryCommand { get; }
        public ReactiveCommand<Unit, Task> ExecuteHistoryCommand { get; }

        //Zvolené
        public string SerialPort { get; set; }
        public int Baudrate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public string ToSendValue { get; set; }
        public string TerminalString { get; set; }
        private StringBuilder TerminalStringBuilder { get; set; } = new StringBuilder();
        private IDisposable SerialCharactersSubscriptions { get; set; }

        private bool CanSend { get; set; } = false;
        public bool isProgressBarVissible { get; set; } = false;
        private string StatusBarColor { get; set; } = "Red";
        private string StatusBar { get; set; } = "Disconnected";

        private double ProgressValue { get; set; } = 0;

        [DoNotNotify]
        public Reactive.Bindings.ReactiveProperty<string> ToSearchValue { get; set; } = new Reactive.Bindings.ReactiveProperty<string>();
        public ObservableCollection<TreeViewCategory> Categories { get; init; }
        public ObservableCollection<TreeViewCategory> FilteredCategories { get; set; }


        public MainWindowViewModel()
        {
            ConnectCommand = ReactiveCommand.Create(Connect);
            DisconnectCommand = ReactiveCommand.Create(Disconnect);
            SendCommand = ReactiveCommand.Create(Send);
            ExecuteCommand = ReactiveCommand.Create<IATCommand>(Execute);
            WriteCommand = ReactiveCommand.Create<IATCommand,Task>(Write);
            ReadCommand = ReactiveCommand.Create<IATCommand>(Read);
            TestCommand = ReactiveCommand.Create<IATCommand>(Test);
            ExportHistoryCommand = ReactiveCommand.Create<Task>(ExportCommands);
            ExportLogCommand = ReactiveCommand.Create<Task>(ExportLog);
            ImportHistoryCommand = ReactiveCommand.Create<Task>(ImportLog);
            ShowHistoryCommand = ReactiveCommand.Create<Task>(ShowHistoryWindow);
            ExecuteHistoryCommand = ReactiveCommand.Create<Task>(ExecuteHistory);
            CommandsHistory = new List<string>();
            CommandsList = FillList();
            Categories = GetCategories();
            FilteredCategories = new ObservableCollection<TreeViewCategory>(Categories);
            ToSearchValue
                .Throttle(TimeSpan.FromSeconds(0.5))
                .Select(x => x?.Trim())
                .Where(x => x != null)
                .DistinctUntilChanged()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(Search);
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

        private async Task ExportCommands()
        {
            SaveFileDialog SaveFileBox = new SaveFileDialog();
            SaveFileBox.Title = "Save Commands History As...";
            List<FileDialogFilter> Filters = new List<FileDialogFilter>();
            FileDialogFilter filter = new FileDialogFilter();
            List<string> extension = new List<string>();
            extension.Add("log");
            filter.Extensions = extension;
            filter.Name = "Log file";
            Filters.Add(filter);
            SaveFileBox.Filters = Filters;

            SaveFileBox.DefaultExtension = "log";

            if (!CommandsHistory.Any())
            {
                var mb = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(
                    new MessageBoxStandardParams
                    {
                        ContentTitle = "Error",
                        ContentMessage = "Exported list is empty.",
                        Icon = Icon.Error,
                       // WindowIcon = new WindowIcon(AvaloniaLocator.Current.GetService<IAssetLoader>().Open(new Uri("Assets/avalonia-logo.ico"))),
                    }); 

                
                await mb.Show();
                return;
            }

            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var path = await SaveFileBox.ShowAsync(desktop.MainWindow);

                using (TextWriter tw = new StreamWriter(path))
                {
                    foreach (string line in CommandsHistory)
                        tw.WriteLine(line);
                }
            }

        }
        private async Task ExportLog()
        {
            SaveFileDialog SaveFileBox = new SaveFileDialog();
            SaveFileBox.Title = "Save Log As...";
            List<FileDialogFilter> Filters = new List<FileDialogFilter>();
            FileDialogFilter filter = new FileDialogFilter();
            List<string> extension = new List<string>();
            extension.Add("log");
            filter.Extensions = extension;
            filter.Name = "Log file";
            Filters.Add(filter);
            SaveFileBox.Filters = Filters;
            SaveFileBox.DefaultExtension = "log";

            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var path = await SaveFileBox.ShowAsync(desktop.MainWindow);
                await File.WriteAllTextAsync(path, TerminalString);
            }
        }

        private async Task ImportLog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open log";
            List<FileDialogFilter> Filters = new List<FileDialogFilter>();
            FileDialogFilter filter = new FileDialogFilter();
            List<string> extension = new List<string>();
            extension.Add("log");
            filter.Extensions = extension;
            filter.Name = "Log file";
            Filters.Add(filter);
            openFileDialog.Filters = Filters;
            openFileDialog.AllowMultiple = false;
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var path = await openFileDialog.ShowAsync(desktop.MainWindow);
                var logFile = File.ReadAllLines(path.FirstOrDefault());
                CommandsHistory = new List<string>(logFile);
            }
        }

        private async Task ShowHistoryWindow()
        {
            var window = new HistoryWindow(CommandsHistory);
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                await window.ShowDialog(desktop.MainWindow);
            }

            if (window.selectedValue == null) return;

            ToSendValue = window.selectedValue;

        }

        private async Task ExecuteHistory()
        {
            List<string> temp = new List<string>(CommandsHistory);

            if (CommandsHistory.Count == 0)
            {
                var mb = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(
                    new MessageBoxStandardParams
                    {
                        ContentTitle = "Info",
                        ContentMessage = "History is empty",
                        Icon = Icon.Info,
                    });
                var s = mb.Show();
                return;
            }
            if (!CommandsHistory.Any())
            {
                return;
            }

            StatusBar = "Executing";
            StatusBarColor = "Orange";
            isProgressBarVissible = true;
            ProgressValue = 0;
            int max = temp.Count();
            double increment = 100 / max;
            foreach (string command in temp)
            {
                ToSendValue = command;
                ProgressValue += increment;
                Send();
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
            isProgressBarVissible = false;
            ProgressValue = 0;
            StatusBar = "Connected";
            StatusBarColor = "Green";
        }


        private void OnStringReceived(string output)
        {
            TerminalStringBuilder.Append(output);
            TerminalString = TerminalStringBuilder.ToString();
        }

        private void Connect()
        {
            if (serialCommunication != null)
            {
                return;
            }
            StatusBar = "Connected";
            StatusBarColor = "Green";
            CanSend = true;
            serialCommunication = new SerialCommunication(SerialPort, Baudrate, DataBits, Parity, StopBits);
            TerminalStringBuilder.Clear();
            TerminalString = string.Empty;
            serialCommunication.Open();
            SerialCharactersSubscriptions = serialCommunication.ReceivedCharactersObservable
                .Subscribe(OnStringReceived);
        }
        private void Disconnect()
        {
            if (serialCommunication == null)
            {
                return;
            }
            StatusBar = "Disconnected";
            StatusBarColor = "Red";
            CanSend = false;
            SerialCharactersSubscriptions.Dispose();
            serialCommunication.Dispose();
            serialCommunication = null;
        }
        private void Send()
        {          
            if (serialCommunication == null)
            {
                return;
            }
            if(ToSendValue == null)
            {
                return;
            }
            if(!ToSendValue.Trim().Any())
            {
                return;
            }
            serialCommunication.Write(ToSendValue);
            TerminalStringBuilder.AppendLine(ToSendValue);
            CommandsHistory.Add(ToSendValue);
            TerminalString = TerminalStringBuilder.ToString();
        }

        private void Execute(IATCommand command)
        {
            ToSendValue = command.CreateExecuteCommand();
        }

        private async Task Write(IATCommand command)
        {
            if (!command.AvailableParameters.Any())
            {
                ToSendValue = command.CreateWriteCommand(Array.Empty<ICommandParameter>());
                return;
            }
            var window = new WriteWindow(command);
            window.Title = command.Name;


            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                await window.ShowDialog(desktop.MainWindow);
            }

            if (window.SelectedValues == null) return;

            var parameters = command.AvailableParameters.Select(x => x.Clone() as ICommandParameter).ToArray();

            for(int i =0;i<parameters.Length;i++)
            {
                parameters[i].Value = window.SelectedValues[i];
            }
            
            ToSendValue = command.CreateWriteCommand(parameters);

        }
        private void Read(IATCommand command)
        {
            ToSendValue = command.CreateReadCommand();
        }
        private void Test(IATCommand command)
        {
            ToSendValue = command.CreateTestCommand();
        }
        private void Search(string input)
        {
            var filtered = Categories
                .SelectMany(x => x.Items.Select(y => new { Category = x, Command = y }))
                .Where(x => MatchesFilter(x.Command.Command, input))
                .GroupBy(x => x.Category)
                .Select(x => new TreeViewCategory()
                {
                    CommandCategory = x.Key.CommandCategory,
                    Items = new ObservableCollection<TreeViewItem>(x.Select(y => y.Command))
                });
            FilteredCategories = new ObservableCollection<TreeViewCategory>(filtered);
        }

        private bool MatchesFilter(IATCommand command, string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return true;
            }

            List<bool> conditions = new List<bool>();
            foreach(var token in input.Split(" ").Select(x => x.Trim().ToLower()))
            {
                if (token.ToLower().StartsWith("c:") && token.Length > 2)
                {
                    var type = token.Substring(2).ToLower();
                    var condition = type switch
                    {
                        "test" => command.CanTest,
                        "write" => command.CanWrite,
                        "read" => command.CanRead,
                        "execute" => command.CanExecute,
                        _ => input.Contains(token)
                    };
                    conditions.Add(condition);
                }
                else
                {
                    bool containsDescription = command.Description.ToLower().Contains(token);
                    bool containsName = command.Name.ToLower().Contains(token);
                    conditions.Add(containsName || containsDescription);
                }
            }
            return conditions.All(x => x);
        }

        private List<IATCommand> FillList()
        {
            List<IATCommand> commands = new List<IATCommand>();
            commands.Add(new FindPhonebookEntriesCommand());
            return commands;
        }
    }
}
