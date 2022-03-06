using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class DigitalAudioInterfaceConfiguration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override string Name => "Digital Audio Interface Configuration";

        public override string Description => "This command configures the digital audio interface. When there is no codec on board, please define the PCM formats.In the following conditions, the MT can be used directly with default settings (master mode,short-synchronization, 2048 kHz clock frequency, 16-bit liner data format, 8 kHz sampling rate).";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter("io","Codec. It can be set to x, 1–6. (Not supported currently)",false),
            new IntegerListCommandParameter("mode","Integer type.",new Dictionary<string, object> {
                { "Master mode", 0 },
                { "Slave mode", 1 },
            },true),
            new IntegerListCommandParameter("fsync","Integer type.",new Dictionary<string, object> {
                { "Primary mode (short-synchronization)", 0 },
                { "Auxiliary mode (long-synchronization)", 1 },
            },true),
            new IntegerListCommandParameter("clock","Integer type. Clock frequency.",new Dictionary<string, object> {
                { "128 kHz (Not supported currently)", 0 },
                { "256 kHz", 1 },
                { "512 kHz", 2 },
                { "1024 kHz", 3 },
                { "2048 kHz", 4 },
                { "4096 kHz", 5 },
            },true),
            new IntegerListCommandParameter("format","nteger type. Data format.",new Dictionary<string, object> {
                { "16-bit linear", 0 },
            },true),
            new IntegerListCommandParameter("sample","Integer type",new Dictionary<string, object> {
                { "8 kHz", 0 },
                { "16 kHz", 1 },
            },true),
            new IntegerListCommandParameter("sample","Integer type",new Dictionary<string, object> {
                { "Number of slot", 1 },
                { "Number of slot (Set to 2 when use <slot_mapping1>)", 2 },
            },true),
            new IntegerCommandParameter("slot_mapping0","Integer type. Slot mapping value. Range: 1–16.",false),
            new IntegerCommandParameter("slot_mapping1","Integer type. Slot mapping value. Range: 2–16.",false),
        };
        protected override string RawCommand => "AT+QDAI";
    }
}
