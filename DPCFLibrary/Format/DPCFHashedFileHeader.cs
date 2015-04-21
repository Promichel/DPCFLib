namespace DynaStudios.DPCFLib.Format
{
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