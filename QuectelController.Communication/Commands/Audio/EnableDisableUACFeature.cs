using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class EnableDisableUACFeature : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Enable/Disable UAC Feature";

        public override string Description => "This command enables/disables the UAC feature. After UAC is enabled, when you make a call, the voice data from the MT will be decoded into PCM data by the module, and then be outputted to the devicethrough the configured USB port.In the meantime, the device writes the PCM data to the port and thedata will be transferred to the other end of the calling device over the network.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("enable","Integer type. Enable/disable UAC function.",new Dictionary<string, object> {
                { "Disable",0 },
                { "Enable",1 },
            },false),
            new IntegerListCommandParameter("option","Integer type. Configure the port or sound card for PCM data transmission.",new Dictionary<string, object> {
                { "UAC mode. The module serves as a USB sound card in the mode.",2 },
            },true),
        };

        protected override string RawCommand => "AT+QPCMV";
    }
}
