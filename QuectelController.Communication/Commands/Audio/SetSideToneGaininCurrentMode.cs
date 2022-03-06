using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class SetSideToneGaininCurrentMode : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Side Tone Gain in Current Mode";

        public override string Description => "This command sets the side tone gain value in current mode.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter("st_gain","Integer type. Indicate the configured side tone gain in current mode. Range: 0–65535. Default value may be different in different audio modes.",false),
        };

        protected override string RawCommand => "AT+QSIDET";
    }
}
