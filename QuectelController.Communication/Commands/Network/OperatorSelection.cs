using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class OperatorSelection : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Operator Selection";

        public override string Description =>
            @"This command returns the current operators and their status, and allows automatic or manual network selection.
The Test Command returns a set of five parameters, each representing an operator presenting in the
network. Any of the formats may be unavailable and should then be an empty field. The list of operators
shall be in the order of: home network, networks referenced in (U) SIM and other networks.
The Read Command returns the current mode and the currently selected operator. If no operator is 
selected, <format>, <oper> and<AcT> are omitted.
The Write Command forces an attempt to select and register the GSM/UMTS/EPS/5G network operator. 
If the selected operator is not available, no other operator shall be selected (except<mode>=4). The
format of selected operator name shall apply to further Read Commands (AT+COPS?).";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters { get; } = new ICommandParameter[]
        {
           new IntegerListCommandParameter("mode", "Integer type", new Dictionary<string, object> {
               { "Automatic. Operator selection (<oper> field is ignored).", 0 },
               { "Manual operator selection (<oper> field shall be present and <AcT> optionally)", 1 },
               { "Deregister from network", 2 },
               { "Set only <format> (for AT+COPS? Read Command), and do not attempt registration/deregistration (<oper> and <AcT> fields are ignored). This value is invalid in the response of Read Command.", 3 },
               { "Manual/automatic selection. <oper> field shall be presented. If manual selection fails, automatic mode (<mode>=0) will be entered", 4 },
           }, false),
           new IntegerListCommandParameter("format", "Integer type", new Dictionary<string, object> {
               { "Long format alphanumeric <oper> which can be up to 16 characters long", 0 },
               { "Short format alphanumeric <oper>", 1 },
               { "Numeric <oper>. GSM location area identification number", 2 },
           }, true),
           new StringCommandParameter("Oper","String type. Operator in format as per <format>.",true),
           new IntegerListCommandParameter("AcT", "Integer type", new Dictionary<string, object> {
               { "UTRAN", 2 },
               { "E-UTRAN", 7 },
               { "E-UTRAN connected to a 5GCN", 10 },
               { "NR connected to 5GCN", 11 },
               { "NG-RAN", 12 },
               { "E-UTRAN-NR dual connectivity", 13 },
           }, true),
        };

        protected override string RawCommand => "AT+COPS";
    }
}
