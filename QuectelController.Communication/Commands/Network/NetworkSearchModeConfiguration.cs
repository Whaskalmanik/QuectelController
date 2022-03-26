using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class NetworkSearchModeConfiguration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Network Search Mode Configuration";

        public override string Description => "This command specifies the network search mode";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringCommandParameter("mode_pref",
                @"String type. Use the colon as a separator to list the RATs to be configured. The
parameter format is: RAT1:RAT2:…RATN. The RATs supported by the module are as follows:
AUTO     WCDMA & LTE & 5G NR
WCDMA    WCDMA only
LTE      LTE only
NR5G     5G NR only",true)
        };

        protected override string RawCommand => "AT+QNWPREFCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"mode_pref\"," + CreateParametersString(commandParameters);
        }
    }
}
