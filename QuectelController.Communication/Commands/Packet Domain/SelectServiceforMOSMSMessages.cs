using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Packet_Domain
{
    public class SelectServiceforMOSMSMessages : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Select Service for MO SMS Messages";

        public override string Description => "This command specifies the service or service preference that the MT will use to send MO (mobile originated) SMS messages.";

        public override CommandCategory Category => CommandCategory.PacketDomainCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
             new IntegerListCommandParameter("service","A numeric parameter which indicates the service or service preference to be used.",new Dictionary<string, object> {
                { "Packet domain", 0 },
                { "Circuit switched", 1 },
                { "Packet domain preferred (use circuit switched if GPRS not available)", 2 },
                { "Circuit switch preferred (use Packet Domain if circuit switched not available)", 3 },
            },false),
        };

        protected override string RawCommand => "AT+CGSMS";
    }
}
