using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Network
{
    public class RoamingPreferenceConfiguration : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Roaming Preference Configuration";

        public override string Description => "This command specifies the roaming preference of UE.";

        public override CommandCategory Category => CommandCategory.NetworkServiceCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("roam_pref","Integer type. Roaming preference of UE.",new Dictionary<string, object> {
                { "Roam only on home network", 1 },
                { "Roam on affiliate network", 3 },
                { "Roam on any network", 255 },
            },true),
        };

        protected override string RawCommand => "AT+QNWPREFCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"roam_pref\"," + CreateParametersString(commandParameters);
        }
    }
}
