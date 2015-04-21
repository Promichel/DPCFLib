using System.IO;
using System.Runtime.Serialization;

namespace DynaStudios.DPCFLib.Solutions
{
    public class ReadableSerializer<T> where T : class
    {
        public static MemoryStream Serialize(T data)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var ms = new MemoryStream();
            serializer.WriteObject(ms, data);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static T Deserialize(Stream stream)
        {
            var serializer = new DataContractSerializer(typeof(T));
            return serializer.ReadObject(stream) as T;
        }

    }
}
