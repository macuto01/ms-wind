namespace MSWind.Scripts
{
    public enum PacketOpcodes
    {
        // Global opcode table
        rPing = 0x0C,
        sPong = 0x14,
        sInit1 = 0x1D,
        rInit1 = 0x16,
        sInit2 = 0x10B,
        rPwKey = 0x12,
        sLogin = 0x01,
        rLogin = 0x00,
        sPin = 0x06,
        rPin = 0x03,
        sWorldInfoRequest = 0x8,
        rWorldInfoRequestConfirm = 0x8B,
        rWorldInfo = 0x05,
        rWorldSelectAllClear = 0x15,
        sSelectWorld = 0x05,
        rChannelSelectAllClear = 0x02,
        sSelectChannel = 0x04,
        rCharInfo = 0x06,
        sSelectCharacter = 0x0B,
        rServerInfo = 0x07,
        sChannelConnect = 0xC,
        sOwlTeleport = 0x43,
        sNpcChat = 0x38,
        sShop = 0x8C,
        rLoggedIn = 0x2A,

        rPlayerMove = 0xBF,
        sPlayerMove = 0x24
    }
}
