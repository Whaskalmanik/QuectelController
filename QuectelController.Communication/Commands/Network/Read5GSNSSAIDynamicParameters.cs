using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class Read5GSNSSAIDynamicParameters : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Read 5GS NSSAI Dynamic Parameters";

        public override string Description => "This command returns the default configured NSSAI, rejected NSSAI for 3GPP access and rejected NSSAI for non-3GPP access stored at the MT.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
           new IntegerListCommandParameter("nssai_type", "Integer type. Specify the type of NSSAI to be returned.", new Dictionary<string, object> {
               { "Return stored default configured NSSAI only", 0 },
               { "Return stored default configured NSSAI and rejected NSSAI(s)", 1 },
               { "Return stored default configured NSSAI, rejected NSSAI(s) and configured NSSAI(s)", 2 },
               { " Return stored default configured NSSAI, rejected NSSAI(s), configured NSSAI(s) and allowed NSSAI(s)", 3 },
           }, false),
           new StringCommandParameter("plmn_id","String type. Indicate the MCC and MNC of the PLMN to which the NSSAI information applies. For the format and the encoding of the MCC and MNC, see 3GPP TS 23.003. This parameter shall not be subject to conventional character conversion as per AT+CSCS.",false)
        };

        protected override string RawCommand => "AT+C5GNSSAIRDP";
    }
}
