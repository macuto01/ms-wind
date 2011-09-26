using System;
using System.IO;
using System.Text;

namespace MSWind.Connection
{
    /// <summary>
    /// Class to handle writing packets
    /// </summary>
    public class PacketWriter : AbstractPacket
    {
        /// <summary>
        /// The main writer tool
        /// </summary>
        private readonly BinaryWriter BinWriter;

        /// <summary>
        /// Amount of data writen in the writer
        /// </summary>
        public short Length
        {
            get { return (short)Buff.Length; }
        }

        /// <summary>
        /// Creates a new instance of PacketWriter
        /// </summary>
        public PacketWriter()
            : this(0)
        {
        }

        /// <summary>
        /// Creates a new instance of PacketWriter
        /// </summary>
        /// <param name="size">Starting size of the buffer</param>
        public PacketWriter(int size)
        {
            Buff = new MemoryStream(size);
            BinWriter = new BinaryWriter(Buff, Encoding.ASCII);
        }

        public PacketWriter(byte[] data)
        {
            Buff = new MemoryStream(data);
            BinWriter = new BinaryWriter(Buff, Encoding.ASCII);
        }

        /// <summary>
        /// Restart writing from the point specified. This will overwrite data in the packet.
        /// </summary>
        /// <param name="length">The point of the packet to start writing from.</param>
        public void Reset(int length)
        {
            Buff.Seek(length, SeekOrigin.Begin);
            Buff.SetLength(length);
        }

        /// <summary>
        /// Writes a byte to the stream
        /// </summary>
        /// <param name="@byte">The byte to write</param>
        public void WriteByte(int @byte)
        {
            BinWriter.Write((byte)@byte);
        }

        /// <summary>
        /// Writes a byte array to the stream
        /// </summary>
        /// <param name="@bytes">The byte array to write</param>
        public void WriteBytes(byte[] @bytes)
        {
            BinWriter.Write(@bytes);
        }

        /// <summary>
        /// Writes a boolean to the stream
        /// </summary>
        /// <param name="@bool">The boolean to write</param>
        public void WriteBool(bool @bool)
        {
            BinWriter.Write(@bool);
        }

        /// <summary>
        /// Writes a short to the stream
        /// </summary>
        /// <param name="@short">The short to write</param>
        public void WriteShort(int @short)
        {
            BinWriter.Write((short)@short);
        }

        /// <summary>
        /// Writes an int to the stream
        /// </summary>
        /// <param name="@int">The int to write</param>
        public void WriteInt(int @int)
        {
            BinWriter.Write(@int);
        }

        /// <summary>
        /// Writes a long to the stream
        /// </summary>
        /// <param name="@long">The long to write</param>
        public void WriteLong(long @long)
        {
            BinWriter.Write(@long);
        }

        /// <summary>
        /// Writes a string to the stream
        /// </summary>
        /// <param name="@string">The string to write</param>
        public void WriteString(String @string)
        {
            BinWriter.Write(@string.ToCharArray());
        }

        /// <summary>
        /// Writes a string prefixed with a [short] length before it, to the stream
        /// </summary>
        /// <param name="@string">The string to write</param>
        public void WriteMapleString(String @string)
        {
            WriteShort((short)@string.Length);
            WriteString(@string);
        }

        /// <summary>
        /// Writes a hex-string to the stream
        /// </summary>
        /// <param name="@string">The hex-string to write</param>
        public void WriteHexString(String hexString)
        {
            WriteBytes(HexEncoding.GetBytes(hexString));
        }

        /// <summary>
        /// Sets a byte in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@byte">The byte to set</param>
        public void SetByte(long index, int @byte)
        {
            long oldIndex = Buff.Position;
            Buff.Position = index;
            WriteByte((byte)@byte);
            Buff.Position = oldIndex;
        }

        /// <summary>
        /// Sets a byte array in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@bytes">The bytes to set</param>
        public void SetBytes(long index, byte[] @bytes)
        {
            long oldIndex = Buff.Position;
            Buff.Position = index;
            WriteBytes(@bytes);
            Buff.Position = oldIndex;
        }

        /// <summary>
        /// Sets a bool in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@bool">The bool to set</param>
        public void SetBool(long index, bool @bool)
        {
            long oldIndex = Buff.Position;
            Buff.Position = index;
            WriteBool(@bool);
            Buff.Position = oldIndex;
        }

        /// <summary>
        /// Sets a short in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@short">The short to set</param>
        public void SetShort(long index, int @short)
        {
            long oldIndex = Buff.Position;
            Buff.Position = index;
            WriteShort((short)@short);
            Buff.Position = oldIndex;
        }

        /// <summary>
        /// Sets an int in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@int">The int to set</param>
        public void SetInt(long index, int @int)
        {
            long oldIndex = Buff.Position;
            Buff.Position = index;
            WriteInt(@int);
            Buff.Position = oldIndex;
        }

        /// <summary>
        /// Sets a long in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@long">The long to set</param>
        public void SetLong(long index, long @long)
        {
            long oldIndex = Buff.Position;
            Buff.Position = index;
            WriteLong(@long);
            Buff.Position = oldIndex;
        }

        /// <summary>
        /// Sets a long in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@string">The long to set</param>
        public void SetString(long index, string @string)
        {
            long oldIndex = Buff.Position;
            Buff.Position = index;
            WriteString(@string);
            Buff.Position = oldIndex;
        }

        /// <summary>
        /// Sets a string prefixed with a [short] length before it, in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@string">The string to set</param>
        public void SetMapleString(long index, string @string)
        {
            long oldIndex = Buff.Position;
            Buff.Position = index;
            WriteMapleString(@string);
            Buff.Position = oldIndex;
        }

        /// <summary>
        /// Sets a hex-string in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@string">The hex-string to set</param>
        public void SetHexString(long index, string @string)
        {
            long oldIndex = Buff.Position;
            Buff.Position = index;
            WriteHexString(@string);
            Buff.Position = oldIndex;
        }

    }
}
