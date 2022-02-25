using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class DisplayCurrentConfiguration : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Display Current Configuration";

        public override string Description =>  @"This command displays the current configurations of some AT command parameters , even 
including the single-letter AT command parameters which are not readable.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT&V";
    }
}
