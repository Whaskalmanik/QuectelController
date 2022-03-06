using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Supplementary_Service
{
    public class ConnectedLineIdentificationPresentation : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Connected Line Identification Presentation";

        public override string Description => 
            @"This command enables/disables a calling subscriber to get the connected line identity (COL) of the called 
party after setting up a mobile originated call, referring to the GSM/UMTS supplementary service COLP
(Connected Line Identification Presentation). MT enables or disables the presentation of the COL
(Connected Line) at the TE for a mobile originating a call.It has no effect on the execution of the
supplementary service COLR in the network.";

        public override CommandCategory Category => CommandCategory.SupplementaryServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("n","Integer type. Set/present the result code presentation status in the MT",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable", 1 },
            },true),
        };

        protected override string RawCommand => "AT+COLP";
    }
}
