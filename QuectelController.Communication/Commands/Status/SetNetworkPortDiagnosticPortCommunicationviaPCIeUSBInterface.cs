using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class SetNetworkPortDiagnosticPortCommunicationviaPCIeUSBInterface : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Set Network Port/Diagnostic Port Communication via PCIe/USB Interface";

        public override string Description => "This command sets the network port/diagnostic port communication via USB/PCIe interface.";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("network","Integer type.",new Dictionary<string, object> {
                { "Set the network port communication via USB interface.",0 },
                { "Set the network port communication via PCIe interface.",1 },
            },true),
            new IntegerListCommandParameter("diag","Integer type.",new Dictionary<string, object> {
                { "Set the diagnostic port communication via USB interface.",0},
            },true),
        };

        protected override string RawCommand => "AT+QCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"data_interface\"" + CreateParametersString(commandParameters);
        }
    }
}
