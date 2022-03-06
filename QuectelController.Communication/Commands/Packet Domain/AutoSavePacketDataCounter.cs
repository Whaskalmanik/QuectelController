using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Packet_Domain
{
    public class AutoSavePacketDataCounter : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Auto Save Packet Data Counter";

        public override string Description => "This command allows AT+QGDCNT/AT+QGDNRCNT to save results to NVM automatically";

        public override CommandCategory Category => CommandCategory.PacketDomainCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("value","Integer type. The parameter is the time-interval for AT+QGDCNT/AT+QGDNRCNT to save results to NVM automatically. If it is set to 0, auto-save feature is disabled. Range: 0, 30–65535. Default: 0. Unit: second",false),
        };

        protected override string RawCommand => "AT+QAUGDCNT";
    }
}
