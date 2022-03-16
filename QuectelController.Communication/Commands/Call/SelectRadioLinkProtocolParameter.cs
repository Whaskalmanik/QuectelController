using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Call
{
    public class SelectRadioLinkProtocolParameter : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Select Radio Link Protocol Parameter";

        public override string Description => "This command selects radio link protocol (RLP) parameters used when non-transparent data calls are originated.";

        public override CommandCategory Category => CommandCategory.CallRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("iws","Integer type. Interworking Window Size (IWF to MS window size). 0–61 Interworking window size 0–240–488 For <ver>=2",true),
            new IntegerCommandParameter("mws","Integer type. Mobile Window Size (MS to IWF window size). 0–61 Mobile window size 0–240–488 For <ver>=2",true),
            new IntegerCommandParameter("T1","Integer type. 38–48–255 Acknowledgment timer T1 in a unit of 10ms 42–52–255 For <ver>=2",true),
            new IntegerCommandParameter("N2","Integer type. 1–6–55 Retransmission attempts N2",true),
            new IntegerCommandParameter("ver","0–2 RLP version number",true),
        };
        protected override string RawCommand => "AT+CRLP";
    }
}
