using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class SetDisconnectionDelayafterIndicatingtheAbsenceofDataCarrier : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Disconnection Delay after Indicating the Absence of Data Carrier";

        public override string Description => 
            @"This command determines the duration (unit: tenths of a second) during which the UE remains connected 
in absence of a data carrier. This parameter setting determines the amount of time (unit: tenths of a 
second) during which the MT will remain connected in absence of a data carrier. If the data carrier is once 
more detected before disconnection, the MT remains connected.
";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter("n","1–15–254 Duration of tenths of seconds to wait before disconnecting after UE has indicated the absence of received line signal",false),
        };

        protected override string RawCommand => "ATS10";
    }
}
