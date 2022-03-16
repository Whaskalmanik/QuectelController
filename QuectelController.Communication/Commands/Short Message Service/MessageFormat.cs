using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class MessageFormat : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Message Format";

        public override string Description => 
            @"This command specifies the input and output format of the short messages. <mode> indicates the format 
of messages used with send, list, read and write message commands and unsolicited result codes 
resulting from received messages.
The format of messages can be either PDU mode (entire TP data units used) or text mode (headers and
body of the messages given as separate parameters). Text mode uses the value of parameter <chset>
specified by AT+CSCS to inform the character set to be used in the message body in the TA-TE interface";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("mode","Integer type.",new Dictionary<string, object> {
                { "PDU mode", 0 },
                { "Text mode", 1 },
            },true),
        };

        protected override string RawCommand => "AT+CMGF";
    }
}
