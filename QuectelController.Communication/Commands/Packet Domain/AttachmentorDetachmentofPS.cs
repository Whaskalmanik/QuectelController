using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Packet_Domain
{
    public class AttachmentorDetachmentofPS : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Attachment or Detachment of PS";

        public override string Description => 
            @"This command attaches MT to, or detaches MT from, the Packet Domain service. After the command has 
been completed, the MT remains in V.250 command state.If MT is already in the requested state, the
command will be ignored and the OK response will be returned. If the requested state cannot be achieved,
an ERROR or +CME ERROR response will be returned.";

        public override CommandCategory Category => CommandCategory.PacketDomainCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("state","Integer type. Indicate the state of PS attachment.",new Dictionary<string, object> {
                { "Detached", 0 },
                { "Attached", 1 },
            },false),
        };

        protected override string RawCommand => "AT+CGATT";
    }
}
