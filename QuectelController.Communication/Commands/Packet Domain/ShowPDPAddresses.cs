using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Packet_Domain
{
    public class ShowPDPAddresses : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Show PDP Addresses";

        public override string Description => "This command returns a list of PDP addresses for the specified context identifiers. If no <cid> is specified, the addresses for all defined contexts are returned";

        public override CommandCategory Category => CommandCategory.PacketDomainCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("cid","Integer type. Specify a particular PDP context definition.",false),
            new StringCommandParameter("PDP_addr","String type. Identifies the MT in the address space applicable to the PDP. The address may be static or dynamic.For a static address, it will be the one set by the AT+CGDCONT command when the context was defined.For a dynamic address it will be the one assigned during the last PDP context activation that used the context definition referred to by <cid>. <PDP_addr> is omitted if no address is available.",false),
        };

        protected override string RawCommand => "AT+CGPADDR";
    }
}
