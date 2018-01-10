using System;
namespace XmlRpcLight.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class XmlRpcUrlAttribute : Attribute
    {
        public XmlRpcUrlAttribute(string UriString)
        {
            Uri = UriString;
        }
        public string Uri { get; }
        public override string ToString()
        {
            return "Uri : " + Uri;
        }

    }
}