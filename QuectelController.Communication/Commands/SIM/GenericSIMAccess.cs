using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class GenericSIMAccess : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Generic (U)SIM Access";

        public override string Description => "This command allows a direct control of the(U)SIM that is inserted in the currently selected card slot by adistant application on TE. TE should then keep the processing of (U)SIM information within the frame specified by GSM/UMTS.";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("length","Integer type. String length of <command> or <response>.",false),
            new StringCommandParameter("command","String type in hexadecimal format.",false)
        };

        protected override string RawCommand => "AT+CSIM";
    }
}
