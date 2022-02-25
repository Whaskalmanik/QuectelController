using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Phonebook
{
    public class WritePhonebookEntry : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Write Phonebook Entry";

        public override string Description =>
            @"This command writes phonebook entry in location number <index> in the current phonebook memory 
storage selected with AT+CPBS.It can also delete a phonebook entry in location number<index>.";

        public override CommandCategory Category => CommandCategory.Phonebook;

        public override IReadOnlyList<ICommandParameter> AvailableParameters { get; } = new ICommandParameter[]
        {
           new IntegerCommandParameter("Index", "Integer type. In the range of location numbers of phone book memory.", false ),
           new StringCommandParameter("Text", "String type field of maximum length <tlength> in current TE character set specified by AT+CSCS.", true),
           new IntegerCommandParameter("Number", "Phone number", true ),
           new IntegerListCommandParameter("Type","Type of address of octet in integer format (See 3GPP TS 24.008). Usually, it has three kinds of values",new Dictionary<string, object> {
               { "(U)SIM phonebook", "SM" },
               { "MT dialed calls list", "DC" }
           },true)
        };


        protected override string RawCommand => "AT+CPBW";
    }
}
