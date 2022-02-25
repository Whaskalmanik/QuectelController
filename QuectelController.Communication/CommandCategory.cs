using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QuectelController.Communication
{
    public enum CommandCategory
    {
        [Description("General Commands")]
        GeneralCommands,
        [Description("Status Control Commands")]
        StatusControlCommands,
        [Description("(U)SIM Related Commands")]
        USIMRelatedCommands,
        [Description("Network Service Commands")]
        NetworkServiceCommands,
        [Description("Call Related Commands")]
        CallRelatedCommands,
        [Description("Phonebook")]
        Phonebook,
        [Description("Short Message Service Commands")]
        ShortMessageServiceCommands,
        [Description("Packet Domain Commands")]
        PacketDomainCommands,
        [Description("Supplementary Service Commands")]
        SupplementaryServiceCommands,
        [Description("Audio Commands")]
        AudioCommands,
        [Description("Hardware Related Commands")]
        HardwareRelatedCommands,
        

    }
}
