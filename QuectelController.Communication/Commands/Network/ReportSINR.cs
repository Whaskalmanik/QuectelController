using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class ReportSINR : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override string Name => "Report SINR";

        public override string Description => "The command queries and reports the SINR of the current service network.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();
        protected override string RawCommand => "AT+QSINR";
    }
}
