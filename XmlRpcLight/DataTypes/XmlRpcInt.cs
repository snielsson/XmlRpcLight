namespace XmlRpcLight.DataTypes {
    public class XmlRpcInt {
        private readonly int _value;

        public XmlRpcInt() {
        }

        public XmlRpcInt(int val) {
            _value = val;
        }

        public override string ToString() {
            return _value.ToString();
        }

        public override int GetHashCode() {
            return _value.GetHashCode();
        }

        public override bool Equals(
            object o) {
            if (o == null || !(o is XmlRpcInt))
                return false;
            var dbl = o as XmlRpcInt;
            return (dbl._value == _value);
        }

        public static bool operator ==(
            XmlRpcInt xi,
            XmlRpcInt xj) {
            if (((object) xi) == null && ((object) xj) == null)
                return true;
            if (((object) xi) == null || ((object) xj) == null)
                return false;
            return xi._value == xj._value;
        }

        public static bool operator !=(
            XmlRpcInt xi,
            XmlRpcInt xj) {
            return !(xi == xj);
        }

        public static implicit operator int(XmlRpcInt x) {
            return x._value;
        }

        public static implicit operator XmlRpcInt(int x) {
            return new XmlRpcInt(x);
        }
    }
}