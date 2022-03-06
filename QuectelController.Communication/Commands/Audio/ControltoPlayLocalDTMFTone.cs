using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class ControltoPlayLocalDTMFTone : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Control to Play Local DTMF Tone";

        public override string Description => "The command plays a local DTMF tone and stops playing the DTMF tone.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("n","Integer type. Indicate every DTMF’s play time and mute time. Range: 1–1000. Unit: 1/100 second when <y> is set to 1, or 1/10 second when <y> is not set", false),
            new StringCommandParameter("DTMF_string","String type. DTMF tone string. Maximum length: 20 characters. DTMF tone string includes 0-9,*,#,A-D", false),
            new IntegerCommandParameter("y","Integer type. If the parameter is omitted, it means the unit of <n> is 1/10 second", true),
        };

        protected override string RawCommand => "AT+QLDTMF";
    }
}
