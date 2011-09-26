using System;
using System.Net.Sockets;
using System.Threading;
using MSWind.Crypto;

namespace MSWind.Connection
{
    /// <summary>
    /// Class to handle connection to maplestory server
    /// </summary>
    public class MapleConnection
    {
        public TcpClient TcpConnection;
        private int MapleVersion;
        private bool Ready;
        private MapleCrypto ReceiveCrypto;
        public Thread ReceiveLoopThread;
        private MapleCrypto SendCrypto;
        private Client Client;

        /// <summary>
        /// Creates a connection to maplestory
        /// </summary>
        /// <param name="server">Maplestory server IP</param>
        /// <param name="port">Maplestory server port</param>
        /// <param name="client">Client to send packets from</param>
        public MapleConnection(string server, int port, Client client)
        {
            this.Client = client;
            this.TcpConnection = new TcpClient(server, port);
            while (!this.TcpConnection.Connected)
            {
                Thread.Sleep(10);
            }

            this.ReceiveLoopThread = new Thread(new ThreadStart(this.ReceiveLoop));

            this.ReceiveLoopThread.Start();
        }

        /// <summary>
        /// A loop to check for received packets
        /// </summary>
        private void ReceiveLoop()
        {
            if (this.TcpConnection.Connected)
            {
                while (this.TcpConnection.Available < 0x10)
                {
                    Thread.Sleep(50);
                }
                byte[] buffer = new byte[0x10];
                this.TcpConnection.GetStream().Read(buffer, 0, 0x10);

                PacketReader Reader = new PacketReader(buffer);
                Reader.ReadShort();
                this.MapleVersion = Reader.ReadShort();
                Reader.ReadMapleString();
                this.SendCrypto = new MapleCrypto(Reader.ReadBytes(4), (short)this.MapleVersion);
                this.ReceiveCrypto = new MapleCrypto(Reader.ReadBytes(4), (short)this.MapleVersion);

                this.Ready = true;
                while (this.TcpConnection.Connected)
                {
                    if (this.TcpConnection.Available >= 4)
                    {
                        byte[] buffer2 = new byte[4];
                        this.TcpConnection.GetStream().Read(buffer2, 0, 4);
                        int packetLength = MapleCrypto.GetPacketLength(buffer2);
                        while (this.TcpConnection.Available < packetLength)
                        {
                            Thread.Sleep(20);
                        }
                        byte[] buffer3 = new byte[packetLength];
                        this.TcpConnection.GetStream().Read(buffer3, 0, packetLength);
                        this.ReceiveCrypto.Crypt(buffer3);
                        MapleCustomEncryption.Decrypt(buffer3);
                        Client.HandlePacket(buffer3);
                    }
                    Thread.Sleep(5);
                }
                this.Ready = false;
            }
        }

        /// <summary>
        /// Encrypts and sends the packet to the maplestory server
        /// </summary>
        /// <param name="packet">Input packet to be sent</param>
        public void SendPacket(byte[] packet)
        {
            if (this.TcpConnection.Connected)
            {
                while (!this.Ready)
                {
                    Thread.Sleep(50);
                }
                lock (this.SendCrypto)
                {
                    lock (this.TcpConnection)
                    {
                        byte[] dst = new byte[packet.Length];
                        byte[] buffer2 = new byte[packet.Length + 4];
                        byte[] headerToServer = this.SendCrypto.GetHeaderToServer(packet.Length);
                        Buffer.BlockCopy(packet, 0, dst, 0, packet.Length);
                        MapleCustomEncryption.Encrypt(dst);
                        this.SendCrypto.Crypt(dst);
                        Buffer.BlockCopy(headerToServer, 0, buffer2, 0, 4);
                        Buffer.BlockCopy(dst, 0, buffer2, 4, dst.Length);
                        try
                        {
                            this.TcpConnection.GetStream().Write(buffer2, 0, buffer2.Length);
                        }
                        catch { }
                    }
                }
            }
        }

        /// <summary>
        /// Closes the MapleConnection
        /// </summary>
        public void Close()
        {
            this.TcpConnection.Close();
        }
    }
}

