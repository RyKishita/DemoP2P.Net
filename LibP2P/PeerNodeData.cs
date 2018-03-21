using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace LibP2P
{
    public class PeerNodeData<T> where T : class
    {
        public PeerNodeData(PeerNameRecord peerNameRecord)
        {
            this.peerNameRecord = peerNameRecord;
            Data = Serializer.Deserialize<T>(peerNameRecord.Data);
        }

        PeerNameRecord peerNameRecord;

        public T Data { get; private set; }

        public string Comment => peerNameRecord.Comment;

        public IPEndPoint EndPointIPv4 => GetEndPoint(AddressFamily.InterNetwork);

        public IPEndPoint EndPointIPv6 => GetEndPoint(AddressFamily.InterNetworkV6);

        public IPEndPoint GetEndPoint(AddressFamily addressFamily)
        {
            return peerNameRecord.EndPointCollection.FirstOrDefault(endPoint => endPoint.AddressFamily == addressFamily);
        }
    }
}
