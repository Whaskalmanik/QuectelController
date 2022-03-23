using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class DefinePDPContexts : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Define PDP Contexts";

        public override string Description => 
            @"The command specifies PDP context parameters for a specific context <cid>. A special form of the Write 
Command (AT+CGDCONT=<cid>) causes the values for context <cid> to become undefined. It is not 
allowed to change the definition of an already activated context. 
This Read Command returns the current configurations for each defined PDP context";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
           new IntegerCommandParameter("cid",
               @"Integer type.  PDP context identifier. A numeric parameter which specifies a particular 
PDP context definition. The parameter is local to the TE-MT interface and is used in 
other PDP context-related commands.The range of supported values (minimum value
= 1) is returned by the test form of the command.Range: 1–42.",true),
           new StringListParameter("PDP_Type","String type. Packet data protocol type, a string parameter which specifies the type of packet data protocol.",new Dictionary<string, object> {
               { "IPv4. Internet protocol (IETF STD 5)", "IP" },
               { "Point to Point Protocol (IETF STD 51)", "PPP" },
               { "Internet Protocol, version 6 (see RFC 2460)]", "IPV6" },
               { "Virtual introduced to handle dual IP stack UE capability. (See 3GPP TS 24.301)", "IPV4V6" },
           }, true),
           new StringCommandParameter("APN",@"String type. Access point name, which is a logical name used to select the GGSN or the external packet data network. If the value is null or omitted, then the subscription value will be requested.",true),
           new StringCommandParameter("PDP_addr",
               @"String type. Identify the MT in the address space applicable to the PDP. If the value is 
null or omitted, then a value may be provided by the TE during the PDP startup 
procedure or, failing that, a dynamic address will be requested. The allocated 
address may be read using the AT+CGPADDR.",true),
           new IntegerListCommandParameter("data_comp","Integer type. Controls PDP data compression (applicable for SNDCP only) (see 3GPP TS 44.065).",new Dictionary<string, object> {
               { "Off", 0 },
               { "On (Manufacturer preferred compression)", 1 },
               { "V.42bis", 2 },
               { "V.44 (Not supported currently)", 3 },
           }, true),
           new IntegerListCommandParameter("head_comp","Integer type. Control PDP header compression (see 3GPP TS 44.065 and 3GPP TS 25.323).",new Dictionary<string, object> {
               { "Off", 0 },
               { "On ", 1 },
               { "RFC1144", 2 },
               { "RFC2507", 3 },
               { "RFC3095", 4 },
           }, true),
           new IntegerListCommandParameter("IPv4_addr_alloc","Integer type. Control how the MT/TA requests to get the IPv4 address information.",new Dictionary<string, object> {
               { "IPv4 address allocation through NAS signaling", 0 },
               { "IPv4 address allocated through DHCP", 1 },
           }, true),
           new IntegerListCommandParameter("request_type","Integer type. Indicate the type of PDP context activation request for the PDP context.",new Dictionary<string, object> {
               { "PDP context is for new PDP context establishment or for handover from a non-3GPP access network (how the MT decides whether the PDP context isfor new PDP context establishment or for handover is implementation specific).", 0 },
               { "PDP context is for emergency bearer services.", 1 },
           }, true),
           new IntegerListCommandParameter("P-SCF_discoverty"," Integer type. Influence how the MT/TA requests to get the P-CSCF address, see 3GPP TS 24.229 annex B and annex L.",new Dictionary<string, object> {
               { "Preference of P-CSCF address discovery not influenced by AT+CGDCONT.", 0 },
               { "Preference of P-CSCF address discovery through NAS signaling.", 1 },
               { "Preference of P-CSCF address discovery through DHCP.", 2 },
           }, true),
           new IntegerListCommandParameter("IM_CN_Signalling_Flag_Ind","Integer type. Indicate to the network whether the PDP context is for IM CN subsystem-related signaling only or not.",new Dictionary<string, object> {
               { " UE indicates that the PDP context is not for IM CN subsystem-related signaling only.", 0 },
               { "UE indicates that the PDP context is for IM CN subsystem-related signaling only.", 1 },
           }, true),
           new IntegerListCommandParameter("NSLPI","Integer type. Indicate the NAS signaling priority requested for this PDP context.",new Dictionary<string, object> {
               { "This PDP context is to be activated with the value for the low priority indicator configured in the MT.", 0 },
               { "This PDP context is to be activated with the value for the low priority indicator set to MS is not configured for NAS signaling low priority.", 1 },
           }, true),
           new IntegerListCommandParameter("securePCO","Integer type. Specify if security protected transmission of PCO is requested or not (applicable for EPS only, see 3GPP TS 23.401 subclause 6.5.1.2).",new Dictionary<string, object> {
               { "Security protected transmission of PCO is not requested", 0 },
               { "Security protected transmission of PCO is requested", 1 },
           }, true),
           new IntegerListCommandParameter("IPv4_MTU_discovery","Integer type. Influence how the MT/TA requests to get the IPv4 MTU size, see 3GPP TS 24.008 subclause 10.5.6.3.",new Dictionary<string, object> {
               { "Preference of IPv4 MTU size discovery not influenced by AT+CGDCONT", 0 },
               { "Preference of IPv4 MTU size discovery through NAS signaling", 1 },
           }, true),
           new IntegerListCommandParameter("local_addr_ind","Integer type. Indicate to the network whether the MS supports local IP address in TFTs (see 3GPP TS 24.301 and 3GPP TS 24.008 subclause10.5.6.3).",new Dictionary<string, object> {
               { "The MS does not support local IP address in TFTs", 0 },
               { "That the MS supports local IP address in TFTs", 1 },
           }, true),
           new IntegerListCommandParameter("Non-IP_MTU_discovery","Integer type. Influence how the MT/TA requests to get the Non-IP MTU size, see 3GPP TS 24.008 subclause 10.5.6.3.",new Dictionary<string, object> {
               { "Preference of Non-IP MTU size discovery not influenced by AT+CGDCONT", 0 },
               { "Preference of Non-IP MTU size discovery through NAS signaling", 1 },
           }, true),
           new IntegerListCommandParameter("Reliable_Data_Service","nteger type. Indicate whether the UE is using Reliable Data Service for a PDN connection or not, see 3GPP TS 24.301 and 3GPP TS 24.008 subclause 10.5.6.3.",new Dictionary<string, object> {
               { "Reliable Data Service is not being used for the PDN connection", 0 },
               { "Reliable Data Service is being used for the PDN connection", 1 },
           }, true),
           new IntegerListCommandParameter("SSC_mode","Integer type. Indicate the session and service continuity (SSC) mode for the PDU session in 5GS, see 3GPP TS 23.501.",new Dictionary<string, object> {
               { "The PDU session is associated with SSC mode 1", 0 },
               { "The PDU session is associated with SSC mode 2", 1 }, 
               { "The PDU session is associated with SSC mode 3", 2 },
           }, true),
           new StringCommandParameter("S-NSSAI",
               @"String type in hexadecimal character format. Dependent of the form, the string can be 
separated by dot(s) and semicolon(s). This parameter is associated with the PDU
session for identifying a network slice in 5GS, see 3GPP TS 23.501 and 3GPP TS 
24.501. For the format and the encoding of S-NSSAI, see also 3GPP TS 23.003. This 
parameter shall not be subject to conventional character conversion as per AT+CSCS. 
The parameter has one of the forms:
sst only slice/service type (SST) is present
sst;mapped_sst SST and mapped configured SST are present
sst.sd SST and slice differentiator (SD) are present
sst.sd;mapped_sst SST, SD and mapped configured SST are present
sst.sd;mapped_sst.mapped_sd SST, SD, mapped configured SST and mapped 
configured SD are present",true),
           new IntegerListCommandParameter("Pref_access_type","Integer type. Indicate the preferred access type for the PDU session in 5GS, see 3GPP TS 23.501 and 3GPP TS 24.501.",new Dictionary<string, object> {
               { "The preferred access type is 3GPP access", 0 },
               { "The preferred access type is non-3GPP access", 1 },
           }, true),
           new IntegerListCommandParameter("RQos_ind","Integer type. Indicate whether the UE supports reflective QoS for the PDU session, see 3GPP TS 23.501 and 3GPP TS 24.501.",new Dictionary<string, object> {
               { "Reflective QoS is not supported for the PDU session", 0 },
               { "Reflective QoS is supported for the PDU session", 1 },
           }, true),
           new IntegerListCommandParameter("MH6-PDU","Integer type. Indicate whether the UE supports IPv6 multi-homing for the PDU session, see 3GPP TS 23.501 and 3GPP TS 24.501",new Dictionary<string, object> {
               { "IPv6 multi-homing is not supported for the PDU session", 0 },
               { "IPv6 multi-homing is supported for the PDU session", 1 },
           }, true),
           new IntegerListCommandParameter("Always-on_req","Integer type. Indicate whether the UE requests to establish the PDU session as an always-on PDU session, see 3GPP TS 24.501.",new Dictionary<string, object> {
               { "always-on PDU session is not requested", 0 },
               { "always-on PDU session is requested", 1 },
           }, true),
        };

        protected override string RawCommand => "AT+CGDCONT";
    }
}
