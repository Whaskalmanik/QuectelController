using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Supplementary_Service
{
    public class CallRelatedSupplementaryServices : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Call Related Supplementary Services";

        public override string Description => 
            @"This command allows the control of the following call related services: 
-A call can be temporarily disconnected from the MT but the connection is retained by the network; 
-Multiparty conversation(conference calls); 
-The served subscriber who has two calls(one held and the other either active or alerting) can connect the other parties and release the served subscriber’s own connection";

        public override CommandCategory Category => CommandCategory.SupplementaryServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter("n","Integer type. Values can be 0, 1X, 2, 2X, 3, 4 where (X = 1-7)",true),
        };

        protected override string RawCommand => "AT+CHLD";
    }
}
