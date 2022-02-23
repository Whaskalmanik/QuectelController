using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication
{
    public interface IReadATCommand : IATCommand 
    {
        string CreateReadCommand();
    }
}
