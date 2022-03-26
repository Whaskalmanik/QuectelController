using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class EnableDisableRGMII : CommandBase
    {
        public override bool CanExecute => false;
        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Enable/Disable RGMII";

        public override string Description => "This command enables/disables RGMII and queries the current configuration.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringListParameter("status","String type. Enable or disable RGMII.",new Dictionary<string, object> {
                { "Enable RGMII", "ENABLE" },
                { "Disable RGMII", "DISABLE" },
            },true),
            new IntegerListCommandParameter("voltage","Integer type. RGMII voltage.",new Dictionary<string, object> {
                { "1.8 V", 0 },
                { "2.5 V", 1 },
            },true),
            new IntegerListCommandParameter("mode","Integer type. RGMII mode.",new Dictionary<string, object> {
                { "Empty mode (No any data call)", -1 },
                { "Call RGMII with COMMON-RGMII mode", 0 },
                { "Call RGMII with IP Passthrough-RGMII mode", 1 },
            },true),
            new IntegerCommandParameter("profileID","Integer type. Profile ID of RGMII data call. Range: 1–8. It should be used together with AT+CGDCONT.",true),
        };

        protected override string RawCommand => "AT+QETH";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"rgmii\"," + CreateParametersString(commandParameters);
        }
    }
}
