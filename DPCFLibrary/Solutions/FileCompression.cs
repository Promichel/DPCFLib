using System;

namespace DynaStudios.DPCFLib.Solutions
{
    [Serializable]
    public enum FileCompression : byte
    {
        Uncompressed = 0x00, 
        LZMA = 0x01, 
        Custom = 0x02
    }
}