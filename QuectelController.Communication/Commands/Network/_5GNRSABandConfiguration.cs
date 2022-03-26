using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class _5GNRSABandConfiguration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "5G NR SA Band Configuration";

        public override string Description => "This command specifies the preferred 5G NR SA bands to be searched by UE.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringCommandParameter("NR5G_band","String type. Use the colon as a separator to list the 5G NR bands to be configured. The parameter format is n1:n2:…:nx. The configurable 5G NR SA bands supported by the applicable modules for this command are: n1, n2, n3, n5, n7, n8, n12, n20, n25, n28, n38, n40, n41, n48, n66, n71, n77, n78, n79.",true)
        };

        protected override string RawCommand => "AT+QNWPREFCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"nr5g_band\"," + CreateParametersString(commandParameters);
        }
    }
}
