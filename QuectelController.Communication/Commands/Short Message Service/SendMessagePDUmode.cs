using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class SendMessagePDUmode : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Send Messages (PDU Mode)";

        public override string Description =>
            @"This command sends a short message from TE to the network (SMS-SUBMIT). After invoking the Write 
Command, wait for the prompt > and then start to write the message.After that, enter <CTRL+Z> to
indicate the ending of PDU and begin to send the message.Sending can be cancelled by giving<ESC>
character. Abortion is acknowledged with OK, though the message will not be sent.The message
reference<mr> is returned to the TE on successful message delivery. The value can be used to identify
message upon unsolicited delivery status report result code.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("length",@"Message length. Indicate in the text mode (AT+CMGF=1) the length of the message 
body <data> (or <cdata>) in characters; or in PDU mode (AT+CMGF=0), the length of 
the actual TP data unit in octets (i.e. the RP layer SMSC address octets are not 
counted in the length)",false),
        };

        protected override string RawCommand => "AT+CMGS";
    }
}
