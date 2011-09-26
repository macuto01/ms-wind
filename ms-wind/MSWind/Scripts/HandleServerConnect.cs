using System;
using MSWind.Connection;

namespace MSWind.Scripts
{
    class HandleServerConnect
    {
        public HandleServerConnect(Client client, byte[] packet)
        {
            PacketReader Reader = new PacketReader(packet);

            Reader.ReadByte();                       // unknown
            Reader.ReadByte();                       // unknown
            int Host = Reader.ReadInt();
            int Port = Reader.ReadShort();
            int CharacterID = Reader.ReadInt();
            Reader.ReadByte();                       // unknown
            Reader.ReadInt();                      // unknown

            client.ChangeIntConnection(Host, Port);

            byte[] Buffer = { 0x00, 0xE0, 0x4D, 0xA6, 0xA5, 0xCF, 0xB4, 0x68, 0xCB, 0xE4, 0x00, 0x00, 0x00, 0x00, 0x32, 0xFD, 0x00, 0x00 };

            PacketWriter Writer = new PacketWriter();
            Writer.WriteShort(PacketOpcodes.sChannelConnect);
            Writer.WriteInt(CharacterID);
            Writer.WriteBytes(Buffer);
            Writer.WriteBytes(client.Account.SessionID);

            client.SendPacket(Writer);
        }
    }
}
