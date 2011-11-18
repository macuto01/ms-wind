using MSWind.Connection;

namespace MSWind.Scripts
{
    class HandlePing
    {
        public HandlePing(Client client)
        {
            PacketWriter Writer = new PacketWriter();
            Writer.WriteShort((short)PacketOpcodes.sPong);

            client.SendPacket(Writer);
        }
    }
}
