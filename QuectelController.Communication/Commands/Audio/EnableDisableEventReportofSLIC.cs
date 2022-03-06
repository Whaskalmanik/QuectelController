using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class EnableDisableEventReportofSLIC : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Enable/Disable Event Report of SLIC Analog Phone";

        public override string Description => "This command enables or disables the reporting of SLIC analog phone event. Currently only the events of DTMF, on-hook, off- hook and flash are supported.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("op","Integer type. Enable or disable the reporting of SLIC analog phone event.",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable", 1 },
            },true),
        };

        protected override string RawCommand => "AT+QAUDCFG";
        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"slic_IndRep\"" + CreateParametersString(commandParameters);
        }
    }
}
