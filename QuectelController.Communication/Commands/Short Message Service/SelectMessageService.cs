using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class SelectMessageService : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Select Message Service";

        public override string Description => "This command selects message service <service> and queries the types of messages supported by MT.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("service","Integer type. Type of message service.",new Dictionary<string, object> {
            { 
                    @"3GPP TS 23.040 and 3GPP TS 23.041 (the syntax of SMS AT commands is 
compatible with 3GPP TS 27.005 Phase 2 version 4.7.0; Phase 2+ features
which do not require new command syntax can be supported, e.g. correct
routing of messages with new Phase 2+ data coding schemes).", 0 },
            { 
                    @"3GPP TS 23.040 and 3GPP TS 23.041 (the syntax of SMS AT commands 
is compatible with 3GPP TS 27.005 Phase 2+ version; the requirement of
<service> setting 1 is mentioned under corresponding command descriptions).", 1 },
            },false),
        };

        protected override string RawCommand => "AT+CSMS";
    }
}
