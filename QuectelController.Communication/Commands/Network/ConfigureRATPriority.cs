using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class ConfigureRATPriority : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Configure RAT Priority";

        public override string Description => "This command configures the RAT acquisition order.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringCommandParameter("rat_order",
                @"String type. Use the colon as a separator to specify RAT priority. The parameter
format is: RAT1:RAT2:…RATN. The RATs supported by the module are as follows:
WCDMA    WCDMA
LTE      LTE
NR5G     5G NR",true),
        };

        protected override string RawCommand => "AT+QNWPREFCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"rat_acq_order\"," + CreateParametersString(commandParameters);
        }
    }
}
