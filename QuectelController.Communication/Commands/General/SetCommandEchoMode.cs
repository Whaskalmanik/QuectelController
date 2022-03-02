using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class SetCommandEchoMode : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Set Command Echo Mode";

        public override string Description => "This command controls whether TA echoes characters received from TE or not during AT command mode.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("Value","Integer Type",new Dictionary<string, object> {
                { "OFF",0 },
                { "ON",1}
            } ,false)
        };

        protected override string RawCommand => "ATE";
    }
}
