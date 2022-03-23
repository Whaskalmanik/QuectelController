using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class SignalQualityReport : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Signal Quality Report";

        public override string Description => @"This command indicates the received signal strength <RSSI> and the channel bit error rate <ber>. This Test Command returns values supported by MT.This Execution Command returns received signal strength indication<RSSI> and channel bit error rate<ber> from MT";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+CSQ";
    }
}
