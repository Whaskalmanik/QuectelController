using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class RequestMTFirmwareRevisionIdentification : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Request MT Firmware Revision Identification";

        public override string Description => "This Execution Command delivers the identification text of MT firmware version.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+GMR";
    }
}
