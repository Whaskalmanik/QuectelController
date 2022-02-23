using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication
{
    public abstract class CommandBase : IATCommand
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract CommandCategory Category { get; }

        public abstract IReadOnlyList<ICommandParameter> AvailableParameters { get; }

        protected abstract string RawCommand{get;}

        public string CreateCommand(IEnumerable<ICommandParameter> commandParameters)
        {
            if (!CheckParameters(commandParameters))
            {
                return "Invalid parameters";
            }
            return CreateCommandInternal(commandParameters);
        }

        public string CreateTestCommand()
        {
            return RawCommand + "=?";
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
            //check jestli jsou všechny neoptional zahrnuty
            //check jestli je optional tak všechny před ním optional musí být
            throw new NotImplementedException();
        }

        protected string CreateParametersString(IEnumerable<ICommandParameter> commandParameters)
        {
            // z parametrů dělat raw command to sent
            throw new NotImplementedException();
        }
    }
}
