namespace MSWind
{
    /// <summary>
    /// All account variables
    /// </summary>
    public class AccountInfo
    {         
        public string Username = "";
        public string Password = "";
        public string Pin = "";
        public string World = "";
        public string Character = "";
        public int WorldIndex = -1;
        public int ChannelIndex = -1;
        public bool AutoSelect = false;
        public int AccountID = -1;
        public byte[] SessionID = new byte[8];
        public byte CharacterCount = 0;
        public int ID = -1;
        public bool LoggedIn = false;
        public bool LoggingIn = false;
        public int CharacterIndex = 0;

        public static int AccountCount = 0;
        public static int SelectedAccountIndex = -1;
        public static Client[] Players = new Client[512];

        public Account.World[] Worlds = new Account.World[3];
        public Account.Character[] Characters = new Account.Character[15];
        public Account.Equip Equips = new Account.Equip();
    }
}
