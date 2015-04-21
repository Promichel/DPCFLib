using System.IO;
using System.Xml.Serialization;

namespace DynaStudios.DPCFLib.Solutions
{
    public class ReadableSerializer<T> where T : class
    {
        public static MemoryStream Serialize(T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            var ms = new MemoryStream();
            serializer.Serialize(ms, data);
            return ms;
        }

        public static T Deserialize(Stream stream)
        {
            var serializer = new XmlSerializer(typeof (T));
            return serializer.Deserialize(stream) as T;
        }

        public static T LoadFromFile(string filepath)
        {
            T result;
            using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                result = Deserialize(fs);
            }
            return result;
        }

        public static void SaveToFile(T data, string filepath)
        {
            using (var stream = Serialize(data))
            {
                using (var fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                {
                    stream.WriteTo(fs);
                }
            }
        }
    }
}
