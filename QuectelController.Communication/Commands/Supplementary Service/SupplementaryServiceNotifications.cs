using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Supplementary_Service
{
    public class SupplementaryServiceNotifications : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Supplementary Service Notifications";

        public override string Description => "This command enables/disables the presentation of notification result codes from TA to TE.";

        public override CommandCategory Category => CommandCategory.SupplementaryServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("n","Integer type. Sets/indicates the +CSSI intermediate result code presentation status to the TE.",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable", 1 },
            },true),
            new IntegerListCommandParameter("m","Integer type. Sets/indicates the +CSSU unsolicited result code presentation status to TE.",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable", 1 },
            },true),
        };

        protected override string RawCommand => "AT+CSSN";
    }
}
