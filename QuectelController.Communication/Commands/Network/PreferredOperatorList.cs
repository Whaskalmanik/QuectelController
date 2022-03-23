using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class PreferredOperatorList : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Preferred Operator List";

        public override string Description => "This command edits and queries the list of preferred operators.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("index","Integer type. The order number of operators in the (U)SIM preferred operator list.",false),
            new IntegerListCommandParameter("format","String type",new Dictionary<string, object> {
               { "Long format alphanumeric <oper>", 0 },
               { "Short format alphanumeric <oper>", 1 },
               { "Numeric <oper>", 2 },
            }, true),
            new StringCommandParameter("format","<format> indicates the format is alphanumeric or numeric (see AT+COPS)",false),
            new IntegerListCommandParameter("GSM","Integer type. GSM access technology.",new Dictionary<string, object> {
               { "Access technology is not selected", 0 },
               { "Access technology is selected", 1 },
            }, true),
            new IntegerListCommandParameter("GSM_compact","Integer type. GSM compact access technology",new Dictionary<string, object> {
               { "Access technology is not selected", 0 },
               { "Access technology is selected", 1 },
            }, true),
            new IntegerListCommandParameter("UTRAN","Integer type. UTRAN access technology.",new Dictionary<string, object> {
               { "Access technology is not selected", 0 },
               { "Access technology is selected", 1 },
            }, true),
            new IntegerListCommandParameter("E-UTRAN","Integer type. E-UTRAN access technology.",new Dictionary<string, object> {
               { "Access technology is not selected", 0 },
               { "Access technology is selected", 1 },
            }, true),
            new IntegerListCommandParameter("NG-RAN","Integer type. NG-RAN access technology",new Dictionary<string, object> {
               { "Access technology is not selected", 0 },
               { "Access technology is selected", 1 },
            }, true),
        };

        protected override string RawCommand => "AT+CPOL";
    }
}
