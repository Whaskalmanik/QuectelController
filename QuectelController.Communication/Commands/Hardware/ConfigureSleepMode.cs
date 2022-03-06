using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class ConfigureSleepMode : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Configure Sleep Mode";

        public override string Description => "This command controls whether MT enters sleep mode. When entering into sleep mode is enabled, MT can directly enter sleep mode.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("n","Integer type. Enable or disable sleep mode",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable. It is controlled by DTR. DTR is pulled up by default.", 1 },
            },false),
            new IntegerListCommandParameter("saved","Integer type. Whether to save the configuration into NVM.",new Dictionary<string, object> {
                { "Not save", 0 },
                { "Save", 1 },
            },true),
        };

        protected override string RawCommand => "AT+QSCLK";
    }
}
