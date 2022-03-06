using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class DTMFandToneGeneration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "DTMF and Tone Generation";

        public override string Description => "This command sends ASCII characters which cause MSC to transmit DTMF tones to a remote subscriber. This command can only be operated in a voice call.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringCommandParameter("DTMF_string","String type. ASCII characters in the set 0-9, #, *, A, B, C, D. The string should be enclosed in quotation marks (\"...\").When sending multiple tones at a time, the time interval of two tones <interval> can be specified by AT+VTD. The maximal length of the string is 31 bytes.",false),
            new IntegerCommandParameter("duration","Integer type. The duration of each tone in 10 ms with tolerance.",true),
        };

        protected override string RawCommand => "AT+VTS";  
    }
}
