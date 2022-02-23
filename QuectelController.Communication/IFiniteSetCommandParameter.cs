using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication
{
    public interface IFiniteSetCommandParameter :ICommandParameter
    {
        IDictionary<string,object> AvailableValues { get; }

    }
}
