using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class HSPUACategoryConfiguration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "HSUPA Category Configuration";

        public override string Description => "This command specifies the HSUPA category.";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("cat","Integer type. HSUPA category.",new Dictionary<string, object> {
                { "Category 5",5 },
                { "Category 6",6 },
                { "Category 7",7 },
                { "Category 8",8 },
            },true),
        };

        protected override string RawCommand => "AT+QCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"hsupacat\"," + CreateParametersString(commandParameters);
        }
    }
}
