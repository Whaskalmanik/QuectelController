using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class ErrorMessageFormat : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Error Message Format";

        public override string Description => 
            @"This command disables or enables the use of final result code +CME ERROR: <err> as the indication of 
an error.When enabled, errors cause +CME ERROR: <err> final result code instead of ERROR";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("n"," Integer type. Whether to enable result code.",new Dictionary<string, object> {
                { "Disable result code and use ERROR instead.",0 },
                { "Enable result code and use numeric values.",1 },
                { "Enable result code and use verbose values.",2 }
            } ,false),
        };
        protected override string RawCommand => "AT+CMEE";
    }
}
