using System.IO;
using DynaStudios.DPCFLib.Solutions;
using DynaStudios.DPCFLib.Util;

namespace DynaStudios.DPCFLib.Format.Reader
{
    public class DPCFHeaderReader : IReader<DPCFFileHeader>
    {
        private readonly EndianBinaryReader _reader;

        public DPCFHeaderReader(FileStream fileHeaderBytes)
        {
            _reader = new EndianBinaryReader(new LittleEndianBitConverter(), fileHeaderBytes);
        }

        public void InitReader(byte[] fileHeaderBytes)
        {
            
        }

        public DPCFFileHeader ReadHeader()
        {

            DPCFFileHeader header = new DPCFFileHeader();

            header.Version = _reader.ReadInt16();
            header.HashedFileHeaderSize = _reader.ReadUInt32();
            header.HashedFileHeaders = ReadHashedFileHeaders(header.HashedFileHeaderSize);
            header.HFHHash = _reader.ReadBytes(16);
            header.IndexDictionarySize = _reader.ReadUInt32();
            header.IndexDictionaryLength = ReadIndexLength(header.IndexDictionarySize);
            header.IndexDictionary = ReadDictionary(header.IndexDictionaryLength);
            header.FileCreation = _reader.ReadInt64();
            header.FileChanged = _reader.ReadInt64();

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
                    result[i][j] = _reader.ReadByte();
                }
            }

            return result;
        }

        private uint[] ReadIndexLength(uint size)
        {
            uint[] result = new uint[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = _reader.ReadUInt32();
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
            result.Identifier = _reader.ReadUInt32();
            result.LocationIdentifier = _reader.ReadUInt32();
            result.FileHash = _reader.ReadBytes(16);
            result.CompressionMethod = (FileCompression)_reader.ReadInt16();
            result.UncompressedFileSize = _reader.ReadUInt64();
            result.CompressedFileSize = _reader.ReadUInt64();
            result.DataBlockOffset = _reader.ReadUInt32();

            return result;
        }
    }
}
