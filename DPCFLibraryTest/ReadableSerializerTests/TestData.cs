using System;
using System.Runtime.Serialization;

namespace DPCFLibraryTest.ReadableSerializerTests
{
    [Serializable]
    [DataContract(Name = "Test")]
    public class TestData
    {
        [DataMember]
        public string Data { get; set; }
    }
}
