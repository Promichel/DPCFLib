using System.IO;
using DynaStudios.DPCFLib.Solutions;
using NUnit.Framework;

namespace DPCFLibraryTest.ReadableSerializerTests
{
    [TestFixture]
    public class ReadableSerializerTest
    {
        [Test]
        public void Serialize()
        {
            var testData = new TestData {Data = "test"};
            var result = ReadableSerializer<TestData>.Serialize(testData);
            Assert.NotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [Test]
        public void Deserialize()
        {
            var testData = new TestData {Data = "test"};
            using (var stream = ReadableSerializer<TestData>.Serialize(testData))
            {
                stream.Seek(0, SeekOrigin.Begin);
                var result = ReadableSerializer<TestData>.Deserialize(stream);
                Assert.NotNull(result);
                Assert.IsTrue(result.Data.Equals("test"));
            }
        }

        [Test]
        public void DeserializeWithTextReader()
        {
            using (var txtReader = new StringReader("<Test><Data>test</Data></Test>"))
            {
                var result = ReadableSerializer<TestData>.Deserialize(txtReader);
                Assert.NotNull(result);
                Assert.IsTrue(result.Data.Equals("test"));
            }
        }
    }
}
