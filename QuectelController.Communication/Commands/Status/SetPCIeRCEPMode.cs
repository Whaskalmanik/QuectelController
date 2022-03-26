using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class SetPCIeRCEPMode : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Set PCIe RC/EP Mode";

        public override string Description => "This command sets PCIe RC/EP mode.";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("mode","Integer type. Set PCIe RC or EP mode.",new Dictionary<string, object> {
                { "PCIe EP mode.",0 },
                { "PCIe RC mode.",1 },
            },true),
        };

        protected override string RawCommand => "AT+QCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"pcie/mode\"," + CreateParametersString(commandParameters);
        }
    }
}
