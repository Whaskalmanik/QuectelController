using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class SetUplinkGainsofMicrophone : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Uplink Gains of Microphone";

        public override string Description => "This command sets the uplink gains of microphone.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("txgain","Integer type. Uplink codec gain. Range: 0–65535. The default value may be different indifferent audio modes.",false),
            new IntegerCommandParameter("txdgain","Integer type. Uplink digital gain. Range: 0–65535. The default value may be different in different audio modes.",true),
        };

        protected override string RawCommand => "AT+QMIC";
    }
}
