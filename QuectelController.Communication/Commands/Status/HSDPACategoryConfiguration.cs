using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class HSDPACategoryConfiguration : CommandBase
    {
        public override bool CanExecute => false;
        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "HSDPA Category Configuration";

        public override string Description => "This command specifies the HSDPA category.";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("cat","Integer type. HSDPA category",new Dictionary<string, object> {
                { "Category 6",6 },
                { "Category 8",8 },
                { "Category 10",10 },
                { "Category 12",12 },
                { "Category 14",14 },
                { "Category 18",18 },
                { "Category 20",20 },
                { "Category 24",24 },
            },true),
        };

        protected override string RawCommand => "AT+QCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"hsdpacat\"" + CreateParametersString(commandParameters);
        }
    }
}
