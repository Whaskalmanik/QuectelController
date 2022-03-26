using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.General
{
    class QueryImportedMBNFileList : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => false;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Query Imported MBN File List";

        public override string Description => "This command queries the imported MBN file list.";

        public override CommandCategory Category => CommandCategory.GeneralCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerCommandParameter ("Index","Integer type. The MBN index indicates which imported MBN file is currently listed.",false),
            new IntegerListCommandParameter("Celected","Integer type. Indicates whether the MBN file is selected.",new Dictionary<string, object> {
                { "Unselected",0 },
                { "Selected",1 },
            },true),
            new IntegerListCommandParameter("Activate","Integer type. Indicates whether the MBN file is activated.",new Dictionary<string, object> {
                { "Inactivated",0 },
                { "Activated",1 },
            },true),
            new StringCommandParameter("MBN name","String type. The name of the imported MBN file",false),
            new StringCommandParameter("MBN_version","String type. The version of the imported MBN file.",false),
            new StringCommandParameter("MBN_release_date","String type. The release date of the imported MBN file",false),
        };

        protected override string RawCommand => "AT+QMBNCFG";

        protected override string CreateCommandInternal(IEnumerable<ICommandParameter> commandParameters)
        {
            return RawCommand + "=\"List\"," + CreateParametersString(commandParameters);
        }
    }
}
