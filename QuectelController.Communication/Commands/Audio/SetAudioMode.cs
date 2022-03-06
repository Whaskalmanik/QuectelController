using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class SetAudioMode : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Set Audio Mode";

        public override string Description => "This command sets the audio mode required for the connected device.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("mode","Integer type. Indicate the current configured audio mode of echo canceller, noise suppressor, digital gain and parameter calibration.",new Dictionary<string, object> {
                { "Handset", 0 },
                { "Headset", 1 },
                { "Speaker", 2 },
                { "VCO", 3 },
                { "Bluetooth", 4 },
                { "Voice over USB", 5 },
                { "Full TTY", 6 },
                { "HCO", 7 },
                { "FAX", 8 },
            },true),
        };

        protected override string RawCommand => "AT+QAUDMOD";
    }
}
