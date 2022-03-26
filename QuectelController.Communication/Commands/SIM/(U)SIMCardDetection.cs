using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    class U_SIMCardDetection : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "(U)SIM Card Detection";

        public override string Description => "This command enables (U)SIM card hot-swap function. (U)SIM card is detected by GPIO interrupt. The level of(U)SIM card detection pin should also be set when the(U)SIM card is inserted.";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("enable","Integer type. Enable or disable (U)SIM card detection.",new Dictionary<string, object> {
                { "Disable",0  },
                { "Enable",1 },
            },false),
            new IntegerListCommandParameter("insert_level","Integer type. The level of (U)SIM detection pin when a (U)SIM card is inserted.",new Dictionary<string, object> {
                { "Low level",0  },
                { "High level",1 },
            },false),
        };

        protected override string RawCommand => "AT+QSIMDET";
    }
}
