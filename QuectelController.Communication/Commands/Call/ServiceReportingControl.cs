using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class ServiceReportingControl : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Service Reporting Control";

        public override string Description => 
            @"This command controls whether the MT to transmit an intermediate result code +CR: <serv> to the TE or not when a call is set up. 
If it is enabled, the intermediate result code is transmitted at the point during connect negotiation at which 
the MT has determined which speed and quality of service will be used, before any error control or data 
compression reports and before any final result code (e.g. CONNECT) is transmitted.";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("type","Integer type.",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable", 1 },
            },true),
        };

        protected override string RawCommand => "AT+CR";
    }
}
