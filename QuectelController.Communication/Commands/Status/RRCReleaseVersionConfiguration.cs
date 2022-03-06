using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class RRCReleaseVersionConfiguration : CommandBase
    {
        public override bool CanExecute => false;
        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "RRC Release Version Configuration";

        public override string Description => "This command specifies the RRC release version. ";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("rrcr","Integer type. RRC release version.",new Dictionary<string, object> {
                { "R99",0 },
                { "R5",1 },
                { "R6",2 },
                { "R7",3 },
                { "R8",4 },
                { "R9",5 },
            },true),
        };

        protected override string RawCommand => "AT+QCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"rcr\"" + CreateParametersString(commandParameters);
        }
    }
}
