using System;
using System.Threading;
using MSWind.Connection;
using MSWind.Scripts;

namespace MSWind
{
    /// <summary>
    /// Maplestory client.
    /// Handles all interaction with the server.
    /// </summary>
    public class Client
    {
        public AccountInfo Account = new AccountInfo();
        public MapleConnection MapleConnect;
        public Thread LoginThread;
        public MainForm MForm;

        /// <summary>
        /// HandlePacket
        /// Switches packet header and runs the appropriate scripts
        /// </summary>
        /// <param name="packet">Packet to be Handled</param>
        public void HandlePacket(byte[] packet)
        {
            PacketReader Reader = new PacketReader(packet);
            short header = Reader.ReadShort();
            byte[] Packet = Reader.ReadBytes(packet.Length - 2);
            switch (header)
            {
                case (short)PacketOpcodes.rPing:
                    new HandlePing(this);
                    break;

                case (short)PacketOpcodes.rLogin:
                    new HandleLoginInfo(this, Packet);
                    break;

                case (short)PacketOpcodes.rPwKey:
                    new HandleLogin(this, Packet);
                    break;

                case (short)PacketOpcodes.rPin:
                    new HandlePin(this, Packet);
                    break;

                case (short)PacketOpcodes.rWorldInfo:
                    new HandleWorldInfo(this, Packet);
                    break;

                case (short)PacketOpcodes.rWorldSelectAllClear:
                    new HandleSelectWorld(this);
                    break;

                case (short)PacketOpcodes.rChannelSelectAllClear:
                    new HandleSelectChannel(this);
                    break;

                case (short)PacketOpcodes.rCharInfo:
                    new HandleCharList(this, Packet);
                    break;

                case (short)PacketOpcodes.rServerInfo:
                    new HandleServerConnect(this, Packet);
                    break;

                case (short)PacketOpcodes.rLoggedIn:
                    new HandleLoggedIn(this, Packet);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Login to account
        /// </summary>
        public void Login(MainForm form)
        {
            MForm = form;
            Account.LoggingIn = true;
            LoginThread = new Thread(CheckLoggedIn);
            LoginThread.Start();
        }

        /// <summary>
        /// Checks if account login has succeeded,
        /// If not restarts login process.
        /// </summary>
        public void CheckLoggedIn()
        {
            while (!Account.LoggedIn)
            {
                new Init(this);
                Thread.Sleep(2000);
            }
            // Account logged in, update form data
            Account.LoggingIn = false;
            MForm.ChangedAccount();
        }

        public void LoginCharacter()
        {
            Account.Characters[Account.CharacterIndex].LoggingIn = true;
            Thread LoginCharacter = new Thread(CheckCharacterLoggedIn);
            LoginCharacter.Start();
        }

        public void CheckCharacterLoggedIn()
        {
            while (!Account.Characters[Account.CharacterIndex].LoggedIn)
            {
                new LoginCharacter(this, Account.CharacterIndex);
                Thread.Sleep(1000);
            }
            Account.Characters[Account.CharacterIndex].LoggingIn = false;
            Thread SpamGP = new Thread(StartSpamGP);
            SpamGP.Start();
            MForm.ChangedAccount();
        }

        public void StartSpamGP()
        {
            while (Account.Characters[Account.CharacterIndex].LoggedIn)
            {
                PacketWriter Writer = new PacketWriter();
                // 95 00 1D 08 00 00 00
                Writer.WriteShort(0x95);
                Writer.WriteShort(0x81D);
                Writer.WriteShort(0);
                Writer.WriteByte(0);
                SendPacket(Writer);
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// Converts PacketWriter memory stream to byte[]
        /// Sends converted packet over mConnection
        /// </summary>
        /// <param name="writer">PacketWriter to be converted to byte[] and sent</param>
        public void SendPacket(PacketWriter writer)
        {
            byte[] Buffer = new byte[writer.Length];
            Buffer = writer.ToArray();
            this.MapleConnect.SendPacket(Buffer);
        }

        /// <summary>
        /// Change current MapleConnection
        /// </summary>
        /// <param name="host">Host IP address as a string</param>
        /// <param name="port">Host port</param>
        public void ChangeConnection(string host, int port)
        {
            if (this.MapleConnect != null)
            {
                this.MapleConnect.Close();
            }
            this.MapleConnect = new MapleConnection(host, port, this);
        }

        /// <summary>
        /// Convert int IP address to string and then change connection
        /// </summary>
        /// <param name="host">Host IP address as int</param>
        /// <param name="port">Host port</param>
        public void ChangeIntConnection(int host, int port)
        {
            byte[] Bytes = BitConverter.GetBytes(host);
            string Str = string.Format("{0}.{1}.{2}.{3}", new object[] { Bytes[0], Bytes[1], Bytes[2], Bytes[3] });
            this.ChangeConnection(Str, port);
        }
    }
}
