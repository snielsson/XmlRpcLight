using System;
using System.Collections;
using System.Collections.Generic;
using XmlRpcLight.Enums;
namespace XmlRpcLight.DataTypes {
    public class XmlRpcStruct : Dictionary<string, object> {

        public XmlRpcStruct() {
        }
        //public XmlRpcStruct(IEnumerable<KeyValuePair<string, object>> dictionary) : base(dictionary)
        //{

        //}
        //public XmlRpcStruct(IDictionary<string, object> dictionary): base(dictionary)
        //{

        //}

        public new void Add(string key, object value) {
           
            if (XmlRpcServiceInfo.GetXmlRpcType(value.GetType())
                == XmlRpcType.tInvalid) {
                throw new ArgumentException(String.Format(
                    "Type {0} cannot be mapped to an XML-RPC type", value.GetType()));
            }
            base.Add(key, value);
           
        }

        public new object this[string key] {
            get { return base[key]; }
            set {
                if (XmlRpcServiceInfo.GetXmlRpcType(value.GetType())
                    == XmlRpcType.tInvalid) {
                    throw new ArgumentException(String.Format(
                        "Type {0} cannot be mapped to an XML-RPC type", value.GetType()));
                }
                base[key] = value;
               
            }
        }

        public override bool Equals(Object obj) {
            if (obj.GetType() != typeof (XmlRpcStruct))
                return false;
            var xmlRpcStruct = (XmlRpcStruct) obj;
            if (Keys.Count != xmlRpcStruct.Count)
                return false;
            foreach (String key in Keys) {
                if (!xmlRpcStruct.ContainsKey(key))
                    return false;
                if (!this[key].Equals(xmlRpcStruct[key]))
                    return false;
            }
            return true;
        }

        public override int GetHashCode() {
            int hash = 0;
            foreach (object obj in Values) {
                hash ^= obj.GetHashCode();
            }
            return hash;
        }

        //public new IDictionaryEnumerator GetEnumerator() {
        //    return new Enumerator(_keys, _values);
        //}

        //public override ICollection Keys { get { return (ICollection)_keys; } }

        //public override void Remove(object key) {
        //    base.Remove(key);
        //    int idx = _keys.IndexOf((string)key);
        //    if (idx >= 0) {
        //        _keys.RemoveAt(idx);
        //        _values.RemoveAt(idx);
        //    }
        //}

        //public override ICollection Values { get { return (ICollection)_values; } }

        //private class Enumerator : IDictionaryEnumerator {
        //    private readonly IList<string> _keys;
        //    private readonly IList<object> _values;
        //    private int _index;

        //    public Enumerator(IList<string> keys, IList<object> values) {
        //        _keys = keys;
        //        _values = values;
        //        _index = -1;
        //    }

        //    public void Reset() {
        //        _index = -1;
        //    }

        //    public object Current {
        //        get {
        //            CheckIndex();
        //            return new DictionaryEntry(_keys[_index], _values[_index]);
        //        }
        //    }

        //    public bool MoveNext() {
        //        _index++;
        //        if (_index >= _keys.Count)
        //            return false;
        //        return true;
        //    }

        //    public DictionaryEntry Entry {
        //        get {
        //            CheckIndex();
        //            return new DictionaryEntry(_keys[_index], _values[_index]);
        //        }
        //    }

        //    public object Key {
        //        get {
        //            CheckIndex();
        //            return _keys[_index];
        //        }
        //    }

        //    public object Value {
        //        get {
        //            CheckIndex();
        //            return _values[_index];
        //        }
        //    }

        //    private void CheckIndex() {
        //        if (_index < 0 || _index >= _keys.Count) {
        //            throw new InvalidOperationException(
        //                "Enumeration has either not started or has already finished.");
        //        }
        //    }
        //}
    }
}