using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class _5GSNSSAISetting : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "5GS NSSAI Setting";

        public override string Description => "This command enables updating the default configuration NSSAI stored at MT";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters { get; } = new ICommandParameter[]
        {
            new IntegerCommandParameter("dfl_nssai_len","Integer type. Indicate the length in octets of the default configured NSSAI to be stored at the MT.",false),
            new StringCommandParameter("dfl_config_nssai",
                @"String type in hexadecimal format. Dependent of the form, the string can be
separated by dot(s), semicolon(s) and colon(s). This parameter indicates the list
of S-NSSAIs included in the default configured NSSAI to be stored by the MT.
<dfl_config_nssai> is coded as a list of <S-NSSAI>s separated by colons. Refer
<S-NSSAI> in subclause 10.1.1. This parameter shall not be subject to
conventional character conversion as per AT+CSCS.",false),
        };

        protected override string RawCommand => "AT+C5GNSSAI";
    }
}
