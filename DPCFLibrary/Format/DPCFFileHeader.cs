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
}
