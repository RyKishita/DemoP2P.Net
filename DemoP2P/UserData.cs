using System;

namespace DemoP2P
{
    [Serializable]
    class UserData : IEquatable<UserData>, ICloneable
    {
        public UserData()
        {

        }

        public UserData(UserData src)
        {
            this.DisplayName = src.DisplayName;
            this.Flag1 = src.Flag1;
            this.Flag2 = src.Flag2;
        }

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

        public override bool Equals(object obj)
        {
            return Equals(obj as UserData);
        }

        public bool Equals(UserData other)
        {
            if (other == null) return false;
            if (object.ReferenceEquals(this, other)) return true;

            return this.DisplayName == other.DisplayName &&
                    this.Flag1 == other.Flag1 &&
                    this.Flag2 == other.Flag2;
        }

        public object Clone()
        {
            return new UserData(this);
        }
    }
}
