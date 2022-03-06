using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Supplementary_Service
{
    public class UnstructuredSupplementaryServiceData : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Unstructured Supplementary Service Data";

        public override string Description => 
           @"This command allows control of the Unstructured Supplementary Service Data (USSD) according to 
3GPP TS 22.090. Both network and mobile initiated operations are supported.

<mode> disables/enables the presentation of an unsolicited result code. The value <mode>=2 cancels
an ongoing USSD session.For a USSD response from the network, or a network initiated operation, the
format is: +CUSD: <status>[,<rspstr>,[<dcs>]].

When<reqstr> is given, a mobile initiated USSD string or a response USSD string to a network-initiated
operation is sent to the network.The response USSD string from the network is returned in a subsequent 
+CUSD URC.";

        public override CommandCategory Category => CommandCategory.SupplementaryServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("mode","Integer type. Sets/indicates the result code presentation status to the TE.",new Dictionary<string, object> {
                { "Disable the result code presentation to the TE", 0 },
                { "Enable the result code presentation to the TE", 1 },
                { "Cancel session (not applicable to Read Command response)", 2 },
            },true),
            new StringCommandParameter("reqstr","String type. Unstructured Supplementary Service Data (USSD) to be sent to the network. If this parameter is omitted, network is not interrogated.",true),
            new IntegerCommandParameter("dcs","Integer type. 3GPP TS 23.038 Cell Broadcast Data Coding Scheme (default 15",true),
        };

        protected override string RawCommand => "AT+CUSD";
    }
}
