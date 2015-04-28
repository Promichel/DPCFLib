using DynaStudios.DPCFLib.Solutions;

namespace DynaStudios.DPCFLib.Format
{
    public struct DPCFHashedFileHeader
    {
        public uint Identifier; //4 bytes
        public uint LocationIdentifier; //4bytes
        public byte[] FileHash; //FileHashLength (fixed 16bytes)
        public FileCompression CompressionMethod; //2 bytes
        public ulong UncompressedFileSize; //8 bytes
        public ulong CompressedFileSize; //8 bytes
        public uint DataBlockOffset; //4 bytes

        //46 bytes fixed
    }
}