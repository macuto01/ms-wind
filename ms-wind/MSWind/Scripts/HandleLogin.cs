using MSWind.Connection;
using System.Text;

namespace MSWind.Scripts
{
    /// <summary>
    /// Handles account login
    /// </summary>
    class HandleLogin
    {
        /// <summary>
        /// Handles account login.
        /// Encrypts password and send login packet.
        /// </summary>
        /// <param name="client">Client from which packet was received</param>
        /// <param name="packet">Packet to be handled</param>>
        public HandleLogin(Client client, byte[] packet)
        {
            PacketReader Reader = new PacketReader(packet);

            int Length = Reader.ReadShort();
            byte[] Key = Reader.ReadBytes(Length);
            string PwEncrypted = Encoding.ASCII.GetString(Crypto.WzRSAEncrypt.Encrypt(Key, Length, client.Account.Password));

            byte[] Buffer = { 0x00, 0xE0, 0x4D, 0xA6, 0xA5, 0xCF, 0xB4, 0x68, 0xCB, 0xE4, 0x00, 0x00, 0x00, 0x00, 0x32, 0xFD, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00 };

            PacketWriter Writer = new PacketWriter();
            Writer.WriteShort(PacketOpcodes.sLogin);
            Writer.WriteMapleString(client.Account.Username);
            Writer.WriteMapleString(PwEncrypted.ToString());
            Writer.WriteMapleString("00E04DA6A5CF_B468CBE4");
            Writer.WriteBytes(Buffer);
            client.SendPacket(Writer);
        }
    }
}
