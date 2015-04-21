using System.Runtime.InteropServices;

namespace DynaStudios.DPCFLib.Format
{
    public struct DPCFFileHeader
    {
        public short Version;

        public uint HashedFileHeaderSize;
        public DPCFHashedFileHeader[] HashedFileHeaders;

        public ushort HFHHashLength;
        public byte[] HFHHash;

        public uint IndexDictionarySize;
        public uint[] IndexDictionaryLength;
        public byte[][] IndexDictionary;

        public ulong FileCreation;
        public ulong FileChanged;
    }

    public struct DPCFHashedFileHeader
    {
        public uint Identifier;
        public uint LocationIdentifier;
        public byte[] FileHash;
        public short CompressionMethod;
        public ulong UncompressedFileSize;
        public ulong CompressedFileSize;
        public uint DataBlockOffset;
    }
}
