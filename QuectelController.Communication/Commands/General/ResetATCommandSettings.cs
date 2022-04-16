using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class ResetATCommandSettings : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Reset AT Command Settings to Factory Settings";

        public override string Description => "This command resets AT command settings to the default values specified by the manufacturer.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("Value","Integer Type",new Dictionary<string, object> {
                { "Reset all AT command settings to factory setting.",0 }
            } ,false)
        };

        protected override string RawCommand => "AT&F0";
    }
}
