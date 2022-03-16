using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class NewMessageAcknowledgementtoMETAPDUMode : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "New Message Acknowledgement to ME/TA (PDU mode)";

        public override string Description => 
            @"This command confirms successful receipt of a new message (SMS-DELIVER or 
SMS-STATUS-REPORT) routed directly to the TE.If the UE does not receive acknowledgement within
required time(network timeout), it will send an RP-ERROR message to the network.The UE will
automatically disable routing to the TE by setting both<mt> and<ds> values of AT+CNMI to 0.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("n","Intenger type,Parameter required only for PDU mode",new Dictionary<string, object> {
                { "Command operates similarly as in text mode", 0 },
                { "Send positive (RP-ACK) acknowledgement to the network. Accepted only in PDU mode.", 1  },
                { "Send negative (RP-ERROR) acknowledgement to the network. Accepted only in PDU mode", 2 },
            },true),
            new IntegerCommandParameter("length",@"Message length. Indicate the length of the message body <data> (or <cdata>) in 
characters in the text mode (AT+CMGF=1), or the length of the actual TP data unit in octets 
(i.e. the RP layer SMSC address octets are not counted in the length) in PDU mode (AT+CMGF=0).",false),
        };

        protected override string RawCommand => "AT+CNMA";
    }
}
