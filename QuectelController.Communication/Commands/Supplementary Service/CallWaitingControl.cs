using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Supplementary_Service
{
    public class CallWaitingControl : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Call Waiting Control";

        public override string Description => "This command allows control of the call waiting supplementary service according to 3GPP TS 22.083. Activation, deactivation and status query are supported.";

        public override CommandCategory Category => CommandCategory.SupplementaryServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("n","Integer type.",new Dictionary<string, object> {
                { "Disable presentation of an unsolicited result code", 0 },
                { "Enable presentation of an unsolicited result code", 1 },
            },true),
            new IntegerListCommandParameter("mode","When <mode> is omitted, network is not interrogated.",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable", 1 },
                { "Query status", 2 },
            },true),
            new IntegerListCommandParameter("classx","Integer type. Each represents a class of information.",new Dictionary<string, object> {
                { "Voice (telephony)", 1 },
                { "Data (refers to all bearer services; and this may only see some bearer services if TA does not support values 16, 32, 64 and 128 with <mode>=2)", 2 },
                { "Fax (facsimile services)", 4 },
                { "Voice, data and fax", 7 },
                { "Short message service", 8 },
                { "Data circuit synchronization", 16 },
                { "Data circuit asynchronization", 32 },
                { "Dedicated packet access", 64 },
                { "Dedicated PAD access", 128 },
            },true),
        };

        protected override string RawCommand => "AT+CCWA";
    }
}
