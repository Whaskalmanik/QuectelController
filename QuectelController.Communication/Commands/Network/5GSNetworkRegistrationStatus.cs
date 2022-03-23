using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class _5GSNetworkRegistrationStatus : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "5GSNetworkRegistrationStatus";

        public override string Description =>  
            @"This command queries the network registration status and controls the presentation of URC +C5GREG: 
< stat > when < n >= 1 and there is a change in the MT’s network registration status in 5GS, or URC 
+C5GREG: <stat>[,[<tac>],[<ci>],[<AcT>],[<Allowed_NSSAI_length>],[<Allowed_NSSAI>]] when
<n>=2 and there is a change of the network cell in 5GS or the network provided an Allowed NSSAI.The
parameters<AcT>, <tac>, <ci>, <Allowed_NSSAI_length> and<Allowed_NSSAI> are provided only if 
available.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters { get; } = new ICommandParameter[]
        {
           new IntegerListCommandParameter("n", "Integer type", new Dictionary<string, object> {
               { "Disable network registration unsolicited result code", 0 },
               { "Enable network registration unsolicited result code + C5GREG:<stat>", 1 },
               { "Enable network registration and location information unsolicited result code +C5GREG: <stat>[,[<tac>],[<ci>],[<AcT>],[<Allowed_NSSAI_length>],[<Allowed_NSSAI>]]", 2 },
           }, true)
        };

        protected override string RawCommand => "AT+C5GREG";
    }
}
