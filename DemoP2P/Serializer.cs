using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Compression;

namespace DemoP2P
{
    class Serializer
    {
        public static byte[] Serialize<T>(T data) where T:class
        {
            using (var ms = new MemoryStream())
            {
                using (var ds = new DeflateStream(ms, CompressionMode.Compress))
                {
                    var bf = new BinaryFormatter();
                    bf.Serialize(ds, data);
                }
                return ms.GetBuffer();
            }
        }

        public static T Deserialize<T>(byte[] data) where T:class
        {
            using (var ms = new MemoryStream(data))
            {
                using (var ds = new DeflateStream(ms, CompressionMode.Decompress))
                {
                    var bf = new BinaryFormatter();
                    return bf.Deserialize(ds) as T;
                }
            }
        }
    }
}
