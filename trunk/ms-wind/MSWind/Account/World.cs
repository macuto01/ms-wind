namespace MSWind.Account
{
    /// <summary>
    /// All world variables
    /// </summary>
    public class World
    {
        public byte ID;
        public string Name;
        public byte EventType;
        public string EventInfo;
        public byte ChannelCount;
        public Channel[] Channels = new Channel[15];
    }
}
