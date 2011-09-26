using System.Windows.Forms;
using MSWind.Connection;

namespace MSWind.Scripts
{
    class HandleLoginInfo
    {
        public HandleLoginInfo(Client client, byte[] packet)
        {
            PacketReader Reader = new PacketReader(packet);

            byte Type = Reader.ReadByte();

            if (Type == 4)
            {
                MessageBox.Show("Incorrect password.");
                client.MapleConnect.Close();
                client.LoginThread.Abort();
                client.Account.LoggingIn = false;
                client.MForm.ChangedAccount();
            }
            else if (Type == 5)
            {
                MessageBox.Show("Username does not exist.");
                client.MapleConnect.Close();
                client.LoginThread.Abort();
                client.Account.LoggingIn = false;
                client.MForm.ChangedAccount();
            }
            else if (Type == 7)
            {
                MessageBox.Show("Account already logged in.");
                client.MapleConnect.Close();
                client.LoginThread.Abort();
                client.Account.LoggingIn = false;
                client.MForm.ChangedAccount();
            }
            else
            {
                client.Account.AccountID = Reader.ReadInt();
                Reader.ReadByte();
                Reader.ReadByte();
                Reader.ReadByte();
                client.Account.Username = Reader.ReadMapleString();
                Reader.ReadMapleString();
                Reader.ReadInt();
                //MessageBox.Show("Actual username: " + client.Account.Accountusername + "; Account id: " + client.Account.Account_id);

                PacketWriter Writer = new PacketWriter();
                Writer.WriteShort(PacketOpcodes.sPin);
                Writer.WriteByte(1);
                Writer.WriteByte(0);
                Writer.WriteInt(client.Account.AccountID);
                Writer.WriteMapleString(client.Account.Pin);

                client.SendPacket(Writer);
            }
        }
    }
}

