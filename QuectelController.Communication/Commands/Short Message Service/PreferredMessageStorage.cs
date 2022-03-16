using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class PreferredMessageStorage : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Preferred Message Storage";

        public override string Description => "This command selects memory storages <mem1>, <mem2> and <mem3> to be used for reading, writing, etc. ";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringListParameter("mem1","String type. Messages to be read and deleted from this memory storage.",new Dictionary<string, object> {
                { "(U)SIM message storage", "SM" },
                { "Mobile equipment message storage", "ME" },
                { "Same as \"ME\" storage", "MT" },
                { "SMS status report storage location", "SR" },
            },false),
            new StringListParameter("mem1","String type. Messages will be written and sent to this memory storage.",new Dictionary<string, object> {
                { "(U)SIM message storage", "SM" },
                { "Mobile equipment message storage", "ME" },
                { "Same as \"ME\" storage", "MT" },
                { "SMS status report storage location", "SR" },
            },true),
            new StringListParameter("mem1","String type. Received messages will be placed in this memory storage if routing to PC is not set (AT+CNMI).",new Dictionary<string, object> {
                { "(U)SIM message storage", "SM" },
                { "Mobile equipment message storage", "ME" },
                { "Same as \"ME\" storage", "MT" },
                { "SMS status report storage location", "SR" },
            },true),
        };
         
        protected override string RawCommand => "AT+CPMS";
    }
}
