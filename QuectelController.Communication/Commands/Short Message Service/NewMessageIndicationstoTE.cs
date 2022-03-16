using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    class NewMessageIndicationstoTE : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "New Message Indications to TE";

        public override string Description =>
            @"This command selects the procedure on how the received new messages from the network are indicated 
to the TE when TE is active, e.g., DTR is at low level (ON). If TE is inactive (e.g., DTR is at high level 
(OFF)), message receiving should be done as specified in 3GPP TS 23.038";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("mode","Intenger type",new Dictionary<string, object> {
                { "Buffer unsolicited result codes in the MT. If MT result code buffer is full, indications can be buffered in some other place or the oldest indications may be discardedand replaced with the new received indications.", 0 },
                { "Discard indication and reject new received message unsolicited result codes when MT-TE link is reserved (e.g. in data mode). Otherwise forward them directly to TE.", 1  },
                { "Buffer unsolicited result codes in the MT when MT-TE link is reserved (e.g. in data mode) and flush them to the TE after reservation. Otherwise forward them directly to TE.", 2 },
            },true),
            new IntegerListCommandParameter("mt","Integer type. The rules for storing received SMS depend on its data coding scheme (refer to 3GPPTS 23.038) and preferred memory storage (AT+CPMS) setting, and the value is",new Dictionary<string, object> {
                { "No SMS-DELIVER indications are routed to TE", 0 },
                { "If SMS-DELIVER is stored into ME/TA, indication of the memory location is routed to the TE by using unsolicited result code: +CMTI: <mem>,<index>", 1  },
                { @"SMS-DELIVERs (except class 2) are routed directly to the TE using unsolicited 
result code: +CMT: [<alpha>],<length><CR><LF><pdu> (PDU mode enabled)
or +CMT: <oa>,[< alpha >],<scts>[,<tooa>,<fo>,<pid>,<dcs>,<sca>,<tosca>,
  <length>]<CR><LF><data> (text mode enabled; about the parameters in italics, 
see AT+CSDH). Class 2 messages result in indication as defined in <mt>=1.", 2 },
                { "Class 3 SMS-DELIVERs are routed directly to TE by using unsolicited result codes defined in <mt>=2. Messages of other classes result in indication as defined in <mt>=1", 3 },
            },true),
            new IntegerListCommandParameter("bm","Integer type. The rules for storing received CBMs depend on its data coding scheme (refer to 3GPP TS 23.038) and the setting of Select CBM Types (AT+CSCB); and the value is",new Dictionary<string, object> {
                { "No CBM indications are routed to the TE.", 0 },
                { "New CBMs are routed directly to the TE using unsolicited result code: +CBM: <length><CR><LF><pdu> (PDU mode enabled); or +CBM: <sn>,<mid>,<dcs>,<page>,<pages><CR><LF><data> (text mode enabled)", 2  },
            },true),
            new IntegerListCommandParameter("ds","Intenger type",new Dictionary<string, object> {
                { "No SMS-STATUS-REPORTs are routed to the TE.", 0 },
                { "SMS-STATUS-REPORTs are routed to the TE using unsolicited result code: +CDS: <length><CR><LF><pdu> (PDU mode) or+CDS: <fo>,<mr>,[< ra >],[<tora>],<scts>,<dt>,<st> (text mode)", 1  },
                { "If SMS-STATUS-REPORT is stored into ME/TA, indication of the memory location is routed to the TE using unsolicited result code: +CDSI: <mem>,<index>", 2 },
            },true),
            new IntegerListCommandParameter("bfr","Intenger type",new Dictionary<string, object> {
                { "TA buffer of unsolicited result codes defined within this command is flushed to the TE when <mode> 1 or 2 is specified (OK response shall be given before flushing the codes)", 0 },
                { "TA buffer of unsolicited result codes defined within this command is cleared when <mode> 1 or 2 is specified.", 1  },
            },true),
        };

        protected override string RawCommand => "AT+CNMI";
    }
}
