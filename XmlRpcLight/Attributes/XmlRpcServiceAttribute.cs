using System;
namespace XmlRpcLight.Attributes {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class XmlRpcServiceAttribute : Attribute {
        public bool AutoDocumentation { get { return autoDocumentation; } set { autoDocumentation = value; } }
        public bool AutoDocVersion { get { return autoDocVersion; } set { autoDocVersion = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int Indentation { get { return indentation; } set { indentation = value; } }
        public bool Introspection { get; set; }
        public string Name { get { return name; } set { name = value; } }
        public bool UseIndentation { get { return useIndentation; } set { useIndentation = value; } }
        public bool UseIntTag { get; set; }
        public bool UseStringTag { get { return useStringTag; } set { useStringTag = value; } }
        public string XmlEncoding { get; set; }
        public override string ToString() {
            string value = "Description : " + description;
            return value;
        }
        private string description = "";
        private int indentation = 2;
        private bool autoDocumentation = true;
        private bool autoDocVersion = true;
        private string name = "";
        private bool useStringTag = true;
        private bool useIndentation = true;
        public XmlRpcServiceAttribute() {
            XmlEncoding = null;
            UseIntTag = false;
            Introspection = false;
        }
    }
}