using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class ControlAudioLoopToneTestFunction : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Control Audio Loop Tone Test Function of Analog Phone and Dial Tone";

        public override string Description => "This command configures the audio loop tone test of an analog phone. Compared to codec scenarios, this command controls audio loop tone test function of an analog telephone and automaticallyenables/disables dial tone.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("enable","Integer type. Whether to enable audio loop tone test function of an analog telephone and automatically enable/disable dial tone",new Dictionary<string, object> {
                { "Disable audio loop tone test function of an analog telephone and automatically enable dial tone", 0 },
                { "Enable audio loop tone test function of an analog telephone and automatically disable dial tone", 1 },
            },true),
        };

        protected override string RawCommand => "AT+QAUDCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"slic/AudLoop\"" + CreateParametersString(commandParameters);
        }
    }
}
