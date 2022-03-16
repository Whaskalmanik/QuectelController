using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class DeleteMessages : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Delete Messages";

        public override string Description => "This command deletes short messages from the preferred message storage <mem1> location <index>. If<delflag> is presented and not set to 0, the ME should ignore<index> and follow the rules of<delflag> shown as below.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("index","Integer type value in the range of location numbers supported by the associated memory.",false),
            new IntegerListCommandParameter("delflag","Integer type. Delete flag.",new Dictionary<string, object> {
                { "Delete the message specified in <index>", 0 },
                { "Delete all read messages from <mem1> storage", 1 },
                { "Delete all read messages from <mem1> storage and sent mobile originated messages",2 },
                { "Delete all read messages from <mem1> storage, sent and unsent mobile originated messages", 3 },
                { "Delete all messages from <mem1> storage", 4 },
            },true),

        };

        protected override string RawCommand => " AT+CMGD";
    }
}
