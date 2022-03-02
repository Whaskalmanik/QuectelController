using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class SelectTECharacterSet : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Select TE Character Set";

        public override string Description => 
        @"This Write Command informs the MT which character set is used by the TE. This enables the MT to 
convert character strings correctly between TE and MT character sets";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new StringListParameter("chset","String type.",new Dictionary<string, object> {
                { "GSM default alphabet ","GSM" },
                { "International reference alphabet","IRA" },
                { "UCS2 alphabet","UCS2" }
            } ,false),
        };

        protected override string RawCommand => "AT+CSCS";
    }
}
