using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Supplementary_Service
{
    public class CallingLineIdentificationPresentation : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Calling Line Identification Presentation";

        public override string Description => "This command refers to the GSM/UMTS supplementary service CLIP (Calling Line Identification Presentation) that enables a called subscriber to get the calling line identity(CLI) of the calling party when receiving a mobile terminated call. It has no effect on the execution of the supplementary service CLIP in the network.";

        public override CommandCategory Category => CommandCategory.SupplementaryServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("n","Integer type. Configures/shows the result code presentation status to the TE",new Dictionary<string, object> {
                { "Disable unsolicited result codes", 0 },
                { "Enable unsolicited result codes", 1 },
            },true),
        };

        protected override string RawCommand => "AT+CLIP";
    }
}
