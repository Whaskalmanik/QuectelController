using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class _5GNRNSABandConfiguration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "5G NR NSA Band Configuration";

        public override string Description => "This command specifies the preferred 5G NR NSA bands to be searched by UE.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringCommandParameter("NSA_NR5G_band","String type. Use the colon as a separator to list the 5G NR NSA bands to be configured. The parameter format is n1:n2:…:nx.",true)
        };

        protected override string RawCommand => "AT+QNWPREFCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"nsa_nr5g_band\"," + CreateParametersString(commandParameters);
        }
    }
}
