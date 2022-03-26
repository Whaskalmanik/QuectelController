using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Phonebook
{
    public class ReadPhonebookEntries : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Read Phonebook Entries";

        public override string Description => 
            @"This command reads phonebook entries in location number range <index1> ... <index2> from the current 
phonebook memory storage selected with AT+CPBS.If<index2> is omitted, only location <index1> will be returned.";

        public override CommandCategory Category => CommandCategory.Phonebook;

        public override IReadOnlyList<ICommandParameter> AvailableParameters { get; } = new[]
        {
           new StringCommandParameter("Find Text", "String type. The field of maximum length <tlength> in current TE character set specified by AT+CSCS.", false )
        };

        protected override string RawCommand => "AT+CPBR";
    }
}
