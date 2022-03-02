using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class ConfigureURCIndicationOption : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Configure URC Indication Option";

        public override string Description => "This command configures the output port of URC.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringListParameter("Multicommand value","String type.",new Dictionary<string, object>{
                { "This command configures the output port of URC.","urcport" },
            }, false),
            new StringListParameter("chset","String type.",new Dictionary<string, object> {
                { "USB AT port","usbat" },
                { "USB modem port","usbmodem" },
                { "Main UART","uart1" },
                { "All ports","all" }
            } ,true),
        };

        protected override string RawCommand => "AT+QURCCFG";
    }
}
