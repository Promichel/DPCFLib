using System.IO;

namespace DynaStudios.DPCFLib.Compression.LZMA
{
    public interface ICompressionHandler
    {
        /// <summary>
        /// Compresses the given input stream with the underlying compression algorhytm and saves it to the output stream.
        /// </summary>
        /// <param name="input">Inputstream</param>
        /// <param name="output">Outputstream</param>
        /// <returns></returns>
        long CompressFile(FileStream input, FileStream output);

        /// <summary>
        /// Decompresses the given input stream with the underlying uncompression algorhytm and save it to the output stream.
        /// </summary>
        /// <param name="input">Inputstream</param>
        /// <param name="output">Outputstream</param>
        /// <returns></returns>
        long DecompressFile(FileStream input, FileStream output);
    }
}