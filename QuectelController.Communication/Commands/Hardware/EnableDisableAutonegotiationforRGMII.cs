using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class EnableDisableAutonegotiationforRGMII : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Enable/Disable Auto-negotiation for RGMII";

        public override string Description => "This command enables or disables the auto-negotiation for RGMII.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringListParameter("status","String type. Enable or disable RGMII auto-negotiation.",new Dictionary<string, object> {
                { "Enable auto-negotiation for RGMII.", "on" },
                { "Disable auto-negotiation for RGMII.", "off" },
            },true),
        };

        protected override string RawCommand => "AT+QETH";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"an\"," + CreateParametersString(commandParameters);
        }
    }
}
