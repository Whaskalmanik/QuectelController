using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class SelectEthernetDrivertobeLoaded : CommandBase
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
            new StringCommandParameter("eth_driver","String type. Ethernet driver name.",true),
            new IntegerListCommandParameter("status","Integer type. Whether to load the Ethernet driver specified by <eth_driver> when the module starts up.",new Dictionary<string, object> {
                { "Not load", 0 },
                { "Load", 1 },
            },true),
        };

        protected override string RawCommand => "AT+QETH";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"eth_driver\"," + CreateParametersString(commandParameters);
        }
    }
}
