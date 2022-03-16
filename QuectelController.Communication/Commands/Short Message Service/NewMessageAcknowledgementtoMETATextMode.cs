using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class NewMessageAcknowledgementtoMETATextMode : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "New Message Acknowledgement to ME/TA (Text Mode)";

        public override string Description => @"This command confirms successful receipt of a new message (SMS-DELIVER or 
SMS-STATUS-REPORT) routed directly to the TE. If the UE does not receive acknowledgement within 
required time (network timeout), it will send an RP-ERROR message to the network. The UE will 
automatically disable routing to the TE by setting both <mt> and <ds> values of AT+CNMI to 0.";
        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+CNMA";
    }
}
