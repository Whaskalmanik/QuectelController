using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PropertyChanged;
using System.Collections.Generic;

namespace QuectelController.Views
{
    [DoNotNotify]
    public partial class HistoryWindow : Window
    {
        private ListBox listBox;


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
            listBox.Items = commandsHistory;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
