using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class SetUEFunctionality : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set UE Functionality";

        public override string Description => "This command controls the functionality level. It can also be used to reset the UE.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("fun","Integer Type",new Dictionary<string, object> {
                { "Minimum functionality",0 },
                { "Full functionality",1 },
                { "Disable both transmitting and receiving RF signals",4 }
            } ,false),
            new IntegerListCommandParameter("rst","Integer Type",new Dictionary<string, object> {
                { "Do not reset the UE before setting it to <fun> power level (Default value when <rst> is omitted.)",0 },
                { "Reset UE. The device is fully functional after the reset. This value is available only for <fun>=1.",1 }
            } ,true)
        };

        protected override string RawCommand => "AT+CFUN";
    }
}
