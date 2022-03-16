using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class SelectCellBroadcastMessageTypes : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Select Cell Broadcast Message Types";

        public override string Description => "This command selects which types of CBMs are to be received by the ME.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("mode","Intenger type",new Dictionary<string, object> {
                { "Message types specified in <mids> and <dcss> are accepted", 0 },
                { "Message types specified in <mids> and <dcss> are not accepted", 1  },
            },false),
            new StringCommandParameter("mids",@"String type. All different possible combinations of CBM message identifiers (see <mid>) (default: empty string), e.g. 0,1,5,320–478,922.",true),
            new StringCommandParameter("dcss",@"String type. All different possible combinations of CBM data coding schemes (see <dcs>) (default: empty string), e.g. 0–3,5.",true),
        };

        protected override string RawCommand => "AT+CSCB";
    }
}
