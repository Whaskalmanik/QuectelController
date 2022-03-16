using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class SendMessagesTextMode : CommandBase 
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Send Messages (Text Mode)";

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
            new StringCommandParameter("da",
                @"Destination address. 3GPP TS 23.040 TP-Destination-Address Address-Value field in 
string format; BCD numbers (or GSM 7-bit default alphabet characters) are
converted to characters of the currently selected TE character set (see AT+CSCS in
3GPP TS 27.007); type of address is given by <toda>.",false),
            
            new IntegerCommandParameter("tada","Integer type. Type of destination address. 3GPP TS 24.011 TP-Destination-Address Type-of-Address octet.",false),
        };

        protected override string RawCommand => "AT+CMGS";
    }
}
