using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    class ServiceCenterAddress : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Service Center Address";

        public override string Description => 
            @"The Write Command updates the SMSC address when mobile originated SMS are transmitted. In text
mode, the setting is used by Write Command.In PDU mode, setting is used by the same command, but
only when the length of the SMSC address is coded into the<pdu> parameter which equals zero.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringCommandParameter("sca",
                @"Service center address. 3GPP TS 24.011 RP SC address Address-Value field in string 
format; BCD numbers (or GSM 7-bit default alphabet characters) are converted to
characters of the currently selected TE character set (see AT+CSCS in 3GPP TS
27.007). The type of address is given by <tosca>",false),
            new IntegerCommandParameter("tosca","Type of service center address. 3GPP TS 24.011 RP SC address Type-of-Address octet in integer format (see <toda> by default).",true),
        };

        protected override string RawCommand => "AT+CSCA";
    }
}
