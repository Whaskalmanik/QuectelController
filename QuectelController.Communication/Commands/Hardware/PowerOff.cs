using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class PowerOff : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Power off";

        public override string Description => "This command powers off the MT. UE returns OK immediately when the command is executed. Then UE deactivates the network.After the deactivation is completed, UE outputs POWERED DOWN and enters into power-off state.The maximum time for unregistering network is 60 seconds.To avoid data loss, the power supply for the module cannot be disconnected before the URC POWERED DOWN is outputted.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("n","Integer type.",new Dictionary<string, object> {
                { "Immediate power-down", 0 },
                { "Normal power-down", 1 },
            },false),
        };

        protected override string RawCommand => "AT+QPOWD";
    }
}
