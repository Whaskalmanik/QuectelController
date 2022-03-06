using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Packet_Domain
{
    public class QueryRmNetDeviceStatus : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Query RmNet Device Status";

        public override string Description => "Query RmNet Device Status";

        public override CommandCategory Category => CommandCategory.PacketDomainCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("on_off","Integer type. Enable/Disable URC reporting RmNet device status.",new Dictionary<string, object> {
                { "Disable URC reporting RmNet device status", 0 },
                { "Enable URC reporting RmNet device status", 1 },
            },false),
        };

        protected override string RawCommand => "AT+QNETDEVSTATUS";
    }
}
