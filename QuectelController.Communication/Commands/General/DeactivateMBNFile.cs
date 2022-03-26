using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    class DeactivateMBNFile : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Deactivate MBN File";

        public override string Description => "After the MBN file is deactivated, the currently activated MBN file becomes inactive.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();
       
        protected override string RawCommand => "AT+QMBNCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"Deactivate\"," + CreateParametersString(commandParameters);
        }
    }
}
