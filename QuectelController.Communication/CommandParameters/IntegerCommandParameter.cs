﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.CommandParameters
{
    public class IntegerCommandParameter : ICommandParameter
    {
        public IntegerCommandParameter(string name, string description, bool optional)
        {
            Name = name;
            Description = description;
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
