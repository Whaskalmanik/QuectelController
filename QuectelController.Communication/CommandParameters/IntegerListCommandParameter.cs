using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.CommandParameters
{
    public class IntegerListCommandParameter : IFiniteSetCommandParameter
    {
        public IntegerListCommandParameter(string name, string description, IDictionary<string, object> availableValues, bool optional)
        {
            Name = name;
            Description = description;
            Optional = optional;
            AvailableValues = availableValues;
        }

        public IDictionary<string, object> AvailableValues { get; init; }
        public string Name { get; init; }

        public string Description { get; init; }

        public object Value { get; set; }

        public bool Optional { get; init; }
        public string ToCommandString()
        {
            if (Value == null)
            {
                return string.Empty;
            }

            return Value.ToString();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
