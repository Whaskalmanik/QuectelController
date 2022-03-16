using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class SetPauseBeforeBlindDialing : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Pause Before Blind Dialing";

        public override string Description => "This command is implemented for compatibility reasons only, and has no effect.";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter("n","Integer type. 0–2–10 Number of seconds to wait before blind dialing",false),
        };

        protected override string RawCommand => "ATS6";
    }
}
