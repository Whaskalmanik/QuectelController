using Avalonia.Controls;
using QuectelController.Communication;
using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuectelController.ParameterEditors
{
    public class StringParameterEditor : ParameterEditorBase<StringCommandParameter, TextBox>
    {
        protected override TextBox CreateControlInternal(StringCommandParameter parameter)
        {
            return new TextBox();
        }

        protected override object GetValueInternal(TextBox control)
        {
            return control.Text;
        }
    }
}
