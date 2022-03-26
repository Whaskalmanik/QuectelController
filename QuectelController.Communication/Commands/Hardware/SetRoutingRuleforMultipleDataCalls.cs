using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class SetRoutingRuleforMultipleDataCalls : CommandBase
    {
        public override bool CanExecute => false;
        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Set Routing Rule for Multiple Data Calls";

        public override string Description => "This command sets the routing rules for multiple data calls.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringListParameter("option","String type. Operation type.",new Dictionary<string, object> {
                { "Add routing rule", "add" },
                { "Delete routing rule", "del" },
            },true),
            new IntegerListCommandParameter("IP_version","Integer type. IP version.",new Dictionary<string, object> {
                { "IPv4", 4 },
                { "IPv6", 6 },
            },true),
            new StringCommandParameter("dest_ip_addr","String type. Destination IP address.",true),
            new IntegerCommandParameter("profileID","Integer type. RGMII data call profile ID.",true),
        };

        protected override string RawCommand => "AT+QETH";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"routing\"," + CreateParametersString(commandParameters);
        }
    }
}
