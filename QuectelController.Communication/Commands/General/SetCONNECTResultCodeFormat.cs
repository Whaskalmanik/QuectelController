using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class SetCONNECTResultCodeFormat : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Set CONNECT Result Code Format and Monitor Call Progress";

        public override string Description =>
            @"This command determines whether TA transmits particular result codes to TE or not. It also controls 
whether TA detects the presence of a dial tone when it begins dialing and the engaged tone(busy signal) or not. ";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("Value","Integer Type",new Dictionary<string, object> {
                { "Only CONNECT result code returned, dial tone and busy detection are both disabled.",0 },
                { "Only CONNECT<text> result code returned, dial tone and busy detection are both disabled.",1 },
                { "CONNECT<text> result code returned, dial tone detection is enabled, and busy detection is disabled.",2 },
                { "CONNECT<text> result code returned, dial tone detection is disabled, and busy detection is enabled.",3 },
                { "CONNECT<text> result code returned, and dial tone and busy detection are both enabled",4 }
            } ,false)
        };

        protected override string RawCommand => "ATX";
    }
}
