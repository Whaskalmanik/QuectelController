using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Supplementary_Service
{
    public class CallingLineIdentificationRestriction : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Calling Line Identification Restriction";

        public override string Description =>
            @"This command refers to the CLIR supplementary service (Calling Line Identification Restriction) according 
to 3GPP TS 22.081 and the OIR supplementary service(Originating Identification Restriction) according
to 3GPP TS 24.607 that allows a calling subscriber to enable or disable the presentation of the calling line
identity(CLI) to the called party when originating a call.

The Write Command overrides the CLIR subscription (default is restricted or allowed) when temporary
mode is provisioned as a default adjustment for all following outgoing calls.This adjustment can be
revoked by using the opposite command";

        public override CommandCategory Category => CommandCategory.SupplementaryServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("n","Integer type. Sets the adjustment for outgoing calls.",new Dictionary<string, object> {
                { "Presentation indicator is used according to the subscription of the CLIR service", 0 },
                { "CLIR invocation", 1 },
                { "CLIR suppression", 1 },
            },false),
        };

        protected override string RawCommand => "AT+CLIR";
    }
}
