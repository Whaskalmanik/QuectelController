using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class SetToneDuration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Tone Duration";

        public override string Description => "This command sets the duration of DTMF tones. It can also set time interval of two tones when sending multiple tones at a time.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("duration","Integer type. The duration tone in 1/10 seconds with tolerance. Range: 0–255; Default: 3. If the duration is less than the minimum time specified by the network,the actual duration will be network specified time.",false),
            new IntegerCommandParameter("interval","Integer type. The time interval of two tones when sending multiple tones at a time by AT+VTS. Range: 0–255; Default: 0. Unit: 0.1 second.",true),
        };

        protected override string RawCommand => "AT+VTD";
    }
}
