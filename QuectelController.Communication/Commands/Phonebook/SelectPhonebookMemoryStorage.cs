using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Phonebook
{
    public class SelectPhonebookMemoryStorage : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Select Phonebook Memory Storage";

        public override string Description => 
            @"This command selects phonebook memory storage, which is used by other phonebook related 
commands.The Read Command returns currently selected memory, the number of used locations and
the total number of locations in the memory when supported by manufacturer.The Test Command returns
supported storages as compound value";

        public override CommandCategory Category => CommandCategory.Phonebook;

        public override IReadOnlyList<ICommandParameter> AvailableParameters { get; } = new[]
        {
           new StringListParameter("Storage", "String type", new Dictionary<string, object> { 
               { "(U)SIM phonebook", "SM" },
               { "MT dialed calls list", "DC" }, 
               { "(U)SIM fix dialing-phone book", "FD" },
               { "(U)SIM last-dialing-phone book", "LD" },
               { "MT missed (unanswered) calls list", "MC" },
               { "Mobile equipment phonebook", "ME" },
               { "MT received calls list", "RC" },
               { "(U)SIM (or MT) emergency number", "EN" },
               { "(U)SIM own numbers (MSISDNs) list", "ON" },
           } ,false)
        };

        protected override string RawCommand => "AT+CPBS";
    }
}
