using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class ObtaintheLatestTimeSynchronizedthroughNetwork : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Obtain the Latest Time Synchronized through Network";

        public override string Description => "The Execution Command returns the latest time that has been synchronized through network.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("mode","Integer type. Query network time mode.",new Dictionary<string, object> {
               { "Query the latest time that has been synchronized through network", 0 },
               { "Query the current GMT time calculated from the latest time that has been synchronized through network", 1 },
               { "uery the current LOCAL time calculated from the latest time that has been synchronized through network ", 2},
            }, false),
        };
        
        protected override string RawCommand => "AT+QLTS";
    }
}
