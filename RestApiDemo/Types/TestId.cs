using Newtonsoft.Json;
using RestApiDemo.Serialization;

namespace RestApiDemo.Types
{
    [StrongValueType(typeof(int))]
    [JsonConverter(typeof(StrongValueTypeJsonConverter))]
    public struct TestId : System.IEquatable<TestId>, System.IComparable<TestId>, System.IComparable
    { 
        public TestId(int value)
        {
            _value = value;
        }

        public bool Equals(TestId other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is TestId && Equals((TestId)obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public int CompareTo(TestId other)
        {
            return System.Collections.Generic.Comparer<int>.Default.Compare(_value, other._value);
        }

        int System.IComparable.CompareTo(object obj)
        {
            if (obj is TestId)
            {
                return CompareTo((TestId)obj);
            }

            throw new System.ArgumentException("Incorrect type.", nameof(obj));
        }

        public static explicit operator int(TestId value)
        {
            return value._value;
        }

        public static explicit operator TestId(int value)
        {
            return new TestId(value);
        }

        public static bool operator ==(TestId lhs, TestId rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(TestId lhs, TestId rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator <(TestId lhs, TestId rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >(TestId lhs, TestId rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <=(TestId lhs, TestId rhs)
        {
            return !(lhs > rhs);
        }

        public static bool operator >=(TestId lhs, TestId rhs)
        {
            return !(lhs < rhs);
        }

        [JsonProperty("value")]
        private readonly int _value;
    }
}
