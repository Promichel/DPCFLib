using System;
using System.Xml.Serialization;

namespace DPCFLibraryTest.ReadableSerializerTests
{
    [Serializable]
    [XmlRoot("Test")]
    public class TestData
    {
        public string Data { get; set; }
    }
}
