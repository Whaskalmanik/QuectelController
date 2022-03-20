using Avalonia.Controls;
using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuectelController.ParameterEditors
{
    public class IntegerParameterEditor : ParameterEditorBase<IntegerCommandParameter, NumericUpDown>
    {
        protected override NumericUpDown CreateControlInternal(IntegerCommandParameter parameter)
        {
            return new NumericUpDown();
            //TODO Integer List parameter editors
        }

        protected override object GetValueInternal(NumericUpDown control)
        {
            return control.Value;
        }
    }
}
