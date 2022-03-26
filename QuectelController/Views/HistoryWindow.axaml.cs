using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using PropertyChanged;
using System.Collections.Generic;

namespace QuectelController.Views
{
    [DoNotNotify]
    public partial class HistoryWindow : Window
    {
        private ListBox listBox;
        public string selectedValue = null;

        public HistoryWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif    
        }

        public HistoryWindow(List<string> commandsHistory) :this()
        {
            listBox = this.FindControl<ListBox>("HistoryLB");
            Populate(commandsHistory);
        }

        public void Populate(List<string> commandsHistory)
        {
            listBox.Items = commandsHistory;
        }

        private void Parse(object sender, RoutedEventArgs e)
        {
            selectedValue = listBox.SelectedItem.ToString();
            this.Close();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
