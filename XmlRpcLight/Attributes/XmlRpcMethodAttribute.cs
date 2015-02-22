using System;
namespace XmlRpcLight.Attributes {
    [AttributeUsage(AttributeTargets.Method)]
    public class XmlRpcMethodAttribute : Attribute {
        public XmlRpcMethodAttribute() {
            StructParams = false;
            IntrospectionMethod = false;
        }
        public XmlRpcMethodAttribute(string method) {
            StructParams = false;
            IntrospectionMethod = false;
            this.method = method;
        }
        public string Method { get { return method; } }
        public bool IntrospectionMethod { get; set; }
        public bool StructParams { get; set; }
        public override string ToString() {
            string value = "Method : " + method;
            return value;
        }
        public string Description = "";
        public bool Hidden = false;
        private readonly string method = "";
    }
}