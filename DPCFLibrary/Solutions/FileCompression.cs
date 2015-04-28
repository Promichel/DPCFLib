using System;

namespace DynaStudios.DPCFLib.Solutions
{
    [Serializable]
    public enum FileCompression : short
    {
        Uncompressed = 0, 
        LZMA = 1, 
        Custom = 2
    }
}