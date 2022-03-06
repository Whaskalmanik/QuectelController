using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class ChangePassword : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Change Password";

        public override string Description => "This command sets a new password for the facility lock function defined by AT+CLCK.";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
           new StringListParameter("fac","String type",new Dictionary<string, object> {
                { "(U)SIM/UICC asks password in MT power-up and when this lock command is issued","SC" },
                { "BAOC (Bar All Outgoing Calls)","AO" },
                { "BOIC (Bar Outgoing International Calls)","OI" },
                { "BOIC-exHC (Bar Outgoing International Calls except to Home Country)","OX" },
                { "BAIC (Bar All Incoming Calls)","AI" },
                { "BIC-Roam (Bar Incoming Calls when Roaming outside the home country)","IR" },
                { "All barring services","AB" },
                { "All outgoing barring services","AG" },
                { "All incoming barring services","AC" },
                { "(U)SIM PIN2","P2" },
            },false),
            new StringCommandParameter("oldpwd","String type. Password specified for the facility from the user interface or with command.",false),
            new StringCommandParameter("newpwd","String type. New password.",false),
        };

        protected override string RawCommand => "AT+CPWD";
    }
}
