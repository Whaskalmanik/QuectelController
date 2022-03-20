using Avalonia.Controls;
using QuectelController.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuectelController.ParameterEditors
{
    public interface IParameterEditor<in T> : IParameterEditor where T : ICommandParameter
    {

    }
    public interface IParameterEditor 
    {
        Control CreateControl(ICommandParameter parameter);
        object GetValue(Control control);
    }
}
