using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class EnableDisableSendingandReceivingATCommands : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Select Ethernet Driver to be Loaded";

        public override string Description => "This command selects the Ethernet driver to be loaded when the module starts up.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringListParameter("status","String type. Enable or disable sending and receiving AT commands via Ethernet port.",new Dictionary<string, object> {
                { "Enable sending and receiving AT commands via Ethernet port", "Enable" },
                { "Disable sending and receiving AT commands via Ethernet port", "Disable" },
            },true),
        };

        protected override string RawCommand => "AT+QETH";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"eth_at\"," + CreateParametersString(commandParameters);
        }
    }
}
