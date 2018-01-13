using System;
namespace XmlRpcLight.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class XmlRpcServiceAttribute : Attribute
    {
        public bool AutoDocumentation { get; set; } = true;
        public bool AutoDocVersion { get; set; } = true;
        public string Description { get; set; } = "";
        public int Indentation { get; set; } = 2;
        public bool Introspection { get; set; }
        public string Name { get; set; } = "";
        public bool UseIndentation { get; set; } = true;
        public bool UseIntTag { get; set; }
        public bool UseStringTag { get; set; } = true;
        public string XmlEncoding { get; set; }
        public override string ToString()
        {
            string value = "Description : " + Description;
            return value;
        }
    }
}