using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class DisplayPINRemainderCounter : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Display PIN Remainder Counter";

        public override string Description => "This command queries the number of attempts left to enter the password of (U)SIM PIN/PUK.";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringListParameter("facility","String type.",new Dictionary<string, object> {
                { "(U)SIM PIN","SC"  },
                { "(U)SIM PIN2","P2" },
            },false),
        };

        protected override string RawCommand => "AT+QPINC";
    }
}
