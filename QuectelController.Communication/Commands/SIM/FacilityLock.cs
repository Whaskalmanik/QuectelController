using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class FacilityLock : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Facility Lock";

        public override string Description => "This command locks/unlocks or interrogates an MT or a network facility <fac>. Password is normally needed to do such actions.When querying the status of network service (<mode>=2) the response line for ‘not active’ case (<status>=0) should be returned only if service is not active for any<class>.";

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
                { "(U)SIM card or active application in the UICC (GSM or (U)SIM) fixed dialing memory feature","FD" },
                { "Lock Phone to the very first inserted (U)SIM/UICC card","PF" },
                { "Network Personalization","PN" },
                { "Network Subset Personalization","PU" },
                { "Service Provider Personalization","PP" },
                { "Corporate Personalization","PC" },
            },false),
           new IntegerListCommandParameter("mode","Integer type",new Dictionary<string, object> {
                { "Unlock",0 },
                { "Lock",1 },
                { "Query status",2 },
            },false),
           new StringCommandParameter("password","String type, Password",true),
           new IntegerListCommandParameter("class","Integer type",new Dictionary<string, object> {
                { "Voice",1 },
                { "Data",2 },
                { "FAX",4 },
                { "All telephony except SMS",7 },
                { "Short message service",8 },
                { "Data circuit synchronization",16 },
                { "Data circuit asynchronization",32 },
            },true),
        };
        protected override string RawCommand => "AT+CLCK";
    }
}
