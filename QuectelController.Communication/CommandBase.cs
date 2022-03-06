using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication
{
    public abstract class CommandBase : IATCommand
    {

        public abstract bool CanExecute { get; }
        public abstract bool CanTest { get; }
        public abstract bool CanRead { get; }
        public abstract bool CanWrite { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract CommandCategory Category { get; }
        public abstract IReadOnlyList<ICommandParameter> AvailableParameters { get; }
        protected abstract string RawCommand { get; }

        public string CreateExecuteCommand()
        {
            if (!CanExecute)
            {
                throw new InvalidOperationException();
            }
            return RawCommand;
        }

        public string CreateTestCommand()
        {
            if (!CanTest)
            {
                throw new InvalidOperationException();
            }
            return RawCommand + "=?";
        }

        public string CreateReadCommand()
        {
            if (!CanRead)
            {
                throw new InvalidOperationException();
            }
            return RawCommand + "?";
        }

        public string CreateWriteCommand(IEnumerable<ICommandParameter> commandParameters)
        {
            if (!CanWrite)
            {
                throw new InvalidOperationException();
            }
            if (!CheckParameters(commandParameters))
            {
                return "Invalid parameters";
            }
            return CreateCommandInternal(commandParameters);
        }

        public virtual string FormatOutput(string rawOutput)
        {
            return rawOutput;
        }

        protected virtual string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=" + CreateParametersString(commandParameters);
        }

        protected bool CheckParameters(IEnumerable<ICommandParameter> commandParameters)
        {
            throw new NotImplementedException();
        }

        protected string CreateParametersString(IEnumerable<ICommandParameter> commandParameters)
        {
            if(!CheckParameters(commandParameters))
            {
                return "Chyba parametrů";
            }
            throw new NotImplementedException();
        }
    }
}
