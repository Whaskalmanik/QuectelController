using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class LoudspeakerVolumeLevelSelection : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Loudspeaker Volume Level Selection";

        public override string Description => "This command selects the volume level of the internal loudspeaker of MT";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter("level","Integer type. Volume level with manufacturer specific range (Smallest value represents the lowest sound level). Range: 0–5; Default: 3.",false),
        };

        protected override string RawCommand => "AT+CLVL";
    }
}
