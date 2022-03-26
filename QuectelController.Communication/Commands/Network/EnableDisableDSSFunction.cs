using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class EnableDisableDSSFunction : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Enable/Disable DSS Function";

        public override string Description => "This command enables or disables DSS Function.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("dss_enable","Integer type. Enable or disable DSS function.",new Dictionary<string, object> {
               { "Disable", 0 },
               { "Enable", 1 },
            }, true),
        };

        protected override string RawCommand => "AT+QNWCFG";
        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"dss_enable\"," + CreateParametersString(commandParameters);
        }
    }
}
