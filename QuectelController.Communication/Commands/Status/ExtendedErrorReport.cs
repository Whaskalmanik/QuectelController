using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class ExtendedErrorReport : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Extended Error Report";

        public override string Description => 
            @"This command queries an extended error and report the cause of the last failed operation, such as:
-The failure to release a call
-The failure to set up a call (both mobile originated or terminated)
-The failure to modify a call by using supplementary services
-The failure to activate, register, query, deactivate or deregister a supplementary service
The release cause <text> is a text to describe the cause information given by the network.";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+CEER";
    }
}
