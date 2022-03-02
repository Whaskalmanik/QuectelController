using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class SetCommandLineTerminationCharacter : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Command Line Termination Character";

        public override string Description => 
            @"This command determines the character recognized by TA to terminate an incoming command line. It is 
also generated for result codes and information text, along with character value set via ATS4";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter ("n","Integer type. Command line termination character. Range: 0–127. Default: 13",false)
        };

        protected override string RawCommand => "ATS3";
    }
}
