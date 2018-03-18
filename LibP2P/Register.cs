using System;
using System.Net.PeerToPeer;

namespace LibP2P
{
    /// <summary>
    /// 送信処理クラス
    /// </summary>
    /// <typeparam name="T">処理対象データ</typeparam>
    public class Register<T> : IDisposable where T : class
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cloud">対象となるネットワーク</param>
        /// <param name="peerName">登録ピア名</param>
        /// <param name="portNo">ポート</param>
        public Register(Cloud cloud, PeerName peerName, int portNo)
        {
            this.cloud = cloud;
            this.peerName = peerName;
            this.portNo = portNo;
        }

        /// <summary>
        /// データを登録
        /// </summary>
        /// <param name="data">データ</param>
        public void RegistData(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            if (null == peerNameRegistration)
            {
                peerNameRegistration = new PeerNameRegistration(peerName, portNo, cloud);
            }

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

            peerNameRegistration.Dispose();
            peerNameRegistration = null;
        }

        #region private

        private Cloud cloud;
        private PeerName peerName;
        private int portNo;
        private PeerNameRegistration peerNameRegistration = null;

        #endregion
    }
}
