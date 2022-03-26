using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class SetMACaddressofIPPassthroughRGMII : CommandBase
    {
        public override bool CanExecute => false;
        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Set MAC address of IP Passthrough-RGMII";

        public override string Description => "This command sets MAC address of IP Passthrough-RGMII mode.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new StringCommandParameter("host_mac_addr","String type. MAC address of the device connected to the module.",true),
        };

        protected override string RawCommand => " AT+QETH";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"ipptmac\"," + CreateParametersString(commandParameters);
        }
    }
}
