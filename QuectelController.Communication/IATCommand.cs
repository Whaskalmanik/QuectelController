using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication
{
    public interface IATCommand
    {
        string Name { get; }
        string Description { get; }
        CommandCategory Category { get; }
        IReadOnlyList<ICommandParameter> AvailableParameters { get; }

        string CreateCommand(IEnumerable<ICommandParameter> commandParameters);
        string CreateTestCommand();
        string FormatOutput(string rawOutput);


    }
}
