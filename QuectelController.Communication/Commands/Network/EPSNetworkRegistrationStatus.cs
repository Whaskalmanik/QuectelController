using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class EPSNetworkRegistrationStatus : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "EPS Network Registration Status";

        public override string Description => 
            @"This command queries the network registration status and controls the presentation of an unsolicited 
result code +CEREG: <stat> when <n>=1 and there is a change in the MT’s EPS network registration 
status in E-UTRAN, or unsolicited result code +CEREG: <stat>[,[<tac>],[<ci>],[<AcT>]] when <n>=2 
and there is a change of the network cell in E-UTRAN.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters { get; } = new ICommandParameter[]
        {
           new IntegerListCommandParameter("n", "Integer type", new Dictionary<string, object> {
               { "Disable network registration unsolicited result code", 0 },
               { "Enable network registration unsolicited result code +CEREG:<stat>", 1 },
               { "Enable network registration and location information unsolicited result code +CEREG: <stat>[,<lac>,<ci>[,<AcT>]]", 2 },
           }, true)
        };

        protected override string RawCommand => "AT+CEREG";
    }
}
