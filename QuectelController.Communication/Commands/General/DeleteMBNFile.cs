using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class DeleteMBNFile : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Delete MBN File";

        public override string Description => "This command deletes MBN file from EFS.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new StringCommandParameter("MBN name","String type. The name of the imported MBN file",true),
        };

        protected override string RawCommand => "AT+QMBNCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"Delete\"," + CreateParametersString(commandParameters);
        }
    }
}
