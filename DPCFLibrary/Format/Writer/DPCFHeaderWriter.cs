using System.IO;
using DynaStudios.DPCFLib.Util;

namespace DynaStudios.DPCFLib.Format.Writer
{
    public class DPCFHeaderWriter : IWriter<DPCFFileHeader>
    {
        private readonly EndianBinaryWriter _writer;

        public DPCFHeaderWriter(Stream stream)
        {
            _writer = new EndianBinaryWriter(new LittleEndianBitConverter(), stream);
        }

        public void Write(DPCFFileHeader header)
        {
            _writer.Write(header.Version);
            _writer.Write(header.HashedFileHeaderSize);
            WriterFileHeader(header.HashedFileHeaders);
            _writer.Write(header.HFHHash);
            _writer.Write(header.IndexDictionarySize);
            Write(header.IndexDictionaryLength);
            Write(header.IndexDictionary);
            _writer.Write(header.FileCreation);
            _writer.Write(header.FileChanged);
        }

        private void WriterFileHeader(DPCFHashedFileHeader[] hashedFileHeaders)
        {
            foreach (var fileHeader in hashedFileHeaders)
            {
                _writer.Write(fileHeader.Identifier);
                _writer.Write(fileHeader.LocationIdentifier);
                _writer.Write(fileHeader.FileHash);
                _writer.Write((short)fileHeader.CompressionMethod);
                _writer.Write(fileHeader.UncompressedFileSize);
                _writer.Write(fileHeader.CompressedFileSize);
                _writer.Write(fileHeader.DataBlockOffset);
            }
        }

        private void Write(byte[][] array)
        {
            foreach (byte[] bytes in array)
            {
                foreach (var b in bytes)
                {
                    _writer.Write(b);
                }
            }
        }

        private void Write(uint[] array)
        {
            foreach (uint u in array)
            {
                _writer.Write(u);
            }
        }
    }
}