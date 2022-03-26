using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class CloseLogicalChannel : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Close Logical Channel";

        public override string Description => "This command asks the ME to close a communication session with the active UICC. The ME shall close the previously opened logical channel.The TE will no longer be able to send commands on this logical channel. The UICC closes the logical channel when receiving this command.";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("sessionid","Integer type. A session ID to be used in order to target a specific application on the smart card (e.g. (U)SIM, WIM, ISIM) using logical channels mechanism.",false),
        };

        protected override string RawCommand => "AT+CCHC";
    }
}
