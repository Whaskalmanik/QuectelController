using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class SettheTimetoWaitforCommaDialModifier : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set the Time to Wait for Comma Dial Modifier";

        public override string Description => "This command is implemented for compatibility reasons only, and has no effect.";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter("n","Integer type. 0 No pause when comma encountered in dial string 1–2–255 Number of seconds to wait for comma dial modifier",false),
        };

        protected override string RawCommand => "ATS8";
    }
}
