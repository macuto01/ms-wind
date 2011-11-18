using System.Windows.Forms;
using MSWind.Connection;

namespace MSWind.Scripts
{
    /// <summary>
    /// Handles received information about the character list
    /// </summary>
    class HandleCharList
    {
        /// <summary>
        /// Handles received information about the character list.
        /// Stores character variables for later access.
        /// </summary>
        /// <param name="client">Client from which packet was received</param>
        /// <param name="packet">Packet to be handled</param>
        public HandleCharList(Client client, byte[] packet)
        {
            PacketReader Reader = new PacketReader(packet);

            byte Error = Reader.ReadByte();
            if(Error!=0)
            {
                MessageBox.Show("Error selecting channel");
            }
            else
            {
                client.Account.CharacterCount = Reader.ReadByte();

                for(int i=0; i<client.Account.CharacterCount; i++)
                {
                    client.Account.Characters[i] = new Account.Character();

                    client.Account.Characters[i].ID = Reader.ReadInt();
                    PacketReader SubReader = new PacketReader(Reader.ReadBytes(13));
                    client.Account.Characters[i].Name = SubReader.ReadNullTerminatedString();
                    client.Account.Characters[i].Gender = Reader.ReadByte();
                    client.Account.Characters[i].Skin = Reader.ReadByte();
                    client.Account.Characters[i].Face = Reader.ReadInt();
                    client.Account.Characters[i].Hair = Reader.ReadInt();
                    client.Account.Characters[i].Level = Reader.ReadByte();
                    client.Account.Characters[i].Job = Reader.ReadShort();
                    client.Account.Characters[i].Str = Reader.ReadShort();
                    client.Account.Characters[i].Dex = Reader.ReadShort();
                    client.Account.Characters[i].Int = Reader.ReadShort();
                    client.Account.Characters[i].Luk = Reader.ReadShort();
                    client.Account.Characters[i].HP = Reader.ReadShort();
                    client.Account.Characters[i].MaxHp = Reader.ReadShort();
                    client.Account.Characters[i].MP = Reader.ReadShort();
                    client.Account.Characters[i].MaxMp = Reader.ReadShort();
                    client.Account.Characters[i].AP = Reader.ReadShort();
                    if (client.Account.Characters[i].Job / 1000 == 3 || client.Account.Characters[i].Job / 100 == 22 || client.Account.Characters[i].Job == 2001)
                    {
                        byte spCount = Reader.ReadByte();
                        Reader.Skip(spCount * 2);//sp for each job level
                    }
                    else
                        client.Account.Characters[i].SP = Reader.ReadShort();
                    //Reader.Skip(Reader.ReadByte() * 2);
                    client.Account.Characters[i].XP = Reader.ReadInt();
                    client.Account.Characters[i].Fame = Reader.ReadShort();
                    client.Account.Characters[i].Map = Reader.ReadInt();
                    client.Account.Characters[i].SpawnPoint = Reader.ReadByte();
                    Reader.ReadInt();  // unknown
                    Reader.ReadShort();  // unknown
                    Reader.ReadInt();  // unknown
                    Reader.ReadInt();  // unknown
                    Reader.ReadBytes(8); // unknown
                    Reader.ReadByte();   // gender (again)
                    Reader.ReadByte();   // skin (again)
                    Reader.ReadInt();  // face (again)
                    Reader.ReadByte();   // unknown
                    Reader.ReadInt();  // hair (again)

                    byte Position = Reader.ReadByte();

                    while(Position != 0xFF)
                    {
                        client.Account.Equips.Visible[Position] = Reader.ReadInt();
                        Position = Reader.ReadByte();
                    }

                    Position = Reader.ReadByte();

                    while(Position != 0xFF)
                    {
                        client.Account.Equips.Masked[Position] = Reader.ReadInt();
                        Position = Reader.ReadByte();
                    }

                    client.Account.Equips.CashWeapon = Reader.ReadInt();
                    
                    Reader.ReadBytes(12);    // pet info
                    Reader.ReadByte();       // unknown
                    if(Reader.ReadByte()!=0)
                        Reader.Skip(16);       // ranking
                }

                Reader.ReadShort();          // unknown
                Reader.ReadShort();          // unknown
                Reader.ReadBytes(6);         // unknown
                client.Account.SessionID = Reader.ReadBytes(8);

                client.Account.LoggedIn = true;
                // Program.mFrm.LoggedIn(client.Account.id);
                // Program.mFrm.AddCharacters(client.Account.character_count);
            }
        }
    }
}
