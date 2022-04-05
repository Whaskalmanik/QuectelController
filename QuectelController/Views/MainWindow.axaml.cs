using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using PropertyChanged;
using QuectelController.Communication;

namespace QuectelController.Views
{
    [DoNotNotify]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG   
            this.AttachDevTools();
#endif  
            //this.FindControl<TextBlock>("SearchTB").Tapped += MainWindow_Tapped; ;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            
        }


    }
}
