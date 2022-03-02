using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class RequestInternationalMobileSubscriberIdentity : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Request International Mobile Subscriber Identity";

        public override string Description => 
            @"This command requests the International Mobile Subscriber Identity (IMSI) which is intended to permit the 
TE to identify the individual(U)SIM card or active application in the UICC(GSM or (U) SIM) that is
attached to MT.";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+CIMI";
    }
}
