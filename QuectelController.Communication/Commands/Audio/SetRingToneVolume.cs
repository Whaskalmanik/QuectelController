using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class SetRingToneVolume : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Ring Tone Volume";

        public override string Description => "This command sets the volume of ring tone.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter("volume","Integer type. Indicate the configured volume of ring tone. Range: 0–7. Default: 3.",false),
        };

        protected override string RawCommand => "AT+CRSL";
    }
}
