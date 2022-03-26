using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.SIM
{
    public class GenericUICCLogicalChannelAccess : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Generic UICC Logical Channel Access";

        public override string Description => "This command allows a direct control of the currently selected UICC by a distant application on the TE. The TE shall then take care of processing UICC information within the frame specified by GSM/UMTS";

        public override CommandCategory Category => CommandCategory.USIMRelatedCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("sessionid","Integer type. This is the identifier of the session to be used in order to send the APDU commands to the UICC. It is mandatory in order to send commands to the UICC when targeting applications on the smart card using a logical channel other than the default channel(channel 0).",false),
            new IntegerCommandParameter("length","Integer type. Length of the characters that are sent to TE in <command> or <response> (two times the actual length of the command or response).",false),
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
        };

        protected override string RawCommand => "AT+CGLA";
    }
}
