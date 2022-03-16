using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class SetNumberofRingsBeforeAutomaticAnswering : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Number of Rings Before Automatic Answering";

        public override string Description => "This command controls automatic answering mode for the incoming calls.";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter("n","Integer type. 0 Automatic answering is disabled 1-255. Enable automatic answering on the ring number specified",false),
        };

        protected override string RawCommand => "ATS0";
    }
}
