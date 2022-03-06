using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Packet_Domain
{
    public class QualityofServiceProfileAcceptable : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Quality of Service Profile (Minimum Acceptable)";

        public override string Description => @"This command allows TE to specify a minimum acceptable profile which is checked by MT against the 
negotiated profile when the PDP context is activated. The Write Command specifies a profile for the 
context identified by the context identification parameter <cid>. 

A special form of the Write Command, AT+CGQMIN=<cid> causes the minimum acceptable profile for 
context number <cid> to become undefined. In this case no check is made against the negotiated profile. 
This Read Command returns the current configurations for each defined context. Details can be found in 
3GPP TS 23.107 and all parameters are saved in NVM automatically";

        public override CommandCategory Category => CommandCategory.PacketDomainCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("cid","Integer type. Specify a particular PDP context definition.",false),
            new StringListParameter("PDP_type","String type. Packet Data Protocol type.",new Dictionary<string, object> {
                { "IP", "IP" },
                { "PPP", "PPP" },
                { "IPV6", "IPV6" },
                { "IPV4V6", "IPV4V6" },
            },true),
            new IntegerListCommandParameter("precedence","Integer type. Specify the precedence class.",new Dictionary<string, object> {
                { "Network subscribed value", 0 },
                { "High Priority. Service commitments shall be maintained ahead of precedence classes 2 and 3", 1 },
                { "Normal priority. Service commitments should be maintained ahead of precedence class 3", 2 },
                { "Low priority. Service commitments should be maintained", 3 },
            },true),
            new IntegerCommandParameter("delay","Integer type. A numeric parameter which specifies the delay class. This parameter defines the end-to-end transfer delay incurred in the transmission of SDUs through the network. Values are in Table in AT Commands documentation. Values are from 0-4",true),
            new IntegerCommandParameter("reliability","Integer type. A numeric parameter which specifies the reliability class.",true),
            new IntegerCommandParameter("peak","Integer type. A numeric parameter which specifies the peak throughput class, in octets per second.",true),
            new IntegerCommandParameter("mean","Integer type. Specify the mean throughput class, in octets per hour.",true),
        };

        protected override string RawCommand => "AT+CGQMIN";
    }
}
