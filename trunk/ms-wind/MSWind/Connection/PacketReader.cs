using System;
using System.IO;
using System.Text;

namespace MSWind.Connection
{
    /// <summary>
    /// Class to handle reading data from a packet
    /// </summary>
    public class PacketReader : AbstractPacket
    {
        /// <summary>
        /// The main reader tool
        /// </summary>
        private readonly BinaryReader BinReader;

        /// <summary>
        /// Amount of data left in the reader
        /// </summary>
        public short Length
        {
            get { return (short)Buff.Length; }
        }

        /// <summary>
        /// Creates a new instance of PacketReader
        /// </summary>
        /// <param name="arrayOfBytes">Starting byte array</param>
        public PacketReader(byte[] arrayOfBytes)
        {
            Buff = new MemoryStream(arrayOfBytes, false);
            BinReader = new BinaryReader(Buff, Encoding.ASCII);
        }

        /// <summary>
        /// Restart reading from the point specified.
        /// </summary>
        /// <param name="length">The point of the packet to start reading from.</param>
        public void Reset(int length)
        {
            Buff.Seek(length, SeekOrigin.Begin);
        }

        public void Skip(int length)
        {
            Buff.Position += length;
        }

        /// <summary>
        /// Reads an unsigned byte from the stream
        /// </summary>
        /// <returns> an unsigned byte from the stream</returns>
        public byte ReadByte()
        {
            return BinReader.ReadByte();
        }

        /// <summary>
        /// Reads a byte array from the stream
        /// </summary>
        /// <param name="length">Amount of bytes</param>
        /// <returns>A byte array</returns>
        public byte[] ReadBytes(int count)
        {
            return BinReader.ReadBytes(count);
        }

        /// <summary>
        /// Reads a bool from the stream
        /// </summary>
        /// <returns>A bool</returns>
        public bool ReadBool()
        {
            return BinReader.ReadBoolean();
        }

        /// <summary>
        /// Reads a signed short from the stream
        /// </summary>
        /// <returns>A signed short</returns>
        public short ReadShort()
        {
            return BinReader.ReadInt16();
        }

        /// <summary>
        /// Reads a signed int from the stream
        /// </summary>
        /// <returns>A signed int</returns>
        public int ReadInt()
        {
            return BinReader.ReadInt32();
        }

        /// <summary>
        /// Reads a signed long from the stream
        /// </summary>
        /// <returns>A signed long</returns>
        public long ReadLong()
        {
            return BinReader.ReadInt64();
        }

        /// <summary>
        /// Reads an ASCII string from the stream
        /// </summary>
        /// <param name="length">Amount of bytes</param>
        /// <returns>An ASCII string</returns>
        public string ReadString(int length)
        {
            return Encoding.ASCII.GetString(ReadBytes(length));
        }

        /// <summary>
        /// Reads a maple string from the stream
        /// </summary>
        /// <returns>A maple string</returns>
        public string ReadMapleString()
        {
            return ReadString(ReadShort());
        }

        /// <summary>
        /// Reads a null terminated string
        /// </summary>
        /// <returns>Returns a string</returns>
        public string ReadNullTerminatedString()
        {
            byte Num;
            string Str = "";
            while ((Num = this.ReadByte()) != 0)
            {
                Str = Str + ((char)Num);
            }
            return Str;
        }
    }
}
