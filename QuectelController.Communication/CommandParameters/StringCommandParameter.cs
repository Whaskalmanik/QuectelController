using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.CommandParameters
{
    public class StringCommandParameter : ICommandParameter
    {
        public string Name { get; init; }

        public string Description { get; init; }

        public object Value { get; set; }

        public bool Optional { get; init; }

        public StringCommandParameter(string name, string description, bool optional)
        {
            Name = name;
            Description = description;
            Optional = optional;
        }

        public string ToCommandString()
        {
            return $"\"{Value}\"";
        }
    }
}
