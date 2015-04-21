using System.IO;
using DynaStudios.DPCFLib.Util;
using NUnit.Framework;

namespace DPCFLibraryTest
{
    [TestFixture]
    public class HashCalculatorTest
    {
        private HashCalculator _hashCalculator;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _hashCalculator = new HashCalculator();
        }

        [Test]
        public void CalculateMd5ChecksumTest()
        {
            byte[] testFile = LoadTestfileIntoArray();
            Assert.IsNotEmpty(testFile);

            string hash = _hashCalculator.Calculate(testFile);
            Assert.IsTrue(hash.Equals("02C1E93316160F9B6AD6B7CC115186C1"));
        }

        #region Methods to Load Testfiles

        private byte[] LoadTestfileIntoArray()
        {
            byte[] result;
            using (var fs = new FileStream(Path.Combine("TestFiles", "Sample.txt"), FileMode.Open, FileAccess.Read))
            {
                result = new byte[fs.Length];
                fs.Read(result, 0, result.Length);
            }
            return result;
        }

        #endregion
    }
}
