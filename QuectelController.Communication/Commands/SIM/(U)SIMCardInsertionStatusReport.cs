using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    class _U_SIMCardInsertionStatusReport : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "(U)SIM Card Insertion Status Report";

        public override string Description => "This command queries (U)SIM card insertion status or determines whether (U)SIM card insertion status report is enabled.";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("enable","Integer type. Enable or disable (U)SIM inserted status report. If it is enabled, the URC +QSIMSTAT: <enable>,<inserted_status> is reported when (U)SIM card isinserted or removed.",new Dictionary<string, object> {
                { "Disable",0  },
                { "Enable",1 },
            },false),
        };

        protected override string RawCommand => "AT+QSIMSTAT";
    }
}
