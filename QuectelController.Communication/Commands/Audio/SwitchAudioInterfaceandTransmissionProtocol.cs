using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class SwitchAudioInterfaceandTransmissionProtocol : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Switch Audio Interface and Transmission Protocol";

        public override string Description => "This command switches the audio interface and transmission protocol.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {  
            new IntegerListCommandParameter("audio_interface","Integer type. The audio interface to be enabled.",new Dictionary<string, object> {
                { "PCM protocol", 0 },
                { "I2S protocol", 1 },
            },true),
            new IntegerListCommandParameter("index","Integer type. Audio interface channel.",new Dictionary<string, object> {
                { "Enable the first audio interface", 1 },
                { "Enable the second audio interface", 2 },
            },true),
        };

        protected override string RawCommand => "AT+QAUDCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"aif\"" + CreateParametersString(commandParameters);
        }
    }
}
