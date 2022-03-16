using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Short_Message_Service
{
    public class ShowTextModeParameters : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Show Text Mode Parameters";

        public override string Description => "This command controls whether detailed header information is shown in text mode result codes.";

        public override CommandCategory Category => CommandCategory.ShortMessageServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("show","Intenger type",new Dictionary<string, object> {
                { "Do not show header values defined in commands +CSCA, +CSMP (<sca>, <tosca>, <fo>, <vp>, <pid>, <dcs>) and <length>, <toda> or <tooa> in +CMT, +CMGL, +CMGR result codes for SMS-DELIVERs and SMS-SUBMITs in text mode", 0 },
                { "Show the values in result codes", 1  },
            },false),
        };

        protected override string RawCommand => "AT+CSDH";
    }
}
