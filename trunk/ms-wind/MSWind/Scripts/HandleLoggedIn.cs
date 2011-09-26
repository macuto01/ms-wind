using MSWind.Connection;

namespace MSWind.Scripts
{
    /// <summary>
    /// Handles received once character logs in
    /// </summary>
    class HandleLoggedIn
    {
        /// <summary>
        /// Handles received character login information and confirms CharacterID
        /// </summary>
        /// <param name="client">Client from which packet was received</param>
        /// <param name="packet"></param>
        public HandleLoggedIn(Client client, byte[] packet)
        {
            PacketReader Reader = new PacketReader(packet);
            int CharacterID = Reader.ReadInt();

            for (int i = 0; i < client.Account.CharacterCount; i++)
            {
                if (client.Account.Characters[i].ID == CharacterID)
                    client.Account.Characters[i].LoggedIn = true;
            }
        }
    }
}
