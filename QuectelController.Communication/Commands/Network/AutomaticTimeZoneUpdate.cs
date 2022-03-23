using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class AutomaticTimeZoneUpdate : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Automatic Time Zone Update";

        public override string Description => "This command enables/disables automatic time zone update via NITZ.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("onoff","Integer type. Indicates the mode of automatic time zone update.",new Dictionary<string, object> {
               { "Disable automatic time zone update via NITZ", 0 },
               { "Enable automatic time zone update via NITZ", 1 },
            }, false),
        };

        protected override string RawCommand => "AT+CTZU";
    }
}
