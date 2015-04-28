using System.IO;

namespace DynaStudios.DPCFLib.Format.Writer
{
    public class DPCFHeaderWriter : AbstractByteWriter, IWriter<DPCFFileHeader>
    {
        public DPCFHeaderWriter(Stream stream) : base(stream)
        {
            
        }

        public void Write(DPCFFileHeader header)
        {
            Write(header.Version);
            Write(header.HashedFileHeaderSize);
            Write(header.HashedFileHeaders);
            Write(header.HFHHash);
            Write(header.IndexDictionarySize);
            Write(header.IndexDictionaryLength);
            Write(header.IndexDictionary);
            Write(header.FileCreation);
            Write(header.FileChanged);
        }

        private void Write(byte[][] array)
        {
            foreach (byte[] bytes in array)
            {
                foreach (var b in bytes)
                {
                    Write(b);
                }
            }
        }

        private void Write(uint[] array)
        {
            foreach (uint u in array)
            {
                Write(u);
            }
        }

        private void Write(DPCFHashedFileHeader[] hashedFileHeaders)
        {
            foreach (var fileHeader in hashedFileHeaders)
            {
                Write(fileHeader.Identifier);
                Write(fileHeader.LocationIdentifier);
                Write(fileHeader.FileHash);
                Write((short)fileHeader.CompressionMethod);
                Write(fileHeader.UncompressedFileSize);
                Write(fileHeader.CompressedFileSize);
                Write(fileHeader.DataBlockOffset);
            }
        }
    }
}