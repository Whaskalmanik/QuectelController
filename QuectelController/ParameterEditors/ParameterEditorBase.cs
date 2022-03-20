using Avalonia.Controls;
using QuectelController.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuectelController.ParameterEditors
{
    public abstract class ParameterEditorBase<T, TControl> : IParameterEditor<T> where T : ICommandParameter where TControl : Control
    {
        public Control CreateControl(ICommandParameter parameter)
        {
            if (parameter is T typedParameter)
            {
                return CreateControlInternal(typedParameter);
            }
            throw new ArgumentException();
        }

        public object GetValue(Control control)
        {
            if(control is TControl typedControl)
            {
                return GetValueInternal(typedControl);
            }
            return null;
        }

        protected abstract object GetValueInternal(TControl control);
        protected abstract TControl CreateControlInternal(T parameter);
    }
}
