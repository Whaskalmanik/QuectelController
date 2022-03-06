using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Packet_Domain
{
    public class ActivateorDeactivatePDPContexts : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Activate or Deactivate PDP Contexts";

        public override string Description => 
            @"This command activates or deactivates the specified PDP context(s). After the command has been 
completed, the MT will remain in V.250 command state.If any PDP context is already in the requested
state, the state for that context will remain unchanged.If MT is not PS attached when the activation form
of the command is executed, MT will first perform a PS attach and then attempt to activate the specified
contexts.If no <cid> specifies the activation/deactivation form of the command, it will activate or
deactivate all defined contexts.";

        public override CommandCategory Category => CommandCategory.PacketDomainCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("state","Integer type. Indicate the state of PDP context activation.",new Dictionary<string, object> {
                { "Deactivated", 0 },
                { "Activated", 1 },
            },true),
            new IntegerCommandParameter("cid","Integer type. Specify a particular PDP context definition.",false),
        };

        protected override string RawCommand => "AT+CGACT";
    }
}
