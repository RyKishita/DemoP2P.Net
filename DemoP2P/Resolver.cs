using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer;

namespace DemoP2P
{
    /// <summary>
    /// PeerNameResolverラッパー
    /// </summary>
    /// <typeparam name="T">処理対象データ</typeparam>
    class Resolver<T> : IDisposable where T : class
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
            Setup();
        }

        private Cloud cloud;
        private PeerName peerName;
        private PeerNameResolver peerNameResolver = null;

        /// <summary>
        /// ResolveAsync処理の進捗イベント
        /// 引数1：処理毎の識別トークン。ResolveAsyncの戻り値
        /// 引数2：処理の進捗%
        /// 引数3：読み込まれたデータ
        /// </summary>
        public event Action<ResolveToken, int, T> ProgressChanged;

        /// <summary>
        /// ResolveAsync処理の完了、または取り消し後のイベント
        /// 引数1：処理毎の識別トークン。ResolveAsyncの戻り値
        /// 引数2：読み込まれた全てのデータ
        /// 引数3：処理が中断されて終了したならtrue
        /// </summary>
        public event Action<ResolveToken, IEnumerable<T>, bool> Completed;

        /// <summary>
        /// 最新の情報を同期的に取得
        /// </summary>
        public IEnumerable<T> Resolve()
        {
            return GetDatas(peerNameResolver.Resolve(peerName, cloud));
        }

        /// <summary>
        /// 最新の情報を非同期で取得
        /// </summary>
        /// <returns>処理毎の識別トークン</returns>
        public ResolveToken ResolveAsync()
        {
            var token = new ResolveToken();
            peerNameResolver.ResolveAsync(peerName, cloud, token.ID);
            return token;
        }

        /// <summary>
        /// 非同期取得の取り消し
        /// </summary>
        /// <param name="token">処理毎の識別トークン。ResolveAsyncの戻り値</param>
        public void ResolveAsyncCancel(ResolveToken token)
        {
            peerNameResolver.ResolveAsyncCancel(token.ID);
        }

        private void Pnr_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(new ResolveToken(e.UserState), e.ProgressPercentage, GetData(e.PeerNameRecord));
        }

        private void Pnr_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            Completed?.Invoke(new ResolveToken(e.UserState), GetDatas(e.PeerNameRecordCollection), e.Cancelled);
        }

        static T GetData(PeerNameRecord peerNameRecord)
        {
            return Serializer.Deserialize<T>(peerNameRecord.Data);
        }

        static IEnumerable<T> GetDatas(PeerNameRecordCollection peerNameRecords)
        {
            return peerNameRecords.Select(record => GetData(record));
        }

        private void Setup()
        {
            Dispose();

            peerNameResolver = new PeerNameResolver();
            peerNameResolver.ResolveProgressChanged += Pnr_ResolveProgressChanged;
            peerNameResolver.ResolveCompleted += Pnr_ResolveCompleted;
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
    }
}
