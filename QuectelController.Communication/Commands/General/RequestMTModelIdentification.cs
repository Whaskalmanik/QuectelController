using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class RequestMTModelIdentification : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Request MT Model Identification";

        public override string Description => "This command returns the model information of the product.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+CGMM";
    }
}
