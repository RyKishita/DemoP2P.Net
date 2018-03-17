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
    class Register<T> : IDisposable where T : class
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cloud">対象となるネットワーク</param>
        /// <param name="peerName">登録ピア名</param>
        /// <param name="portNo">ポート</param>
        public Register(Cloud cloud, PeerName peerName, int portNo)
        {
            peerNameRegistration = new PeerNameRegistration(peerName, portNo) { Cloud = cloud };
        }

        private PeerNameRegistration peerNameRegistration;

        /// <summary>
        /// データを登録
        /// </summary>
        /// <param name="data">データ</param>
        public void RegistData(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            peerNameRegistration.Data = Serializer.Serialize(data);
            if (peerNameRegistration.IsRegistered())
            {
                peerNameRegistration.Update();
            }
            else
            {
                peerNameRegistration.Start();
            }
        }

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose()
        {
            if (null == peerNameRegistration) return;
            peerNameRegistration.Stop();
            peerNameRegistration = null;
        }
    }
}
