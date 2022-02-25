using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Phonebook
{
    public class SubscriberNumber : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Subscriber Number";

        public override string Description => "This command gets the subscribers’ own number(s) from the (U)SIM.";

        public override CommandCategory Category => CommandCategory.Phonebook;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+CNUM";
    }
}
