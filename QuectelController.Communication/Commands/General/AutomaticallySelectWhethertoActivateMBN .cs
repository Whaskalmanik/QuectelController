using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class AutomaticallySelectWhethertoActivateMBNFile : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Automatically Select Whether to Activate MBN File";

        public override string Description => "This command automatically selects whether to activate MBN file via (U)SIM card.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("Enable","Enable/disable to automatically activate MBN files.",new Dictionary<string, object> {
                { "Disabled",0 },
                { "Enable",1 },
            },true),
        };

        protected override string RawCommand => "AT+QMBNCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"AutoSel\"" + CreateParametersString(commandParameters);
        }
    }
}
