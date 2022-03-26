using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class Disable5GNR : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Disable 5G NR";

        public override string Description => "This command disables 5G NR.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("disable_mode","Integer type. Disable 5G NR SA/NSA.",new Dictionary<string, object> {
                { "Neither is disabled", 0 },
                { "Disable SA", 1 },
                { "Disable NSA", 2 },
            },true),
        };

        protected override string RawCommand => "AT+QNWPREFCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"nr5g_disable_mode\"," + CreateParametersString(commandParameters);
        }
    }
}
