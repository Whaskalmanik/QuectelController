using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class OpenLogicalChannel : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Open Logical Channel";

        public override string Description => "This command opens a logical channel. <sessionid> is to be used when you send commands with restricted UICC logical channel access AT+CRLA or generic UICC logical channel access AT+CGLA.";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringCommandParameter("dfname","All selectable applications in the UICC are referenced by a DF name coded on 1 to 16 bytes.",false),
        };

        protected override string RawCommand => "AT+CCHO";
    }
}
