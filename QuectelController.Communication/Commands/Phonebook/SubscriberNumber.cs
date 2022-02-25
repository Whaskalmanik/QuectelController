using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Phonebook
{
    public class SubscriberNumber : CommandBase
    {
        public override string Name => "Subscriber Number";

        public override string Description => "This command gets the subscribers’ own number(s) from the (U)SIM.";

        public override CommandCategory Category => CommandCategory.Phonebook;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => throw new NotImplementedException();

        protected override string RawCommand => throw new NotImplementedException();
    }
}
