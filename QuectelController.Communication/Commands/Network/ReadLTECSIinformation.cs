﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class ReadLTECSIinformation : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Read LTE CSI information";

        public override string Description => "This command reads LTE CSI information including MCS, CQI, RI and PMI";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+QNWCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"csi_ctrl\"," + CreateParametersString(commandParameters);
        }
    }
}
