using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class SetTimetoWaitforConnectionCompletion : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Time to Wait for Connection Completion";

        public override string Description => 
            @"This command specifies the duration (unit: second) to wait for the connection completion in case of 
answering or originating a call.If no connection is established during the time, MT will be disconnected
from the line.";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter("n","Integer type.0 Disabled 1–255 Duration of seconds to wait for connection completion",false),
        };

        protected override string RawCommand => "ATS7";
    }
}
