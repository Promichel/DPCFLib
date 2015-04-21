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

        #region Development Tests
        [Test]
        [Ignore]
        public void TestWriteToFile()
        {
            var testData = new TestData { Data = "test" };
            using (var stream = ReadableSerializer<TestData>.Serialize(testData))
            {
                stream.Seek(0, SeekOrigin.Begin);
                using (FileStream fs = new FileStream("test.config", FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fs);
                    fs.Flush();
                }
            }
        }
        #endregion

    }
}
