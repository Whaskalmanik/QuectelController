using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class Switch_U_SIMSlot : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Switch (U)SIM Slot";

        public override string Description => "This command queries the slot currently used by the (U)SIM and configure which to use. ";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("slot ","Integer type. Physical (U)SIM slot.",new Dictionary<string, object> {
                { "(U)SIM slot 1",1 },
                { "(U)SIM slot 2",2 },
            },false),
        };

        protected override string RawCommand => "AT+QUIMSLOT";
    }
}
