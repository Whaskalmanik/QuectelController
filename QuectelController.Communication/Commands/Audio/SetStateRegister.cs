using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class SetStateRegister : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Set State Register";

        public override string Description => "This command sets the linefeed operating state register of the SLIC chip.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
{
            new IntegerListCommandParameter("state","Integer type. Set the linefeed operating state register of the SLIC chip.",new Dictionary<string, object> {
                { "FORWARD ACTIVE. It enables on-hook/off-hook detection feature. When in-hook, the audio function is disabled. When off-hook, the audio function is enabled.", 0 },
                { "RINGING. It indicates that the analog phone detects the TIP/RING telephone line, and when it is in the RINGING state, it will generate ring tone to remind the userthat there is currently an incoming call", 1 },
            },true),
        };

        protected override string RawCommand => "AT+QAUDCFG";
        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"slic/LF_Ring\"," + CreateParametersString(commandParameters);
        }
    }
}
