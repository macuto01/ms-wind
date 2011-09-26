using System;
using System.Windows.Forms;
using MSWind.Connection;

namespace MSWind.Scripts
{
    class HandleSelectWorld
    {
        public HandleSelectWorld(Client client)
        {
            for (int i = 0; i <= 1; i++)
            {
                if (client.Account.Worlds[i].Name.ToUpper() == client.Account.World.ToUpper())
                {
                    client.Account.WorldIndex = i;
                    int MinIndex = 0;

                    if (client.Account.AutoSelect)
                    {
                        for (int j = 0; j < client.Account.Worlds[i].ChannelCount; j++)
                        {
                            if (MinIndex == 0)
                                MinIndex = j;
                            else if (client.Account.Worlds[i].Channels[j].Population < client.Account.Worlds[i].Channels[MinIndex].Population)
                                MinIndex = j;
                        }
                        // MessageBox.Show("Selecting channel " + client.Account.Worlds[i].Channels[MinIndex].Name + " with the lowest population (" + client.Account.Worlds[i].Channels[MinIndex].Population + ")");
                        client.Account.ChannelIndex = MinIndex;
                    }
                }
            }

            if (client.Account.WorldIndex == -1)
                MessageBox.Show("Unable to find world.");
            else
            {
                PacketWriter Writer = new PacketWriter();
                Writer.WriteShort(PacketOpcodes.sSelectWorld);
                Writer.WriteShort(client.Account.Worlds[client.Account.WorldIndex].ID);
                client.SendPacket(Writer);
            }
        }
    }
}
