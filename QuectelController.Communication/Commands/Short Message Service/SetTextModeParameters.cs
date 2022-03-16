using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class SetTextModeParameters : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Text Mode Parameters";

        public override string Description => "This command sets values for additional parameters needed when a short message is sent to the network or placed in a storage in text mode.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerCommandParameter("fo","First octet. Depending on the command or result code: first octet of 3GPP TS 23.040 SMS-DELIVER, SMS-SUBMIT (default 17), SMS-STATUS-REPORT, SMS-COMMAND in integer format. If a valid value has been entered once, parameter can be omitted",false),
            new IntegerCommandParameter("vp","Validity period. Depend on SMS-SUBMIT <fo> setting: 3GPP TS 23.040 TP-Validity-Period either in integer format or in time-string format (see <dt>). Default: 167.",true),
            new IntegerCommandParameter("pid","Integer type. Protocol identifier. 3GPP TS 23.040 TP-Protocol-Identifier. Default: 0.",true),
            new IntegerCommandParameter("dcs","Data coding scheme. Depending on the command or result code: 3GPP TS 23.038 SMS Data Coding Scheme (default: 0), or Cell Broadcast Data Coding Scheme in integer format",true),
        };

        protected override string RawCommand => "AT+CSMP";
    }
}
