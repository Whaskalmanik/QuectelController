using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication
{
    public interface ICommandParameter
    {
        string Name { get; }
        string Description { get; }
        object Value { get; set; }
        bool Optional { get; }
        string ToCommandString();
    }
}
