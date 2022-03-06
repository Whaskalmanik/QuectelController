using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class ConfigureI2S : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Configure I2S";

        public override string Description => "This command configures master-slave mode and sampling rate.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("mode","Integer type",new Dictionary<string, object> {
                { "Master mode", 0 },
                { "Slave mode", 1 },
            },true),
            new IntegerListCommandParameter("sample_rate","Integer type. Sampling rate.",new Dictionary<string, object> {
                { "8000 Hz", 0 },
                { "16000 Hz", 1 },
                { "48000 Hz", 2 },
            },true),
        };

        protected override string RawCommand => "AT+QAUDCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"i2s/cfg\"" + CreateParametersString(commandParameters);
        }
    }
}
