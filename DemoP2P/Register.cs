using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;

namespace DemoP2P
{
    /// <summary>
    /// PeerNameRegistrationラッパー
    /// </summary>
    /// <typeparam name="T">処理対象データ</typeparam>
    class Register<T> : IDisposable where T : class, IEquatable<T>, ICloneable
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cloud">対象となるネットワーク</param>
        /// <param name="peerName">登録ピア名</param>
        /// <param name="portNo">ポート</param>
        public Register(Cloud cloud, PeerName peerName, int portNo)
        {
            peerNameRegistration = new PeerNameRegistration(peerName, portNo)
            {
                Cloud = cloud
            };
            MyID = Guid.NewGuid().ToString();
        }

        PeerNameRegistration peerNameRegistration;
        T oldData = null;

        /// <summary>
        /// 自分のID
        /// </summary>
        public string MyID
        {
            get { return peerNameRegistration.Comment; }
            private set { peerNameRegistration.Comment = value; }
        }

        /// <summary>
        /// データをセット
        /// </summary>
        /// <param name="data">データ</param>
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

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose()
        {
            peerNameRegistration.Stop();
            peerNameRegistration = null;
        }
    }
}
