using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class RestoreAllATCommandSettings : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Restore All AT Command Settings from User-defined Profile";

        public override string Description => 
            @"This command first resets the AT command settings to their manufacturer defaults, which is similar to 
AT&F.Afterwards the AT command settings are restored from the user-defined profile in the non-volatile memory, if they have been stored with AT&W before";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("Value","Integer Type",new Dictionary<string, object> {
                { "Reset to profile number 0.",0 }
            } ,false)
        };

        protected override string RawCommand => "ATZ";
    }
}
