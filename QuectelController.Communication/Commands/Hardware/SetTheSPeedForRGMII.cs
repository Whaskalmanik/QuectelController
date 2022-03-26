using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class SetTheSPeedForRGMII : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Set the Speed for RGMII";

        public override string Description => "This command configures the speed for RGMII.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringListParameter("speed","String type. RGMII speed.",new Dictionary<string, object> {
                { "Auto negotiation speed.", "0M" },
                { "10 Mbps Ethernet", "10M" },
                { "100 Mbps Ethernet", "100M" },
                { "1000 Mbps Ethernet", "1000M" },
            },true),
        };

        protected override string RawCommand => "AT+QETH";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"speed\"," + CreateParametersString(commandParameters);
        }
    }
}
