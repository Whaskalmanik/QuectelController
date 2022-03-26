using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class QueryUserLayerDownlinkDataPathunderNSANetwork : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Query User Layer Downlink Data Path under NSA Network";

        public override string Description => "This command queries the user layer downlink data path under NSA network.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("enable","Integer type. Enable or disable query the user layer downlink data path under NSA.",new Dictionary<string, object> {
               { "Disable", 0 },
               { "Enable", 1 },
            }, true),
        };

        protected override string RawCommand => "AT+QNWCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"data_path\"," + CreateParametersString(commandParameters);
        }
    }
}
