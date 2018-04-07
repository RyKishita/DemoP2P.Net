using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Compression;

namespace LibP2P
{
    /// <summary>
    /// 製品版では暗号化する必要があるだろうが割愛
    /// </summary>
    class Serializer
    {
        public static byte[] Serialize<T>(T data) where T : class
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

        public static T Deserialize<T>(byte[] data) where T : class
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
