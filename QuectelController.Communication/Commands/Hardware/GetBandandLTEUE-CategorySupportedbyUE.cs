using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class GetBandandLTEUE_CategorySupportedbyUE : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override string Name => "Get Band and LTE UE-Category Supported by UE";

        public override string Description => "This command gets band and LTE UE-Category supported by UE, and queries whether CA is supported.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+ QGETCAPABILITY";
    }
}
