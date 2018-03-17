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
    class Resolver<T> : IDisposable where T : class, IEquatable<T>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="peerName">登録ピア名</param>
        public Resolver(PeerName peerName)
        {
            this.peerName = peerName;

            peerNameResolver.ResolveProgressChanged += Pnr_ResolveProgressChanged;
            peerNameResolver.ResolveCompleted += Pnr_ResolveCompleted;
        }

        private PeerName peerName;
        private PeerNameResolver peerNameResolver = new PeerNameResolver();
        private Dictionary<string, T> items = new Dictionary<string, T>();

        /// <summary>
        /// 新しいノードが追加された時のイベント
        /// 引数：追加された項目のID
        /// </summary>
        public event Action<string> AddNode;

        /// <summary>
        /// ノードが持つデータが更新された時のイベント
        /// 引数：更新された項目のID
        /// </summary>
        public event Action<string> UpdateNodeData;

        /// <summary>
        /// ノードが削除された時のイベント
        /// 引数1：削除された項目のID
        /// 引数2：削除された項目
        /// </summary>
        public event Action<string, T> DeleteNode;

        /// <summary>
        /// ResolveAsync処理の進捗イベント
        /// 引数1：処理毎の識別ID(ResolveAsyncの戻り値)
        /// 引数2：処理の進捗%
        /// </summary>
        public event Action<string, int> ProgressChanged;

        /// <summary>
        /// ResolveAsync処理の完了、または取り消し後のイベント
        /// 引数1：処理毎の識別ID(ResolveAsyncの戻り値)
        /// 引数2：処理が中断されたならtrue
        /// </summary>
        public event Action<string, bool> Completed;

        /// <summary>
        /// 最新の情報を取得
        /// </summary>
        public void Resolve()
        {
            var peerNameRecords = peerNameResolver.Resolve(peerName);

            foreach (PeerNameRecord peerNameRecord in peerNameRecords)
            {
                ReadRecord(peerNameRecord);
            }
            CheckDeleted(peerNameRecords);
        }

        /// <summary>
        /// 最新の情報を非同期で取得
        /// </summary>
        /// <returns>処理毎の識別ID</returns>
        public string ResolveAsync()
        {
            string id = Guid.NewGuid().ToString();
            peerNameResolver.ResolveAsync(peerName, id);
            return id;
        }

        /// <summary>
        /// 非同期取得の取り消し
        /// </summary>
        /// <param name="id">処理毎の識別ID(ResolveAsyncの戻り値)</param>
        public void ResolveAsyncCancel(string id)
        {
            peerNameResolver.ResolveAsyncCancel(id);
        }

        /// <summary>
        /// 項目の情報を取得
        /// </summary>
        /// <param name="id">項目のID</param>
        /// <returns>情報。無ければnullを返す</returns>
        public T GetItemData(string id)
        {
            lock (items)
            {
                return items.ContainsKey(id)
                    ? items[id]
                    : null;
            }
        }

        /// <summary>
        /// 現在保持している項目全てのIDを取得
        /// </summary>
        /// <returns>項目ID群</returns>
        public List<string> GetIDs()
        {
            lock (items)
            {
                return items.Keys.Cast<string>().ToList();
            }
        }

        private void Pnr_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(e.UserState as string, e.ProgressPercentage);

            ReadRecord(e.PeerNameRecord);
        }

        private void Pnr_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                CheckDeleted(e.PeerNameRecordCollection);
            }
            Completed?.Invoke(e.UserState as string, e.Cancelled);
        }

        static string GetUserID(PeerNameRecord peerNameRecord)
        {
            return peerNameRecord.Comment;
        }

        static T GetData(PeerNameRecord peerNameRecord)
        {
            return Serializer.Deserialize<T>(peerNameRecord.Data);
        }

        void ReadRecord(PeerNameRecord peerNameRecord)
        {
            string id = GetUserID(peerNameRecord);
            var loadData = GetData(peerNameRecord);

            var existItem = GetItemData(id);
            if (existItem == null)
            {
                OnAddNode(id, loadData);
            }
            else
            {
                if (existItem.Equals(loadData)) return;
                OnUpdateNodeData(id, loadData);
            }
        }

        private void CheckDeleted(PeerNameRecordCollection peerNameRecords)
        {
            var existIDs = peerNameRecords.Select(pnr => GetUserID(pnr)).ToList();
            var deletedIDs = GetIDs().Where(id => !existIDs.Contains(id));
            foreach (string id in deletedIDs)
            {
                OnDeleteNode(id);
            }
        }

        private void OnAddNode(string id, T data)
        {
            lock (items)
            {
                items.Add(id, data);
            }
            AddNode?.Invoke(id);
        }

        private void OnUpdateNodeData(string id, T data)
        {
            lock (items)
            {
                items[id] = data;
            }
            UpdateNodeData?.Invoke(id);
        }

        private void OnDeleteNode(string id)
        {
            var item = GetItemData(id);
            if (item != null)
            {
                lock (items)
                {
                    items.Remove(id);
                }
            }
            DeleteNode?.Invoke(id, item);
        }

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose()
        {
            if (null != peerNameResolver)
            {
                peerNameResolver.ResolveProgressChanged -= Pnr_ResolveProgressChanged;
                peerNameResolver.ResolveCompleted -= Pnr_ResolveCompleted;
                peerNameResolver = null;
            }
            peerName = null;
        }
    }
}
