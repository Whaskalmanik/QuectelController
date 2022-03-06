using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class SetOutputLevelofAPorPMUGPIO : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Set Output Level of AP or PMU GPIO";

        public override string Description => "This command sets the AP or PMU GPIO output level.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("type","Integer type. Set up the AP or PMU.",new Dictionary<string, object> {
                { "AP", 0 },
                { "PMU", 1 },
            },false),
            new IntegerCommandParameter("gpio_num","Integer type. GPIO number",false),
            new IntegerListCommandParameter("value","Integer type. GPIO output level.",new Dictionary<string, object> {
                { "Low level", 0 },
                { "Hight level", 1 },
            },false),
        };

        protected override string RawCommand => "AT+QAGPIO";
    }
}
