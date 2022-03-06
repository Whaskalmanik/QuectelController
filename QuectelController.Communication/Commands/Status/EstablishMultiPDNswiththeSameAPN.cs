using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class EstablishMultiPDNswiththeSameAPN : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Establish Multi PDNs with the Same APN";

        public override string Description => "This command allows/refuses establishing multi PDNs with the same APN profile. ";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("enabled","Integer type.",new Dictionary<string, object> {
                { "Refuse to establish multi PDNs with the same APN profile",0 },
                { "Allow to establish multi PDNs with the same APN profile",1 },
            },true),
        };

        protected override string RawCommand => "AT+QCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"pdp/duplicatechk\"" + CreateParametersString(commandParameters);
        }
    }
}
