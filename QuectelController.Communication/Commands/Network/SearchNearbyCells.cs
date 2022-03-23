using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class SearchNearbyCells : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Search Nearby Cells";

        public override string Description => "This command searches nearby LTE cells and 5G NR cells.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("mode","Integer type. Cell searching mode", new Dictionary<string,object> {
                { "Search only for LTE cells.",1 },
                { "Search only for 5G NR cells.",2 },
                { "Search LTE cells and 5G NR cells at the same time.",3 }
            },false),
            new IntegerListCommandParameter("ext","Integer type. Hide or show the extension parameter options for <cellID>, <TAC>,<bandwidth> and <band>.", new Dictionary<string,object>{
                { "Hide extension parameters.",0 },
                { "Show extension parameters.",1 },
            },true),
        };

        protected override string RawCommand => "AT+QSCAN";
    }
}
