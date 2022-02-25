using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class SetResultCodePresentationMode : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Set Result Code Presentation Mode";

        public override string Description => 
            @"This command controls whether the result code is transmitted to the TE. Other information text transmitted as response is not affected.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new[]
        {
            new IntegerListCommandParameter("Value","Integer Type",new Dictionary<string, object> {
                { "Result codes are transmitted",0 },
                { "Result codes are suppressed and not transmitted",1 }
            } ,false)
        };

        protected override string RawCommand => "ATQ";
    }
}
