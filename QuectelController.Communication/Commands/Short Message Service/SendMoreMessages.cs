using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class SendMoreMessages : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Send More Messages";

        public override string Description => "This command controls the continuity of the SMS relay protocol link. If the feature is enabled (and supported by the currently used network) multiple messages can be sent faster as the link is kept opening.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
{
            new IntegerListCommandParameter("n","Integer type.",new Dictionary<string, object> {
                { "Feature disabled", 0 },
                { 
                    @"Keep enabled until the time between the response of the latest commands to be sent 
(AT+CMGS, AT+CMSS, etc.) and the next command to be sent exceeds 1–5
seconds (the exact value is up to ME implementation); then ME shall close the link and
MT switches <n> back to 0 automatically.", 1 },
                { 
                    @"Feature enabled. If the time between the response of the latest commands to be sent 
and the next command to be sent exceeds 1–5 seconds (the exact value is up to
ME implementation), ME shall close the link but MT will not switch <n> back to 0 automatically.", 2 },
            },true),
        };

        protected override string RawCommand => "AT+CMMS";
    }
}
