using QuectelController.Communication.CommandParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuectelController.Communication.Commands.Packet_Domain
{
    public class EnterDataState : CommandBase
    {
        public override bool CanExecute => false;

        public override bool CanTest => true;

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override string Name => "Enter Data State";

        public override string Description => @"This Write Command causes the MT to perform whatever actions that are necessary to establish 
communication between the TE and the network using one or more packet domain PDP types.This may
include performing a PS attach and one or more PDP context activations.Any commands following the
AT+CGDATA in the AT command line shall not be processed by MT. 

If the <L2P> value is unacceptable to MT, MT shall return an ERROR or +CME ERROR. Otherwise, the
MT issues the intermediate result code CONNECT and enters V.250 online data state.After data transfer
is completed, and the layer 2 protocol termination procedure has been completed successfully, the V.250 
command state is re-entered and the MT returns the final result code OK.";

        public override CommandCategory Category => CommandCategory.PacketDomainCommands;

        public override IReadOnlyList<ICommandParameter> AvailableParameters => new ICommandParameter[]
        {
            new IntegerListCommandParameter("L2P","String type. indicates the layer 2 protocol to be used between TE and MT",new Dictionary<string, object> {
                { "Point to Point protocol for a PDP such as IP", "PPP" },
            },false),
            new IntegerCommandParameter("cid","Integer type. Specify a particular PDP context definition.",false),
        };

        protected override string RawCommand => "AT+CGDATA";
    }
}
