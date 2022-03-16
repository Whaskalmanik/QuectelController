using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class SendMessagesfromStorage : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Send Messages from Storage";

        public override string Description => "This command sends a message with location value <index> from message storage <mem2> to the network.If a new recipient address<da> is given for SMS-SUBMIT, it should be used instead of the one stored with the message.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("index","Integer type in the range of location numbers supported by the associated memory.",false),
            new StringCommandParameter("da",@"Destination Address. 3GPP TS 23.040 TP-Destination-Address Address-Value field in 
string format; BCD numbers (or GSM 7-bit default alphabet characters) are
converted to characters of the currently selected TE character set (see AT+CSCS in
3GPP TS 27.007); type of address is given by <toda>.",true),
            new StringCommandParameter("toda","Type of destination address. 3GPP TS 24.011 TP-Destination-Address Type-of-Address octet in integer format." ,true),
        };

        protected override string RawCommand => "AT+CMSS";
    }
}
