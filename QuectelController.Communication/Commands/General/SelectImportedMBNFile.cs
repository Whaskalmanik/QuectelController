using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    class SelectImportedMBNFile : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Select Imported MBN File";

        public override string Description => 
            @"This command selects a certain MBN file that has been loaded, and when the module is restarted, the 
selected MBN file will be activated.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new StringCommandParameter("MBN name","String type. MBN file name to be selected.",false),
        };

        protected override string RawCommand => "AT+QMBNCFG";
        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"Select\"," + CreateParametersString(commandParameters);
        }
    }
}
