using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class DisplayMTIdentificationInformation : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Display MT Identification Information";

        public override string Description => "This Execution Command delivers the MT identification information text.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "ATI";
    }
}
