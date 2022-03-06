using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class AddMBNFile : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Delete MBN File";

        public override string Description => "This command deletes MBN file from EFS";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
             new StringCommandParameter("filename","String type. The name of the MBN file to be added.",false),
        };

        protected override string RawCommand => "AT+QMBNCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"Add\"" + CreateParametersString(commandParameters);
        }
    }
}

