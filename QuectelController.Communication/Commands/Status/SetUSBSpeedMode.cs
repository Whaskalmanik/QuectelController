using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class SetUSBSpeedMode : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Set USB Speed Mode";

        public override string Description => "This command sets USB speed mode when device is inserted in a USB 3.0 port.";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new StringListParameter("speed","String type.",new Dictionary<string, object> {
                { "USB 2.0 highspeed","20" },
                { "USB 3.0 superspeed","30" },
            },true),
        };

        protected override string RawCommand => "AT+QCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"usbspeed\"" + CreateParametersString(commandParameters);
        }
    }
}
