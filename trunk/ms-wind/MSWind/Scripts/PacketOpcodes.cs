namespace MSWind.Scripts
{
    public struct PacketOpcodes
    {
        // Global opcode table
        public const short rPing = 0x0C;
        public const short sPong = 0x14;
        public const short sInit1 = 0x1E;
        public const short rInit1 = 0x16;
        public const short sInit2 = 0x1C;
        public const short rPwKey = 0x12;
        public const short sLogin = 0x01;
        public const short rLogin = 0x00;
        public const short sPin = 0x06;
        public const short rPin = 0x03;
        public const short sWorldInfoRequest = 0x8;
        public const short rWorldInfoRequestConfirm = 0x8B;
        public const short rWorldInfo = 0x05;
        public const short rWorldSelectAllClear = 0x15;
        public const short sSelectWorld = 0x05;
        public const short rChannelSelectAllClear = 0x02;
        public const short sSelectChannel = 0x04;
        public const short rCharInfo = 0x06;
        public const short sSelectCharacter = 0x0B;
        public const short rServerInfo = 0x07;
        public const short sChannelConnect = 0xC;
        public const short sOwlTeleport = 0x43;
        public const short sNpcChat = 0x38;
        public const short sShop = 0x8C;
        public const short rLoggedIn = 0x2A;

        public const short rPlayerMove = 0xBF;
        public const short sPlayerMove = 0x24;
    }
}
