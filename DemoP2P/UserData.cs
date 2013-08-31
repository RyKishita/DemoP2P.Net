using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DemoP2P
{
    [Serializable]
    class UserData
    {
        public string DisplayName { get; set; }
        public bool Flag1 { get; set; }
        public bool Flag2 { get; set; }

        public override string ToString()
        {
            return string.Format("DisplayName={0},Flag1={1},Flag2={2}", DisplayName, Flag1, Flag2);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public byte[] Serialize()
        {
            using (var ms = new MemoryStream())
            {
                using (var ds = new DeflateStream(ms, System.IO.Compression.CompressionMode.Compress))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ds, this);
                }
                return ms.GetBuffer();
            }
        }

        public static UserData Deserialize(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                using (var ds = new DeflateStream(ms, System.IO.Compression.CompressionMode.Decompress))
                {
                    var formatter = new BinaryFormatter();
                    return formatter.Deserialize(ds) as UserData;
                }
            }
        }
    }
}
