using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class WriteMessagestoMemoryTestMode : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Write Messages to Memory (Text mode)";

        public override string Description => 
            @"This command stores short messages from TE to memory storage <mem2>, and then the memory 
location<index> of the stored message is returned.Message status will be set to stored unsent by 
default; but parameter<stat> also allows other status values to be given.
The syntax of input text is the same as the one specified in AT+CMGS Write Command";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringCommandParameter("address","Destination address or Originating address",false),
            new StringCommandParameter("type","Type of originating address or destination address octet in integer format" ,true),
            new IntegerListCommandParameter("stat","String type",new Dictionary<string, object> {
                { "Received unread messages", "REC UNREAD" },
                { "Received read messages", "REC READ"  },
                { "Stored unsent messages","STO UNSENT" },
                { "Stored sent messages", "STO SENT" },
                { "All messages", "ALL" },
            },true),
        };

        protected override string RawCommand => "AT+CMGW";
    }
}
