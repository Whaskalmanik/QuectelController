using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class EnableDisableAudioLoopTest : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Enable/Disable Audio Loop Test";

        public override string Description => "This command enables/disables audio loop test.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("enable","Integer type. Enable or disable audio loop test.",new Dictionary<string, object> {
                { "Disable audio loop test",0 },
                { "Enable audio loop test",1 },
            },true),
        };

        protected override string RawCommand => "AT+QAUDLOOP";
    }
}
