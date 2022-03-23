using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class TimeZoneReporting : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Time Zone Reporting";

        public override string Description => "This command controls the reporting of time zone change event. If reporting is enabled, MT returns the unsolicited result code +CTZV: <tz> or +CTZE: <tz>,<dst>,<time> whenever the time zone is changed";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("reporting","Integer type. Indicate the mode of time zone reporting.",new Dictionary<string, object> {
               { "Disable time zone reporting of changed event", 0 },
               { "Enable time zone reporting of changed event by unsolicited result code +CTZV: <tz>", 1 },
               { "Enable extended time zone reporting by unsolicited result code +CTZE: <tz>,<dst>,<time>", 2},
            }, false),
        };

        protected override string RawCommand => "AT+CTZR";
    }
}
