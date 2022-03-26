using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    class GetAverageDownlinkRateinDeltaTime : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Get Average Uplink Rate and Downlink Rate in Delta Time";

        public override string Description => "Get Average Uplink Rate and Downlink Rate in Delta Time";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("time_interval","Integer type. The time to calculate the average rate automatically. Range:1–60. Default value: 2. Unit: second.",true),
        };

        protected override string RawCommand => "AT+QNWCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"up/down\"," + CreateParametersString(commandParameters);
        }
    }
}
