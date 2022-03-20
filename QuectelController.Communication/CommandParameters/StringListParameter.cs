﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.CommandParameters
{
    public class StringListParameter : IFiniteSetCommandParameter
    {
        public IDictionary<string, object> AvailableValues { get; init; }

        public string Name { get; init; }

        public string Description { get; init; }

        public object Value { get; set; }

        public bool Optional { get; init; }

        public StringListParameter(string name, string description, IDictionary<string,object> availableValues, bool optional)
        {
            Name = name;
            Description = description;
            Optional = optional;
            AvailableValues = availableValues;
        }

        public string ToCommandString()
        {
            return $"\"{Value}\"";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
