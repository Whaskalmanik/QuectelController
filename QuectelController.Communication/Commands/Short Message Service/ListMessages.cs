using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class ListMessages : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "List Messages";

        public override string Description => 
            @"This command returns messages with status value<stat> from preferred message storage <mem1> to
the TE.If the status of the message is REC UNREAD, the status in the storage changes to REC 
READ. When executing AT+CMGL without status value <stat>, it reports the list of SMS with REC
UNREAD status.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
          new IntegerListCommandParameter("stat","Depends if int text mode or in PDU mode",new Dictionary<string, object> {
                { "Delete the message specified in <index>", "\"REC UNREAD\"" },
                { "Delete the message specified in <index>", "\"REC READ\"" },
                { "Delete the message specified in <index>", "\"STO UNSENT\"" },
                { "Delete the message specified in <index>", "\"STO SENT\"" },
                { "Delete the message specified in <index>", "\"ALL\"" },

                { "Received unread messages", 0 },
                { "Received read messages", 1 },
                { "Stored unsent messages",2 },
                { "Stored sent messages", 3 },
                { "All messages", 4 },
            },true),
        };

        protected override string RawCommand => "AT+CMGL";
    }
}
