using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoP2P
{
    [Serializable]
    class UserData
    {
        public string DisplayName { get; set; }
        public bool Flag1 { get; set; }
        public bool Flag2 { get; set; }

        public override string ToString()
        {
            return string.Format("DisplayName={0},Flag1={1},Flag2={2}", DisplayName, Flag1, Flag2);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
