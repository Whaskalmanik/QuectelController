using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class EnterPin : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Enter PIN";

        public override string Description => "This command sends to the MT a password which is necessary before it can be operated or querieswhether MT requires a password or not before it can be operated.The password may be (U) SIM PIN,(U) SIM PUK, PH-SIM PIN, etc";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new StringCommandParameter("pin","String type. Password. If the requested password was a PUK, such as (U)SIM PUK1, PH-FSIM PUK or another password, then <pin> must be followed by <new_pin>.",false),
            new StringCommandParameter("new_pin","String type. New password required if the requested code was a PUK",true),
        };

        protected override string RawCommand => "AT+CPIN";
    }
}
