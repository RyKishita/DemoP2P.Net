using System;

namespace DemoP2P
{
    /// <summary>
    /// 一回の処理を識別するためのトークン
    /// ※ ネットワークには渡らない。自身の処理でのみ使用される。
    /// </summary>
    class ResolveToken
    {
        public ResolveToken()
        {

        }

        public string ID { get; private set; } = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return ID;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ResolveToken);
        }

        public bool Equals(ResolveToken other)
        {
            if (other == null) return false;
            if (object.ReferenceEquals(this, other)) return true;

            return this.ID == other.ID;
        }
    }
}
