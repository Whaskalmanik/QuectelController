using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class ReadADCValue : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override string Name => "Read ADC Value";

        public override string Description => "This command reads the voltage value of ADC channel.";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("port","Integer type. Channel number of the ADC.",new Dictionary<string, object> {
                { "ADC channel 0", 0 },
                { "ADC channel 1", 1 },
            },false),
        };

        protected override string RawCommand => "AT+QADC";  
    }
}
