using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class ConfigureEmergencyCallNumbers : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Configure Emergency Call Numbers";

        public override string Description => "This command queries, adds and deletes ECC phone numbers (emergency call numbers).";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("mode","Integer type. ECC number operations.",new Dictionary<string, object> {
                { "Query ECC numbers", 0 },
                { "Add ECC numbers with default category", 1 },
                { "Delete ECC numbers.", 2 },
                { "Reset the ECC number list.", 3 },
                { "Add an ECC number with specified category", 4 },
                { "Query all emergency call numbers and their categories.", 5 },
            },false),
            new IntegerListCommandParameter("type","Integer type. ECC number type.",new Dictionary<string, object> {
                { "ECC numbers stored in the module without (U)SIM card", 0 },
                { "ECC numbers stored in the module with (U)SIM card", 1 },
                { "ECC numbers from the network", 2 },
                { " ECC numbers from the (U)SIM card", 3 },
            },true),
             new StringCommandParameter("eccnumN","String type. ECC numbers (e.g. 110, 119).",true),
             new IntegerListCommandParameter("category","Integer type. ECC number category.",new Dictionary<string, object> {
                { "Default", 0 },
                { "Police", 1 },
                { "Ambulance", 2 },
                { "Fire Brigade", 4 },
                { "Marine Guard", 8 },
                { "Mountain Rescue", 16 },
                { "manually initiated eCall", 32 },
                { "automatically initiated eCall", 64 },
            },true),
        };

        protected override string RawCommand => "AT+QECCNUM";
    }
}
