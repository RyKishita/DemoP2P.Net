using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;

namespace DemoP2P
{
    class Register<T> : IDisposable where T : class, IEquatable<T>, ICloneable
    {
        public Register(Cloud cloud, PeerName peerName, int portNo, string userID)
        {
            peerNameRegistration = new PeerNameRegistration(peerName, portNo)
            {
                Cloud = cloud,
                Comment = userID
            };
        }

        PeerNameRegistration peerNameRegistration;
        T oldData = null;

        public void SetData(T data)
        {
            if (data == null) throw new ArgumentNullException("data");
            if (oldData != null && oldData.Equals(data)) return;

            peerNameRegistration.Data = Serializer.Serialize(data);
            if (peerNameRegistration.IsRegistered())
            {
                peerNameRegistration.Update();
            }
            else
            {
                peerNameRegistration.Start();
            }

            oldData = data.Clone() as T;
        }

        public void Dispose()
        {
            peerNameRegistration.Stop();
            peerNameRegistration = null;
        }
    }
}
