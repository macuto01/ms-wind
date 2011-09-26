using MSWind.Connection;

namespace MSWind.Scripts
{
    /// <summary>
    /// Initialises the connection to the server
    /// </summary>
    class Init
    {
        /// <summary>
        /// Initialises the connection to the server.
        /// Connects to the server and sends packets to initialise the session.
        /// </summary>
        /// <param name="client">Client to initialise</param>
        public Init(Client client)
        {
            client.ChangeConnection("109.234.73.11", 8484);

            PacketWriter Writer = new PacketWriter();
            Writer.WriteShort(PacketOpcodes.sInit1);
            client.SendPacket(Writer);
            Writer.Reset(0);

            Writer.WriteShort(PacketOpcodes.sInit2);
            client.SendPacket(Writer);
        }
    }
}