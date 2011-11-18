using System;
using MSWind.Connection;

namespace MSWind.Scripts
{
    class HandleSelectChannel
    {
        public HandleSelectChannel(Client client)
        {
            // if we reach here then that means that the world select succeeded, ensuring that WorldID & channel_id are NOT nil, all cool
            Random Rand = new Random(System.DateTime.Now.Millisecond);
            PacketWriter Writer = new PacketWriter();
            Writer.WriteShort((short)PacketOpcodes.sSelectChannel);
            Writer.WriteByte(client.Account.Worlds[client.Account.WorldIndex].ID);
            Writer.WriteByte(client.Account.Worlds[client.Account.WorldIndex].Channels[client.Account.ChannelIndex].ID);
            Writer.WriteInt(Rand.Next(40604, 230493854));
            Writer.WriteByte(client.Account.Worlds[client.Account.WorldIndex].Channels[client.Account.ChannelIndex].Language);
            Writer.WriteMapleString("Windows Vista");
            Writer.WriteMapleString("ETHERNET");
            client.SendPacket(Writer);
        }
    }
}