using System;
using MSWind.Connection;

namespace MSWind.Scripts
{
    class LoginCharacter
    {
        public LoginCharacter(Client client, int id)
        {
            PacketWriter Writer = new PacketWriter();
            Writer.WriteShort((short)PacketOpcodes.sSelectCharacter);
            Writer.WriteInt(client.Account.Characters[id].ID);
            client.SendPacket(Writer);
            // Program.mFrm.CharLoggedIn(id);
        }
    }
}
