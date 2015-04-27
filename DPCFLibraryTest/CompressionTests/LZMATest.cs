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
            //Assert.IsTrue(_hashCalculator.Calculate(LoadTestfileIntoArray()).Equals("a837d19bbbc7b115ccf217f2a303a37a"));

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
    }
}