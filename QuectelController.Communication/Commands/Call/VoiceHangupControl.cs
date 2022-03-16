using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class VoiceHangupControl : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Voice Hang up Control";

        public override string Description => "This command controls whether ATH can be used to disconnect the voice call.";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("mode","Integer type.",new Dictionary<string, object> {
                { "ATH can be used to disconnect the voice call", 0 },
                { "ATH is ignored with the response OK returned only", 1 },
            },false),
        };

        protected override string RawCommand => "AT+CVHU";
    }
}
