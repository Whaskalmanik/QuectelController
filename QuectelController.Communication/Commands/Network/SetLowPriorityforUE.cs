using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class SetLowPriorityforUE : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Set Low Priority for UE";

        public override string Description => "This command sets low priority for UE.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("enable","Integer type. Enable/Disable low priority for UE.",new Dictionary<string, object> {
               { "Disable", 0 },
               { "Enable", 1 },
            }, true),
        };

        protected override string RawCommand => "AT+QNWCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"lapi\"," + CreateParametersString(commandParameters);
        }
    }
}
