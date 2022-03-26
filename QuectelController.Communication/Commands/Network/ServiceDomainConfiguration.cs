using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class ServiceDomainConfiguration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Service Domain Configuration";

        public override string Description => "This command specifies the registered service domain.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("srv_domain","Integer type. Service domain of UE.",new Dictionary<string, object> {
                { "CS only", 0 },
                { "PS only", 1 },
                { "CS & PS", 2 },
            },true),
        };

        protected override string RawCommand => "AT+QNWPREFCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"srv_domain\"," + CreateParametersString(commandParameters);
        }
    }
}
