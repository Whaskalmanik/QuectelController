using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication
{
    public abstract class ReadCommandBase : CommandBase, IReadATCommand
    {
        public string CreateReadCommand()
        {
            return RawCommand + "?";
        }
    }
}
