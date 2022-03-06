using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Packet_Domain
{
    public class ReportPacketDomainEvent : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Report Packet Domain Event";

        public override string Description => "This command enables/disables sending of unsolicited result codes +CGEV: XXX from MT to TE in the case of certain events occurring in the Packet Domain MT or the network. <mode> controls the processing of unsolicited result codes specified within this command. <bfr> controls the effect on buffered codes when<mode> 1 or 2 is specified.";

        public override CommandCategory Category => CommandCategory.PacketDomainCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("mode","Integer type.",new Dictionary<string, object> {
                { "Buffer unsolicited result codes in the MT; if MT result code buffer is full, the oldest ones can be discarded. No codes are forwarded to the TE.", 0 },
                { "Discard unsolicited result codes when MT-TE link is reserved (e.g. in on-line data mode); otherwise forward them directly to the TE.", 1 },
                { "Buffer unsolicited result codes in the MT when MT-TE link is reserved (e.g. in on-line data mode) and flush them to the TE when MT-TE link becomes available; otherwise forward them directly to the TE.", 2 },
            },true),
            new IntegerListCommandParameter("bfr","Integer type.",new Dictionary<string, object> {
                { "MT buffer of unsolicited result codes defined within this command is cleaned when <mode> 1 or 2 is specified.", 0 },
                { "MT buffer of unsolicited result codes defined within this command is flushed to the TE when <mode> 1 or 2 is specified (OK response shall be given before flushing the codes). ", 1 },
            },true),
        };

        protected override string RawCommand => "AT+CGEREP";
    }
}
