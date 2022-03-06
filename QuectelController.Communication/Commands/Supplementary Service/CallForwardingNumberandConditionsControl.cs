using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Supplementary_Service
{
    public class CallForwardingNumberandConditionsControl : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Call Forwarding Number and Conditions Control";

        public override string Description => "This command allows control of the call forwarding supplementary service according to 3GPP TS 22.082. Registration, erasure, activation, deactivation and status query are supported. ";

        public override CommandCategory Category => CommandCategory.SupplementaryServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("reads","Integer type.",new Dictionary<string, object> {
                { "Unconditional", 0 },
                { "Mobile busy", 1 },
                { "No reply", 2 },
                { "Not reachable", 3 },
                { "All call forwarding (see 3GPP TS 22.030)", 4 },
                { "All conditional call forwarding (see 3GPP TS 22.030)", 5 },
            },false),
            new IntegerListCommandParameter("mode","Integer type.",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable", 1 },
                { "Query status", 2 },
                { "Registration", 3 },
                { "Erasure", 4 },
            },false),
            new StringCommandParameter("number","String type. Phone number of forwarding address in format specified by <type>.",true),
            new IntegerCommandParameter("type","Integer type. Type of address; default value is 145 when dialing string includes international access code character + otherwise, 129.",true),
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
            },false),
            new StringCommandParameter("subaddr","String type. Sub-address in the format specified by <satype>",true),
            new IntegerCommandParameter("satype","Integer type. Type of sub-address",true),
            new IntegerCommandParameter("time","Integer type. When \"no reply\", \"all call forwarding\" or \"all conditional call forwarding\" is enabled or queried, this gives the time in seconds to wait before call is forwarded, defaultvalue is 20",true),
        };

        protected override string RawCommand => "AT+CCFC";
    }
}
