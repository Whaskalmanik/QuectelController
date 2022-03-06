using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class QueryandConfigureAudioTuningProcess : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Query and Configure Audio Tuning Process";

        public override string Description => "Multipurpose command";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+QAUDCFG";
    }
}
