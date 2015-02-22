using System;
namespace XmlRpcLight.Attributes {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class XmlRpcUrlAttribute : Attribute {
        public XmlRpcUrlAttribute(string UriString) {
            uri = UriString;
        }
        public string Uri { get { return uri; } }
        public override string ToString() {
            string value = "Uri : " + uri;
            return value;
        }
        private readonly string uri;
    }
}