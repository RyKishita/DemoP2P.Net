using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.PeerToPeer;

namespace LibP2P
{
    /// <summary>
    /// 受信処理クラス
    /// </summary>
    /// <typeparam name="T">処理対象データ</typeparam>
    public class Resolver<T> : IDisposable where T : class
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cloud">対象となるネットワーク</param>
        /// <param name="peerName">登録ピア名</param>
        public Resolver(Cloud cloud, PeerName peerName)
        {
            this.cloud = cloud;
            this.peerName = peerName;

            peerNameResolver = new PeerNameResolver();
            peerNameResolver.ResolveProgressChanged += Pnr_ResolveProgressChanged;
            peerNameResolver.ResolveCompleted += Pnr_ResolveCompleted;
        }

        /// <summary>
        /// ResolveAsync処理の進捗イベント
        /// 引数1：処理毎の識別トークン。ResolveAsyncの戻り値
        /// 引数2：処理の進捗%
        /// 引数3：読み込まれたデータ
        /// </summary>
        public event Action<ResolveToken, int, PeerNodeData<T>> ProgressChanged;

        /// <summary>
        /// ResolveAsync処理の完了、または取り消し後のイベント
        /// 引数1：処理毎の識別トークン。ResolveAsyncの戻り値
        /// 引数2：読み込まれたデータとその送信元アドレス
        /// 引数3：処理が中断されて終了したならtrue
        /// </summary>
        public event Action<ResolveToken, IEnumerable<PeerNodeData<T>>, bool> Completed;

        /// <summary>
        /// ResolveAsync処理で例外が起きたら呼ばれるイベント
        /// 引数1：処理毎の識別トークン。ResolveAsyncの戻り値
        /// 引数2：例外
        /// </summary>
        public event Action<ResolveToken, Exception> CompletedException;

        /// <summary>
        /// 最新の情報を同期的に取得
        /// </summary>
        public IEnumerable<PeerNodeData<T>> Resolve()
        {
            if (null == peerNameResolver) throw new ObjectDisposedException(nameof(Resolver<T>));

            return GetDatas(peerNameResolver.Resolve(peerName, cloud));
        }

        /// <summary>
        /// 最新の情報を非同期で取得
        /// </summary>
        /// <returns>処理毎の識別トークン</returns>
        public ResolveToken ResolveAsync()
        {
            if (null == peerNameResolver) throw new ObjectDisposedException(nameof(Resolver<T>));

            var token = new ResolveToken();
            peerNameResolver.ResolveAsync(peerName, cloud, token);
            return token;
        }

        /// <summary>
        /// 非同期取得の取り消し
        /// </summary>
        /// <param name="token">処理毎の識別トークン。ResolveAsyncの戻り値</param>
        public void ResolveAsyncCancel(ResolveToken token)
        {
            if (null == peerNameResolver) throw new ObjectDisposedException(nameof(Resolver<T>));

            peerNameResolver.ResolveAsyncCancel(token);
        }

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose()
        {
            if (null == peerNameResolver) return;

            peerNameResolver.ResolveProgressChanged -= Pnr_ResolveProgressChanged;
            peerNameResolver.ResolveCompleted -= Pnr_ResolveCompleted;
            peerNameResolver = null;
        }

        #region private

        private Cloud cloud;
        private PeerName peerName;
        private PeerNameResolver peerNameResolver;

        private void Pnr_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(e.UserState as ResolveToken, e.ProgressPercentage, new PeerNodeData<T>(e.PeerNameRecord));
        }

        private void Pnr_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            var token = e.UserState as ResolveToken;

            if (null != e.Error)
            {
                CompletedException?.Invoke(token, e.Error);
            }

            Completed?.Invoke(token, GetDatas(e.PeerNameRecordCollection), e.Cancelled);
        }

        private static IEnumerable<PeerNodeData<T>> GetDatas(PeerNameRecordCollection peerNameRecords)
        {
            return peerNameRecords.Select(record => new PeerNodeData<T>(record));
        }

        #endregion
    }
}
