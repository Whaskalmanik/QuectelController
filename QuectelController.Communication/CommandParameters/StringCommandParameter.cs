using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuectelController.Communication.CommandParameters
{
    public class StringCommandParameter : ICommandParameter
    {
        public StringCommandParameter(string name, string description, bool optional)
        {
            Name = name;
            Description = Regex.Replace(description.Trim(), @"[^\S]+", " ");
            Optional = optional;
        }

        public string Name { get; init; }

        public string Description { get; init; }

        public object Value { get; set; }

        public bool Optional { get; init; }

        public string ToCommandString()
        {
            if (Value == null)
            {
                return "\"\"";
            }

            return $"\"{Value}\"";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
