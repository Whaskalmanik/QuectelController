using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class CallStatusIndication : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Call Status Indication";

        public override string Description => "This command indicates the call status.";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("n","Integer type. Enable/disable the URC of DSCI.",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable", 1 },
            },true),
        };

        protected override string RawCommand => "AT^DSCI";
    }
}
