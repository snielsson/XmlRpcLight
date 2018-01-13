namespace XmlRpcLight.DataTypes {
    public class XmlRpcDouble {
        private readonly double _value;

        public XmlRpcDouble() {
        }

        public XmlRpcDouble(
            double val) {
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
            if (o == null || !(o is XmlRpcDouble))
                return false;
            var dbl = o as XmlRpcDouble;
            return dbl._value == _value;
        }

        public static bool operator ==(
            XmlRpcDouble xi,
            XmlRpcDouble xj) {
            if (((object) xi) == null && ((object) xj) == null)
                return true;
            if (((object) xi) == null || ((object) xj) == null)
                return false;
            return xi._value == xj._value;
        }

        public static bool operator !=(
            XmlRpcDouble xi,
            XmlRpcDouble xj) {
            return !(xi == xj);
        }

        public static implicit operator double(XmlRpcDouble x) {
            return x._value;
        }

        public static implicit operator XmlRpcDouble(double x) {
            return new XmlRpcDouble(x);
        }
    }
}