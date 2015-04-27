using System.IO;

namespace DynaStudios.DPCFLib.Compression.LZMA
{
    public interface ICompressionHandler
    {
        void CompressFile(FileStream input, FileStream output);

        void DecompressFile(FileStream input, FileStream output);
    }
}