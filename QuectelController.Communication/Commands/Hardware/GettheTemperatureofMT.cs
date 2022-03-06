using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class GettheTemperatureofMT : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Get the Temperature of MT";

        public override string Description => "This command gets the temperature of MT in °C";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+QTEMP";
    }
}
