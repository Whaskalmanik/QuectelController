using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class SetCommandLineEditingCharacter : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Command Line Editing Character";

        public override string Description =>
            @"This command determines the value of editing character used by TA to delete the immediately preceding 
character from the AT command line (i.e. equates to backspace key).";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter ("n","Integer type. Response editing character. Range: 0–127. Default: 8.",false)
        };

        protected override string RawCommand => "ATS5";
    }
}
