using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using PropertyChanged;
using QuectelController.Communication;
using ReactiveUI;
using System.Collections.Generic;
using System.Linq;

namespace QuectelController.Views
{
    [DoNotNotify]
    public partial class WriteWindow : Window
    {
        private Grid gridLayout;
        private TextBlock describtion;


        public WriteWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif      
        }

        public WriteWindow(IATCommand command) : this()
        {
            gridLayout = this.FindControl<Grid>("GridLayout");
            describtion = this.FindControl<TextBlock>("TextBoxDescribtion");
            Populate(command); 
        }

        private void Populate(IATCommand command)
        {
            gridLayout.RowDefinitions.Clear();
            describtion.Text = command.Description;
            foreach ((var parameter, var index) in command.AvailableParameters.Select((x, i) => (x, i)))
            {
                gridLayout.RowDefinitions.Add(new RowDefinition(GridLength.Auto));

                Label label = new Label();
                label.Content = parameter.Name;
                gridLayout.Children.Add(label);
                label.SetValue(Grid.ColumnProperty, 0);
                label.SetValue(Grid.RowProperty, index);
                label.Margin = Thickness.Parse("0, 1, 5, 0");
                label.SetValue(ToolTip.TipProperty, parameter.Description);

               /* 
                ComboBox comboBox = new ComboBox();
                comboBox.Margin = Thickness.Parse("0, 1, 5, 0");
                comboBox.SetValue(Grid.ColumnProperty, 0);
                comboBox.SetValue(Grid.RowProperty, index);
                */


                TextBox textBox = new TextBox();
                gridLayout.Children.Add(textBox);
                textBox.SetValue(Grid.ColumnProperty, 1);
                textBox.SetValue(Grid.RowProperty, index);
                textBox.Margin = Thickness.Parse("0, 1, 5, 0");

            }
        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {

        }

        public void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
