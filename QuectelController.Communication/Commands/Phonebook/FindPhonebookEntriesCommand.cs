using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Phonebook
{
    public class FindPhonebookEntriesCommand : CommandBase
    {
        public override string Name => "Find Phonebook Entries";

        public override string Description =>
            @"This command searches the phonebook entries starting with the given <findtext> string from the current 
phonebook memory storage selected with AT+CPBS, and return all found entries sorted in alphanumeric order";

        public override CommandCategory Category => CommandCategory.Phonebook;

        public override IReadOnlyList<ICommandParameter> AvailableParameters { get; } = new[]
        {
           new StringCommandParameter("Find Text", "String type. The field of maximum length <tlength> in current TE character set specified by AT+CSCS.", false )
        };

        protected override string RawCommand => "AT+CPBF";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=" + CreateParametersString(commandParameters);
        }
    }
}
