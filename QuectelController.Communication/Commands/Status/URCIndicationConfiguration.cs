using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class URCIndicationConfiguration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "URC Indication Configuration";

        public override string Description => "This command controls URC indication.";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringListParameter("urctype","String type. URC type.",new Dictionary<string, object> {
                { "Master switch of all URCs. Default: ON.","all" },
                { "Indication of signal strength and channel bit error rate change","csq" },
                { "SMS storage full indication. Default: OFF. If this configuration is","smsfull" },
                { "RING indication. Default: ON.","ring" },
                { "Incoming message indication. Default: ON. Related URCs","smsincoming" },
                { "Indication of network access technology change. Default: OFF.","act" },
            },false),
            new IntegerListCommandParameter("enable","Integer type. URC indication is ON or OFF.",new Dictionary<string, object> {
                { "OFF",0 },
                { "ON",1 },
            },true),
            new IntegerListCommandParameter("savetonvram","Integer type. Whether to save configuration into NVM.",new Dictionary<string, object> {
                { "Not save",0 },
                { "Save",1 },
            },true),
        };

        protected override string RawCommand => "AT+QINDCFG";
    }
}
