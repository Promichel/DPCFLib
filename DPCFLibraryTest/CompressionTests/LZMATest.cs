using System.IO;
using DynaStudios.DPCFLib.Compression.LZMA;
using DynaStudios.DPCFLib.Util;
using NUnit.Framework;

namespace DPCFLibraryTest.CompressionTests
{
    [TestFixture]
    public class LZMATest
    {
        private HashCalculator _hashCalculator;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _hashCalculator = new HashCalculator();
        }

        private byte[] LoadTestfileIntoArray()
        {
            byte[] result;
            using (var fs = new FileStream(Path.Combine("TestFiles", "Document.txt"), FileMode.Open, FileAccess.Read))
            {
                result = new byte[fs.Length];
                fs.Read(result, 0, result.Length);
            }
            return result;
        }

        [Test]
        public void TestCompress()
        {
            var handler = new LZMAHandler();

            //Check if Testfile Exists
            Assert.IsTrue(File.Exists(Path.Combine("TestFiles", "Document.txt")));

            //Check source file md5 hash
            Assert.IsTrue(_hashCalculator.Calculate(LoadTestfileIntoArray()).Equals("A837D19BBBC7B115CCF217F2A303A37A"));

            using (var input = new FileStream(Path.Combine("TestFiles", "Document.txt"), FileMode.Open))
            {
                using (
                    var output = new FileStream(Path.Combine("TestFiles", "Document.lzma"), FileMode.Create,
                        FileAccess.Write))
                {
                    handler.CompressFile(input, output);
                }
            }

            Assert.IsTrue(File.Exists(Path.Combine("TestFiles", "Document.lzma")));
        }

        [Test]
        public void TestUncompress()
        {
            var handler = new LZMAHandler();

            TestCompress();

            using (var input = new FileStream(Path.Combine("TestFiles", "Document.lzma"), FileMode.Open))
            {
                using (
                    var output = new FileStream(Path.Combine("TestFiles", "Document_unz.txt"), FileMode.Create,
                        FileAccess.Write))
                {
                    handler.DecompressFile(input, output);
                }
            }

            TextReader txtReader = new StreamReader(Path.Combine("TestFiles", "Document_unz.txt"));
            var text = txtReader.ReadLine();
            Assert.NotNull(text);
            Assert.IsTrue(text.Equals("I'm a sample Text"));
        }
    }
}