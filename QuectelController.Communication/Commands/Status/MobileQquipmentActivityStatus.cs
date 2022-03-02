using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class MobileQquipmentActivityStatus : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Mobile Equipment Activity Status";

        public override string Description => "This command queries the activity status of the ME.";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+CPAS";
    }
}
