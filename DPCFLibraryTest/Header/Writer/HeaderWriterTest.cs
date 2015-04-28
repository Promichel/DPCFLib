using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using DynaStudios.DPCFLib.Format;
using DynaStudios.DPCFLib.Format.Reader;
using DynaStudios.DPCFLib.Format.Writer;
using DynaStudios.DPCFLib.Solutions;
using DynaStudios.DPCFLib.Util;
using NUnit.Framework;

namespace DPCFLibraryTest.Header.Writer
{
    [TestFixture]
    public class HeaderWriterTest
    {

        [Test]
        public void WriteHeader()
        {
            using (var fileStream = new FileStream(Path.Combine("TestFiles", "binary.dpcf"), FileMode.Create, FileAccess.Write))
            {
                var writer = new DPCFHeaderWriter(fileStream);

                var header = new DPCFFileHeader
                {
                    Version = 2,
                    HashedFileHeaderSize = 4
                };
                var headers = new DPCFHashedFileHeader[4];
                var hashCalc = new HashCalculator();
                headers[0] = new DPCFHashedFileHeader
                {
                    Identifier = 1,
                    LocationIdentifier = 1,
                    FileHash = hashCalc.CalculateAsByte(Encoding.UTF8.GetBytes("Test1")),
                    CompressionMethod = FileCompression.Custom,
                    UncompressedFileSize = 111,
                    CompressedFileSize = 111,
                    DataBlockOffset = 111
                };
                headers[1] = new DPCFHashedFileHeader
                {
                    Identifier = 2,
                    LocationIdentifier = 2,
                    FileHash = hashCalc.CalculateAsByte(Encoding.UTF8.GetBytes("Test2")),
                    CompressionMethod = FileCompression.LZMA,
                    UncompressedFileSize = 222,
                    CompressedFileSize = 222,
                    DataBlockOffset = 222
                };
                headers[2] = new DPCFHashedFileHeader
                {
                    Identifier = 3,
                    LocationIdentifier = 3,
                    FileHash = hashCalc.CalculateAsByte(Encoding.UTF8.GetBytes("Test3")),
                    CompressionMethod = FileCompression.Uncompressed,
                    UncompressedFileSize = 333,
                    CompressedFileSize = 333,
                    DataBlockOffset = 333
                };
                headers[3] = new DPCFHashedFileHeader
                {
                    Identifier = 4,
                    LocationIdentifier = 4,
                    FileHash = hashCalc.CalculateAsByte(Encoding.UTF8.GetBytes("Test4")),
                    CompressionMethod = FileCompression.Custom,
                    UncompressedFileSize = 444,
                    CompressedFileSize = 444,
                    DataBlockOffset = 444
                };
                header.HashedFileHeaders = headers;
                header.HFHHash = hashCalc.CalculateAsByte(Encoding.UTF8.GetBytes("Hello World"));

                header.IndexDictionarySize = 2;
                byte[] hello = Encoding.UTF8.GetBytes("Hello");
                byte[] world = Encoding.UTF8.GetBytes("World");
                uint[] arrLength = new uint[2];
                arrLength[0] = (uint) hello.Length;
                arrLength[1] = (uint) world.Length;

                header.IndexDictionaryLength = arrLength;

                byte[][] dictionary = new byte[arrLength.Length][];
                dictionary[0] = hello;
                dictionary[1] = world;
                header.IndexDictionary = dictionary;

                header.FileCreation = new DateTime(2015, 12, 11).Ticks;
                header.FileChanged = new DateTime(2015, 12, 11).Ticks;

                writer.Write(header);
            }      
        }

        [Test]
        public void TestRead()
        {
            WriteHeader();

            DPCFFileHeader dpcfFileHeader;
            using (var file = new FileStream(Path.Combine("TestFiles", "binary.dpcf"), FileMode.Open, FileAccess.Read))
            {   
                var reader = new DPCFHeaderReader(file);
                dpcfFileHeader = reader.ReadHeader();
            }

            Assert.NotNull(dpcfFileHeader);
            Assert.IsTrue(dpcfFileHeader.Version == 2);
            Assert.IsTrue(dpcfFileHeader.HashedFileHeaderSize == 4);
            Assert.IsTrue(dpcfFileHeader.HashedFileHeaders.Length == 4);

            var fileHeader = dpcfFileHeader.HashedFileHeaders[0];
            Assert.NotNull(fileHeader);
            Assert.IsTrue(fileHeader.Identifier == 1);
            Assert.IsTrue(fileHeader.LocationIdentifier == 1);

            DateTime creation = new DateTime(dpcfFileHeader.FileCreation);
            DateTime changed = new DateTime(dpcfFileHeader.FileChanged);

            var hashCalculator = new HashCalculator();
            var testHash = hashCalculator.Calculate(Encoding.UTF8.GetBytes("Test1"));
            Assert.IsTrue(HashCalculator.ProvideMd5ByteArrayAsString(fileHeader.FileHash).Equals(testHash));
            Assert.IsTrue(fileHeader.Identifier == 1);
            Assert.IsTrue(fileHeader.DataBlockOffset == 111);

        }

    }
}
