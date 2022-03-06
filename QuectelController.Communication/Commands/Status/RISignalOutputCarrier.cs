using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class RISignalOutputCarrier : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "RI Signal Output Carrier";

        public override string Description => "This command specifies the RI (ring indicator) signal output carrier.";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new StringListParameter("risignaltype","String type. RI signal output carrier",new Dictionary<string, object> {
                { "The ring indicator behaves on the port where URC is presented.","respective"},
                { "No matter which port URC is presented on, URC only causes the behavior of physical ring indicator","physical" },
            },true),
        };

        protected override string RawCommand => "AT+QCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"risignaltype\"" + CreateParametersString(commandParameters);
        }
    }
}
