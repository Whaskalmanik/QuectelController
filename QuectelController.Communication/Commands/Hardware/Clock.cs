using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Hardware
{
    public class Clock : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Clock";

        public override string Description => "This command sets or queries the real time clock (RTC) of the MT. ";

        public override CommandCategory Category => CommandCategory.HardwareRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new StringCommandParameter("time","String type. The format is yy/MM/dd,hh:mm:ss±zz, indicating year (two last digits), month, day, hour, minutes, seconds and time zone (indicates the difference, expressed in quartersof an hour, between the local time and GMT; range: -48 to +56). E.g. May 6th, 1994, 22:10:00GMT+2 hours equals 94/05/06,22:10:00+08.",false),
        };

        protected override string RawCommand => "AT+CCLK";
    }
}
