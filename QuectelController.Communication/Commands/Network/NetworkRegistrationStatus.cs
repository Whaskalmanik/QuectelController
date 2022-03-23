using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class NetworkRegistrationStatus : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Network Registration Status";

        public override string Description => 
            @"The Read Command returns the network registration status and returns the status of result code 
presentation and an integer <stat> which shows whether the network has currently indicated the 
registration of MT. Location information parameters <lac> and <ci> are returned only when <n>=2 and 
MT is registered on the network.
The Write Command sets whether to present URC or not and controls the presentation of an unsolicited 
result code +CREG: <stat> when <n>=1 and there is a change in the MT network registration status.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters { get; } = new ICommandParameter[]
        {
           new IntegerListCommandParameter("n", "Integer type", new Dictionary<string, object> {
               { "Disable network registration unsolicited result code", 0 },
               { "Enable network registration unsolicited result code: +CREG: <stat>", 1 },
               { "Enable network registration unsolicited result code with location information:+CREG: <stat>[,<lac>,<ci>[,<AcT>]]", 2 },
           }, true)
        };

        protected override string RawCommand => "AT+CREG";
    }
}
