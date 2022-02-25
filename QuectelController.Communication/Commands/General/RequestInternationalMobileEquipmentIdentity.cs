using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    public class RequestInternationalMobileEquipmentIdentity : CommandBase
    {
        public override bool CanExecute => true;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => false;

        public override string Name => "Request International Mobile Equipment Identity ";

        public override string Description => 
            @"This Execution Command requests the International Mobile Equipment Identity (IMEI) number of the ME 
which permits the user to identify individual ME device.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => Array.Empty<ICommandParameter>();

        protected override string RawCommand => "AT+GSN ";
    }
}
