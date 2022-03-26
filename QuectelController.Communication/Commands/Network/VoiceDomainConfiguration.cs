using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class VoiceDomainConfiguration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Voice Domain Configuration";

        public override string Description => "This command specifies the voice domain of UE.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("voice_domain","Integer type. Service domain of UE.",new Dictionary<string, object> {
                { "CS voice only", 0 },
                { "IMS PS voice only", 1 },
                { "CS voice preferred", 2 },
                { "IMS voice preferred", 2 },
            },true),
        };

        protected override string RawCommand => "AT+QNWPREFCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"voice_domain\"," + CreateParametersString(commandParameters);
        }
    }
}
