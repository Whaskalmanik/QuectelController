using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class SelectTypeofAddress : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Select Type of Address";

        public override string Description => "This command selects the type of number for further dialing commands ATD according to 3GPP Specifications.The Test Command returns values supported a compound value.";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("type","Integer type. Current address type setting",new Dictionary<string, object> {
                { "Unknown type", 129 },
                { "International type (contains the character +)", 145 },
            },true),
        };

        protected override string RawCommand => "AT+CSTA";
    }
}
