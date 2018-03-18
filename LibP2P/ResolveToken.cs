using System;

namespace LibP2P
{
    /// <summary>
    /// 非同期の受信一回分の処理を識別するためのトークン
    /// ※ ネットワークには渡らない。自身の処理でのみ使用される。
    /// </summary>
    public class ResolveToken
    {
        public ResolveToken()
        {

        }

        /// <summary>
        /// 区別するために付けているだけで、P2Pの仕組み上必要なものではない
        /// </summary>
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
