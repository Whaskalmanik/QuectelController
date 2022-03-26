using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class TestCallerIDFunctionofSLIC : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Test Caller ID Function of SLIC";

        public override string Description => "This command tests the caller ID function of SLIC.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new StringCommandParameter("num","String type. The phone number of caller ID. maximum length: 15 bytes.",false),
        };

        protected override string RawCommand => "AT+QAUDCFG";
        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"slic_cid\"," + CreateParametersString(commandParameters);
        }
    }
}
