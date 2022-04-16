using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class MTResponseFormat : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "MT Response Format";

        public override string Description => "This command determines the contents of header and trailer transmitted with AT command result codes and information responses.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("Value","Integer Type",new Dictionary<string, object> {
                { "Information response: <text><CR><LF> Short result code format: <numeric code><CR>",0 },
                { "nformation response: <CR><LF><text><CR><LF> Long result code format: <CR><LF><verbose code><CR><LF>",1}
            } ,false)
        };

        protected override string RawCommand => "ATV0";
    }
}
