using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Status
{
    public class ExtendedConfigurationSettings : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Extended Configuration Settings";

        public override string Description => "Multi purpouse command";

        public override CommandCategory Category => CommandCategory.StatusControlCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new StringListParameter("Multicommand value","String type.",new Dictionary<string, object> {
                { "This command specifies the HSDPA category. ","hsdpacat" },
                { "USB modem port","hsupacat" },
                { "Main UART","rrc" },
                { "All ports","pdp/duplicatechk" },
                { "All ports","risignaltype" },
                { "All ports","sarcfg" },
                { "All ports","data_interface" },
                { "All ports","pcie/mode" },
                { "All ports","usbspeed" }
            } ,false),
            new IntegerListCommandParameter("cat","Integer type. HSDPA category",new Dictionary<string, object> {
                { "Category 6",6 },
                { "Category 8",8 },
                { "Category 10",10 },
                { "Category 12",12 },
                { "Category 14",14 },
                { "Category 18",18 },
                { "Category 20",20 },
                { "Category 24",24 },
            },true),
            new StringCommandParameter("MBN name","String type. MBN file name to be selected.",true),

            new StringCommandParameter("filename","String type. MBN file name to be selected.",true),
            //TODO
        };

        protected override string RawCommand => "AT+QCFG";
    }
}
