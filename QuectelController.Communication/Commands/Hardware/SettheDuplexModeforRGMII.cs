using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class SettheDuplexModeforRGMII : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Set the Duplex Mode for RGMII";

        public override string Description => "This command sets the duplex mode for RGMII.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringListParameter("status","String type. RGMII duplex mode.",new Dictionary<string, object> {
                { "RGMII is working at full duplex mode.", "full" },
                { "RGMII is working at half duplex mode.", "half" },
            },true),
        };

        protected override string RawCommand => "AT+QETH";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"mode\"" + CreateParametersString(commandParameters);
        }
    }
}
