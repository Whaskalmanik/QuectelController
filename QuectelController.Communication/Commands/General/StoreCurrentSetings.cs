using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class StoreCurrentSetings : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Store Current Settings to User-defined Profile";

        public override string Description => 
            @"This command stores the current AT command settings to a user-defined profile in non-volatile memory.
The AT command settings are automatically restored from the user-defined profile during power-up or if ATZ is executed.";
        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("Value","Integer Type",new Dictionary<string, object> {
                { "Profile number to store current AT command settings",0 }
            } ,false)
        };

        protected override string RawCommand => "AT&W";
    }
}
