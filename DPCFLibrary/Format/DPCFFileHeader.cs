namespace DynaStudios.DPCFLib.Format
{
    public struct DPCFFileHeader
    {
        public short Version; //2 bytes

        public uint HashedFileHeaderSize; //4 bytes
        public DPCFHashedFileHeader[] HashedFileHeaders; //HashedFileHeaderSize * 46 bytes

        public byte[] HFHHash; //16 bytes

        public uint IndexDictionarySize; //4 bytes
        public uint[] IndexDictionaryLength; //IndexDictionarySize * 4 bytes
        public byte[][] IndexDictionary; //Index DictionarySize * IndexDictionaryLenght[index] * 

        public long FileCreation; //8 bytes
        public long FileChanged; //8 bytes
    }
}
