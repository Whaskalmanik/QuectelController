using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Packet_Domain
{
    public class _5GNRPacketDataCounter : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "5G NR Packet Data Counter";

        public override string Description => "This command allows the application to check how much bytes are sent to or received by MT in 5G NR.";

        public override CommandCategory Category => CommandCategory.PacketDomainCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("op","Integer type. The operation about data counter",new Dictionary<string, object> {
                { "Reset the data counter", 0 },
                { "Save the results of data counter to NVM", 1 },
            },false),
        };

        protected override string RawCommand => "AT+QGDNRCNT";
    }
}
