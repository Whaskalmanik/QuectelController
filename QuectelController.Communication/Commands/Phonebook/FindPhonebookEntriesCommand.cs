using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Phonebook
{
    public class FindPhonebookEntriesCommand : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Find Phonebook Entries";

        public override string Description =>
            @"This command searches the phonebook entries starting with the given <findtext> string from the current 
phonebook memory storage selected with AT+CPBS, and return all found entries sorted in alphanumeric order";

        public override CommandCategory Category => CommandCategory.Phonebook;

        public override IReadOnlyList<ICommandParameter> AvailableParameters { get; } = new[]
        {
           new IntegerCommandParameter("Index 1", "Integer type. The first phonebook record to be read.", false ),
           new IntegerCommandParameter("Index 2", "Integer type. The last phonebook record to be read.", true )
        };

        protected override string RawCommand => "AT+CPBF";
    }
}
