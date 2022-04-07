using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using PropertyChanged;
using QuectelController.Communication;
using QuectelController.ParameterEditors;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace QuectelController.Views
{
    [DoNotNotify]
    public partial class WriteWindow : Window
    {
        public List<object> SelectedValues { get; private set; }
        public bool? isIgnored = false;

        private Grid gridLayout;
        private TextBox describtion;
        private List<Control> parameterEditorControls = new List<Control>();
        private readonly IATCommand command;
        private CheckBox checkBox;

        private Dictionary<Type, IParameterEditor> Editors { get; } = Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => !x.IsAbstract && typeof(IParameterEditor).IsAssignableFrom(x))
            .Select(x => new { type = x, @interface = x.GetInterfaces().FirstOrDefault(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IParameterEditor<>)) })
            .Where(x => x.@interface != null)
            .ToDictionary(
                x => x.@interface.GetGenericArguments()[0],
                x => Activator.CreateInstance(x.type) as IParameterEditor);

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
            describtion = this.FindControl<TextBox>("TextBoxDescribtion");
            checkBox = this.FindControl<CheckBox>("CheckBox");
            Populate(command);
            this.command = command;
        }

        private void Populate(IATCommand command)
        {
            gridLayout.RowDefinitions.Clear();
            describtion.Text = Regex.Replace(command.Description.Trim(), @"[^\S]+", " ");
            foreach ((var parameter, var index) in command.AvailableParameters.Select((x, i) => (x, i)))
            {
                gridLayout.RowDefinitions.Add(new RowDefinition(GridLength.Auto));

                Label label = new Label();
                label.Content = parameter.Name;
                if (!parameter.Optional)
                {
                    label.Content += "*";
                }

                gridLayout.Children.Add(label);
                label.SetValue(Grid.ColumnProperty, 0);
                label.SetValue(Grid.RowProperty, index);
                label.Margin = Thickness.Parse("0, 1, 5, 0");
                label.SetValue(ToolTip.TipProperty, parameter.Description);

                var editor = GetParameterEditor(parameter);
                var control = editor.CreateControl(parameter);
                gridLayout.Children.Add(control);
                control.SetValue(Grid.ColumnProperty, 1);
                control.SetValue(Grid.RowProperty, index);
                control.Margin = Thickness.Parse("0, 1, 5, 0");
                parameterEditorControls.Add(control);
            }
        }

        private IParameterEditor GetParameterEditor(ICommandParameter parameter)
        {
            if(Editors.TryGetValue(parameter.GetType(), out var editor))
            {
                return editor;
            }
            throw new ArgumentException();
        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            SelectedValues = GetValues();
            isIgnored = checkBox.IsChecked;
            Close();
        }

        private List<object> GetValues()
        {
            List<object> values = new List<object>();
            foreach((var parameter, var control) in command.AvailableParameters.Zip(parameterEditorControls))
            {
                var editor = GetParameterEditor(parameter);
                values.Add(editor.GetValue(control));
            }
            return values;
        }
            
        public void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
