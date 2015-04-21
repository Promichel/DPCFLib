using System.Text;
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
            byte[] testString = Encoding.UTF8.GetBytes("Teststring");
            Assert.IsNotEmpty(testString);

            string hash = _hashCalculator.Calculate(testString);
            Assert.IsTrue(hash.Equals("0DE471A9016AD61D89970490DA698AC3"));
        }
    }
}
