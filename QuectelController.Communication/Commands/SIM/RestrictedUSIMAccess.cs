using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class RestrictedUSIMAccess : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Restricted (U)SIM Access";

        public override string Description => "This command offers easy and limited access to the (U)SIM database. It transmits the (U)SIM command <command> and its required parameters to MT.";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("command","Integer type. (U)SIM command number.",new Dictionary<string, object> {
                { "READ BINARY",176 },
                { "READ RECORD",178 },
                { "GET RESPONSE",192 },
                { "UPDATE BINARY",214 },
                { "UPDATE RECORD ",220 },
                { "STATUS",242 },
                { "RETRIEVE DATA",203 },
                { "SET DATA",219 },
            },false),
            new IntegerCommandParameter("field","Integer type. Identifier for an elementary data file on (U)SIM, if used by <command>",true),
            new IntegerCommandParameter("P1","Parameters transferred by the MT to the (U)SIM. These parameters are mandatory for every command, except GET RESPONSE and STATUS. The values are described in 3GPP TS 51.011.",true),
            new IntegerCommandParameter("P2","Parameters transferred by the MT to the (U)SIM. These parameters are mandatory for every command, except GET RESPONSE and STATUS. The values are described in 3GPP TS 51.011.",true),
            new IntegerCommandParameter("P3","Parameters transferred by the MT to the (U)SIM. These parameters are mandatory for every command, except GET RESPONSE and STATUS. The values are described in 3GPP TS 51.011.",true),
            new StringCommandParameter("data","Information which should be written to the (U)SIM (hexadecimal character format; see AT+CSCS).",true),
            new IntegerCommandParameter("pathId","The directory path of an elementary file on a (U)SIM/UICC in hexadecimal format.",true),
        };

        protected override string RawCommand => "AT+CRSM";
    }
}
