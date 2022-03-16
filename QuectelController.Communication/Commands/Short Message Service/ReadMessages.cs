using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class ReadMessages : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Read Messages";

        public override string Description => "This command returns SMS message with location value <index> from message storage <mem1> to the TE. If status of the message is REC UNREAD, status in the storage will change to REC READ.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter("index","In the range of location numbers supported by the associated memory.",true),
        };

        protected override string RawCommand => "AT+CMGR";
    }
}
