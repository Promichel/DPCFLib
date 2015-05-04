using System.IO;
using DynaStudios.DPCFLib.Solutions;

namespace DynaStudios.DPCFLib.Format.Reader
{
    public class DPCFHeaderReader : AbstractByteReader, IReader<DPCFFileHeader>
    {
        public DPCFHeaderReader(FileStream fileHeaderBytes) : base(fileHeaderBytes)
        {
            
        }

        public void InitReader(byte[] fileHeaderBytes)
        {
            
        }

        public DPCFFileHeader ReadHeader()
        {

            DPCFFileHeader header = new DPCFFileHeader();

            header.Version = ReadShort();
            header.HashedFileHeaderSize = ReadUInt();
            header.HashedFileHeaders = ReadHashedFileHeaders(header.HashedFileHeaderSize);
            header.HFHHash = ReadBytes(16);
            header.IndexDictionarySize = ReadUInt();
            header.IndexDictionaryLength = ReadIndexLength(header.IndexDictionarySize);
            header.IndexDictionary = ReadDictionary(header.IndexDictionaryLength);
            header.FileCreation = ReadLong();
            header.FileChanged = ReadLong();

            return header;
        }

        private byte[][] ReadDictionary(uint[] indexDictionaryLength)
        {
            byte[][] result = new byte[indexDictionaryLength.Length][];
            for (int i = 0; i < indexDictionaryLength.Length; i++)
            {
                result[i] = new byte[indexDictionaryLength[i]];
                for (int j = 0; j < indexDictionaryLength[i]; j++)
                {
                    result[i][j] = ReadByte();
                }
            }

            return result;
        }

        private uint[] ReadIndexLength(uint size)
        {
            uint[] result = new uint[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = ReadUInt();
            }
            return result;
        }

        private DPCFHashedFileHeader[] ReadHashedFileHeaders(uint hashedFileHeaderSize)
        {
            DPCFHashedFileHeader[] result = new DPCFHashedFileHeader[hashedFileHeaderSize];
            
            for (var i = 0; i < hashedFileHeaderSize; i++)
            {
                result[i] = ReadHashedFileHeader();
            }

            return result;
        }

        private DPCFHashedFileHeader ReadHashedFileHeader()
        {
            var result = new DPCFHashedFileHeader();
            result.Identifier = ReadUInt();
            result.LocationIdentifier = ReadUInt();
            result.FileHash = ReadBytes(16);
            result.CompressionMethod = (FileCompression)ReadShort();
            result.UncompressedFileSize = ReadULong();
            result.CompressedFileSize = ReadULong();
            result.DataBlockOffset = ReadUInt();

            return result;
        }
    }

    public abstract class AbstractByteReader
    {
        public FileStream FileHeader { get; private set; }
        public int CurrentIndex { get; private set; }

        protected AbstractByteReader(FileStream fileHeaderBytes)
        {
            FileHeader = fileHeaderBytes;
            CurrentIndex = -1;
        }

        public short ReadShort()
        {
            return unchecked((short) ((ReadByte() << 8) | ReadByte()));
        }

        public byte ReadByte()
        {
            var b = FileHeader.ReadByte();
            return (byte)b;
        }

        public int ReadInt()
        {
            return unchecked((ReadByte() << 24) | (ReadByte() << 16) | (ReadByte() << 8) | ReadByte());
        }

        public uint ReadUInt()
        {
            return (uint) unchecked((ReadByte() << 24) | (ReadByte() << 16) | (ReadByte() << 8) | ReadByte());
        }

        public long ReadLong()
        {
            return unchecked((ReadByte() << 56) | (ReadByte() << 48) | (ReadByte() << 40) | (ReadByte() << 32)
                             | (ReadByte() << 24) | (ReadByte() << 16) | (ReadByte() << 8) | ReadByte());
        }

        public ulong ReadULong()
        {
            return (ulong) unchecked((ReadByte() << 56) | (ReadByte() << 48) | (ReadByte() << 40) | (ReadByte() << 32)
                                     | (ReadByte() << 24) | (ReadByte() << 16) | (ReadByte() << 8) | ReadByte());
        }

        protected byte[] ReadBytes(int size)
        {
            var result = new byte[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = (byte) FileHeader.ReadByte();
            }

            return result;
        }
    }

    public interface IReader<out T>
    {
        T ReadHeader();
    }
}
