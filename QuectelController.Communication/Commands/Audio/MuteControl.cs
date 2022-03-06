using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class MuteControl : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Mute Control";

        public override string Description => "This command enables/disables the uplink voice muting during a voice call.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("n","Integer type.",new Dictionary<string, object> {
                { "Mute off",0 },
                { "Mute on",1 },
            },true),
        };

        protected override string RawCommand => "AT+CMUT";
    }
}
