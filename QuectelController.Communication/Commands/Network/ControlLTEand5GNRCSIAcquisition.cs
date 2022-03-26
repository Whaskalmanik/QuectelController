using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    class ControlLTEand5GNRCSIAcquisition : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Control LTE and 5G NR CSI Acquisition";

        public override string Description => "This command controls LTE or 5G NR CSI acquisition.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("LTE_enable","Integer type. Enable or disable LTE CSI acquisition.",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable", 1 },
            },true),
            new IntegerListCommandParameter("NR5G_enable","Integer type. Enable or disable 5G NR CSI acquisition.",new Dictionary<string, object> {
                { "Disable", 0 },
                { "Enable", 1 },
            },true),
        };

        protected override string RawCommand => "AT+QNWCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"csi_ctrl\"," + CreateParametersString(commandParameters);
        }
    }
}
