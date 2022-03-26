using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class UEUsageSettingConfiguration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "UE Usage Setting Configuration";

        public override string Description => "This command specifies the usage setting of UE.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("setting","Integer type. Roaming preference of UE.",new Dictionary<string, object> {
                { "Voice centric", 0 },
                { "Data centric", 1 },
            },true),
        };

        protected override string RawCommand => "AT+QNWPREFCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"ue_usage_setting\"," + CreateParametersString(commandParameters);
        }
    }
}
