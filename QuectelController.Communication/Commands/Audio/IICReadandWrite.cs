using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Audio
{
    public class IICReadandWrite : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "IIC Read and Write";

        public override string Description => "This command configures the codec via IIC interface.";

        public override CommandCategory Category => CommandCategory.AudioCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("rw","Integer type.",new Dictionary<string, object> {
                { "Write command",0 },
                { "Read command",1 },
            },false),
            new IntegerCommandParameter("device","Hex integer type.0–0xFF 7-bit device address",false),
            new IntegerCommandParameter("addr","Hex Integer type.0–0xFF Register address",false),
            new IntegerListCommandParameter("bytes","Integer type.",new Dictionary<string, object> {
                { "Read bytes",1 },
                { "Write bytes",2 },
            },false),
            new IntegerCommandParameter("value","Hex integer type.0–0xFFFF Data value",true),
        };

        protected override string RawCommand => "T+QIIC";
    }
}
