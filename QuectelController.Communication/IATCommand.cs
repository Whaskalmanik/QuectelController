using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication
{
    public interface IATCommand
    {
        bool CanExecute { get; }
        bool CanTest { get; }
        bool CanRead { get; }
        bool CanWrite { get; }

        string Name { get; }
        string Description { get; }
        CommandCategory Category { get; }
        IReadOnlyList<ICommandParameter> AvailableParameters { get; }
        string GetRawCommand();
        string CreateExecuteCommand();
        string CreateTestCommand();
        string CreateReadCommand();
        string CreateWriteCommand(IEnumerable<ICommandParameter> commandParameters);
        string FormatOutput(string rawOutput);
    }
}
