using System;
namespace XmlRpcLight.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class XmlRpcMethodAttribute : Attribute
    {
        public XmlRpcMethodAttribute()
        {
            StructParams = false;
            IntrospectionMethod = false;
        }
        public XmlRpcMethodAttribute(string method)
        {
            StructParams = false;
            IntrospectionMethod = false;
            this.Method = method;
        }
        public string Method { get; }
        public bool IntrospectionMethod { get; set; }
        public bool StructParams { get; set; }
        public override string ToString()
        {
            return "Method : " + Method;
            
        }
        public string Description = "";
        public bool Hidden = false;
    }
}