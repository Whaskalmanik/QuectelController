using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class OriginateaCall : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Originate a Call";

        public override string Description => "This command sets up outgoing voice and data calls. Supplementary services can also be controlled with this command.";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "ATD<n>[<mgsm>][;]";
    }
}
