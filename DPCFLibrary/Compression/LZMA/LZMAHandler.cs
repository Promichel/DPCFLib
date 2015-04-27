using System;
using System.IO;
using SevenZip.Sdk.Compression.Lzma;

namespace DynaStudios.DPCFLib.Compression.LZMA
{
    public class LZMAHandler : ICompressionHandler
    {
        public void CompressFile(FileStream inFile, FileStream outFile)
        {
            var coder = new Encoder();
            using (inFile)
            {
                using (outFile)
                {
                    // Write the encoder properties
                    coder.WriteCoderProperties(outFile);

                    // Write the decompressed file size.
                    outFile.Write(BitConverter.GetBytes(inFile.Length), 0, 8);

                    // Encode the file.
                    coder.Code(inFile, outFile, inFile.Length, -1, null);
                    outFile.Flush();
                    outFile.Close();
                }
            }
        }

        public void DecompressFile(FileStream inFile, FileStream outFile)
        {
            var coder = new Decoder();

            using (inFile)
            {
                using (outFile)
                {
                    // Read the decoder properties
                    var properties = new byte[5];
                    inFile.Read(properties, 0, 5);

                    // Read in the decompress file size.
                    var fileLengthBytes = new byte[8];
                    inFile.Read(fileLengthBytes, 0, 8);
                    var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

                    coder.SetDecoderProperties(properties);
                    coder.Code(inFile, outFile, inFile.Length, fileLength, null);
                    outFile.Flush();
                    outFile.Close();
                }
            }
        }
    }
}