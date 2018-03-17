using System;

namespace DemoP2P
{
    [Serializable]
    class UserData
    {
        public UserData()
        {

        }

        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string DisplayName { get; set; }
        public bool Flag1 { get; set; }
        public bool Flag2 { get; set; }

        public override string ToString()
        {
            return $"{nameof(DisplayName)}={DisplayName},{nameof(Flag1)}={Flag1},{nameof(Flag2)}={Flag2}";
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

            return this.ID == other.ID;
        }
    }
}
