namespace MSWind.Account
{
    /// <summary>
    /// All character variables
    /// </summary>
    public class Character
    {
        public int ID;
        public string Name;
        public byte Gender;
        public byte Skin;
        public int Face;
        public int Hair;
        public byte Level;
        public short Job;
        public short Str;
        public short Dex;
        public short Luk;
        public short Int;
        public short HP = -1;
        public short MaxHp = -1;
        public short MP = -1;
        public short MaxMp = -1;
        public short AP;
        public short SP;
        public int XP;
        public short Fame;
        public int Map;
        public byte SpawnPoint;
        public bool LoggedIn = false;
        public bool LoggingIn = false;

        public static int SelectedCharacterIndex = 0;
    }
}
