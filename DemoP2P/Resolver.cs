using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;

namespace DemoP2P
{
    class Resolver<T> : IDisposable where T : class, IEquatable<T>
    {
        public Resolver(PeerName peerName)
        {
            this.peerName = peerName;

            peerNameResolver = new PeerNameResolver();
            peerNameResolver.ResolveProgressChanged += pnr_ResolveProgressChanged;
            peerNameResolver.ResolveCompleted += pnr_ResolveCompleted;

            items = new Dictionary<string, T>();
        }

        PeerName peerName;
        PeerNameResolver peerNameResolver;
        Dictionary<string, T> items;

        // 引数：追加されたID
        public event Action<string> AddItem;

        // 引数：更新されたID
        public event Action<string> UpdatedItem;

        // 引数：削除されたID
        public event Action<string> DeletedItem;

        // 引数1：処理毎の識別ID(ResolveAsyncの戻り値)
        // 引数2：処理の進捗%
        public event Action<string, int> ProgressChanged;

        // 引数1：処理毎の識別ID(ResolveAsyncの戻り値)
        // 引数2：処理が中断されたならtrue
        public event Action<string, bool> Completed;

        public void Resolve()
        {
            var peerNameRecords = peerNameResolver.Resolve(peerName);

            foreach (PeerNameRecord peerNameRecord in peerNameRecords)
            {
                ReadRecord(peerNameRecord);
            }
            CheckDeleted(peerNameRecords);
        }

        // 戻り値：処理毎の識別ID(ProgressChanged,Completedイベントの識別)
        public string ResolveAsync()
        {
            string id = Guid.NewGuid().ToString();
            peerNameResolver.ResolveAsync(peerName, id);
            return id;
        }

        public T GetItem(string id)
        {
            lock (items)
            {
                return items.ContainsKey(id)
                    ? items[id]
                    : null;
            }
        }

        public List<string> GetIDs()
        {
            lock (items)
            {
                return items.Keys.Cast<string>().ToList();
            }
        }

        void pnr_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            if (ProgressChanged != null) ProgressChanged(e.UserState as string, e.ProgressPercentage);

            ReadRecord(e.PeerNameRecord);
        }

        void pnr_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            if (Completed != null) Completed(e.UserState as string, e.Cancelled);
            if (e.Cancelled) return;

            CheckDeleted(e.PeerNameRecordCollection);
        }

        static string GetID(PeerNameRecord peerNameRecord)
        {
            return peerNameRecord.Comment;
        }

        static T GetData(PeerNameRecord peerNameRecord)
        {
            return Serializer.Deserialize<T>(peerNameRecord.Data);
        }

        void ReadRecord(PeerNameRecord peerNameRecord)
        {
            string id = GetID(peerNameRecord);
            var loadData = GetData(peerNameRecord);

            var existItem = GetItem(id);
            if (existItem == null)
            {
                ExecuteAddItem(id, loadData);
            }
            else
            {
                if (existItem.Equals(loadData)) return;
                ExecuteUpdateItem(id, loadData);
            }
        }

        private void CheckDeleted(PeerNameRecordCollection peerNameRecords)
        {
            var existIDs = peerNameRecords.Select(pnr => GetID(pnr)).ToList();
            var deletedIDs = GetIDs().Where(id => !existIDs.Contains(id));
            foreach (string id in deletedIDs)
            {
                ExecuteDeleteItem(id);
            }
        }

        private void ExecuteAddItem(string id, T data)
        {
            lock (items)
            {
                items.Add(id, data);
            }
            if (AddItem != null) AddItem(id);
        }

        private void ExecuteUpdateItem(string id, T data)
        {
            lock (items)
            {
                items[id] = data;
            }
            if (UpdatedItem != null) UpdatedItem(id);
        }

        private void ExecuteDeleteItem(string id)
        {
            lock (items)
            {
                items.Remove(id);
            }
            if (DeletedItem != null) DeletedItem(id);
        }

        public void Dispose()
        {
            peerName = null;
        }
    }
}
