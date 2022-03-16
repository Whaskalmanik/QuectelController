using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    class SetExtendedFormatofIncomingCallIndication : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Extended Format of Incoming Call Indication";

        public override string Description => 
            @"This command controls whether to use the extended format of incoming call indication or not. When it is 
enabled, an incoming call is indicated to TE with unsolicited result code +CRING: <type> instead of the
normal RING.";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("type","Integer type.",new Dictionary<string, object> {
                { "Disable extended format", 0 },
                { "nable extended format", 1 },
            },true),
        };

        protected override string RawCommand => "AT+CRC";
    }
}
