using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoP2P
{
    /// <summary>
    /// 一回の処理を識別するためのトークン
    /// </summary>
    class ResolveToken
    {
        public ResolveToken()
        {
            ID = Guid.NewGuid().ToString();
        }

        public ResolveToken(object userstate)
        {
            ID = userstate as string;
        }

        public string ID { get; private set; }

        public override string ToString()
        {
            return ID;
        }
    }
}
