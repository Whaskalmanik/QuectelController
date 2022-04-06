using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QuectelController.Communication
{
    public enum CommandCategory
    {
        [Description("General Commands")]
        GeneralCommands = 0,
        [Description("Status Control Commands")]
        StatusControlCommands = 1,
        [Description("(U)SIM Related Commands")]
        USIMRelatedCommands = 2,
        [Description("Network Service Commands")]
        NetworkServiceCommands = 3,
        [Description("Call Related Commands")]
        CallRelatedCommands = 4,
        [Description("Phonebook")]
        Phonebook = 5,
        [Description("Short Message Service Commands")]
        ShortMessageServiceCommands = 6,
        [Description("Packet Domain Commands")]
        PacketDomainCommands = 7,
        [Description("Supplementary Service Commands")]
        SupplementaryServiceCommands = 8,
        [Description("Audio Commands")]
        AudioCommands = 9,
        [Description("Hardware Related Commands")]
        HardwareRelatedCommands = 10,
    }
}
