using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class EnableDisableSLIC : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Enable/Disable SLIC";

        public override string Description => "This command enables or disables the SLIC.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("enable","Integer type. Enable or disable SLIC.",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable", 1 },
            },false),
            new IntegerListCommandParameter("SLIC_type","Integer type. Set SLIC platform type. It is valid only when <enable>=1.",new Dictionary<string, object> {
                { "Reserved", 0 },
                { "E9641 (Currently not supported)", 1 },
                { "SI32185", 2 },
                { "LE9643", 3 },
            },false),
            new IntegerListCommandParameter("region","Integer type. Configure the region of SI32185. It is valid only when <SLIC_type> is 2.",new Dictionary<string, object> {
                { "China", 0 },
                { "France", 1 },
            },true),
        };

        protected override string RawCommand => "AT+QSLIC";
    }
}
