using System.IO;

namespace MSWind.Connection
{
	public abstract class AbstractPacket
	{
		protected MemoryStream Buff;

		public byte[] ToArray()
		{
			return Buff.ToArray();
		}
	}
}
