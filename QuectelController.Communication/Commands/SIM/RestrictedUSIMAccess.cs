using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class RestrictedUSIMAccess : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Restricted (U)SIM Access";

        public override string Description => "This command offers easy and limited access to the (U)SIM database. It transmits the (U)SIM command <command> and its required parameters to MT.";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => throw new NotImplementedException();

        protected override string RawCommand => "AT+CRSM";
    }
}
