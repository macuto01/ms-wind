using System;
using MSWind.Connection;

namespace MSWind.Scripts
{
    class HandleWorldInfo
    {
        public HandleWorldInfo(Client client, byte[] packet)
        {
            PacketReader Reader = new PacketReader(packet);

            byte WorldID = Reader.ReadByte();

            if (WorldID != 0xFF)
            {
                string WorldName = Reader.ReadMapleString();
                byte EventType = Reader.ReadByte();
                string EventInfo = Reader.ReadMapleString();
                Reader.ReadShort();
                Reader.ReadShort();
                byte ChannelCount = Reader.ReadByte();

                //byte WorldID = # player["worlds"];
                client.Account.Worlds[WorldID] = new Account.World();

                client.Account.Worlds[WorldID].ID = WorldID;
                client.Account.Worlds[WorldID].Name = WorldName;
                client.Account.Worlds[WorldID].EventType = EventType;
                client.Account.Worlds[WorldID].EventInfo = EventInfo;
                client.Account.Worlds[WorldID].ChannelCount = ChannelCount;

                for (int i = 0; i < ChannelCount; i++)
                {
                    string ChannelName = Reader.ReadMapleString();
                    int ChannelPopulation = Reader.ReadInt();
                    byte ChannelWorld = Reader.ReadByte();
                    byte ChannelID = Reader.ReadByte();
                    byte ChannelLanguage = Reader.ReadByte();

                    client.Account.Worlds[WorldID].Channels[i] = new Account.Channel();

                    client.Account.Worlds[WorldID].Channels[i].Name = ChannelName;
                    client.Account.Worlds[WorldID].Channels[i].Population = ChannelPopulation;
                    client.Account.Worlds[WorldID].Channels[i].World = ChannelWorld;
                    client.Account.Worlds[WorldID].Channels[i].ID = ChannelID;
                    client.Account.Worlds[WorldID].Channels[i].Language = ChannelLanguage;
                }
            }
        }
    }
}
