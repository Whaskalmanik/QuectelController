using Avalonia.Controls;
using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuectelController.ParameterEditors
{
    public class IntegerListParameterEditor : ParameterEditorBase<IntegerListCommandParameter, ComboBox>
    {
        protected override ComboBox CreateControlInternal(IntegerListCommandParameter parameter)
        {
            ComboBox comboBox = new ComboBox();
            var availableValues = parameter.AvailableValues.ToArray();
            var comboBoxItems = availableValues.Select(x => new ComboBoxItem()
            {
                Content = x.Value,

            }).ToArray();
            comboBox.Items = comboBoxItems;
            foreach ((var value, var item) in availableValues.Zip(comboBoxItems))
            {
                ToolTip.SetTip(item, value.Key);
            }
            return comboBox;
        }

        protected override object GetValueInternal(ComboBox control)
        {
            if(control.SelectedItem == null)
            {
                return null;
            }
            return (control.SelectedItem as ComboBoxItem).Content;
        }
    }
}
