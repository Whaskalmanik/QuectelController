using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class WriteMessagestoMemoryPDUMode : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Write Messages to Memory (PDU Mode)";

        public override string Description => 
            @"This command stores short messages from TE to memory storage <mem2>, and then the memory 
location<index> of the stored message is returned.Message status will be set to stored unsent by 
default; but parameter<stat> also allows other status values to be given.
The syntax of input text is the same as the one specified in AT+CMGS Write Command";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("length",@"Message length. Indicate in the text mode (AT+CMGF=1) the length of the message 
body <data> (or <cdata>) in characters; or in PDU mode (AT+CMGF=0), the length of 
the actual TP data unit in octets (i.e. the RP layer SMSC address octets are not 
counted in the length)",false),
            new IntegerListCommandParameter("stat","Intenger type",new Dictionary<string, object> {
                { "Received unread messages", 0 },
                { "Received read messages", 1  },
                { "Stored unsent messages", 2 },
                { "Stored sent messages", 3 },
                { "All messages", 4 },
            },true),
        };

        protected override string RawCommand => "AT+CMGW";
    }
}
