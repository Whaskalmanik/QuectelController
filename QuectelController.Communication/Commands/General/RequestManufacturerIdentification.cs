using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class RequestManufacturerIdentification : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Request Manufacturer Identification";

        public override string Description => "This Execution Command returns the manufacturer identification text.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+GMI";
    }
}
