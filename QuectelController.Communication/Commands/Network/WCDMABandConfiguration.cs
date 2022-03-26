using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    class WCDMABandConfiguration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "WCDMA Band Configuration";

        public override string Description => "This command specifies the preferred WCDMA bands to be searched by UE.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringCommandParameter("gw_band","String type. Use the colon as a separator to list the WCDMA Bands to be configured. The parameter format is B1:B2:…:BN.",true)
        };

        protected override string RawCommand => "AT+QNWPREFCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"dss_enable\"," + CreateParametersString(commandParameters);
        }
    }
}
