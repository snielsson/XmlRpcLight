using System;
namespace XmlRpcLight {
    public class XmlRpcParameterInfo {
        public string Doc { get; set; }
        public bool IsParams { get; set; }
        public String Name {
            get { return name; }
            set {
                name = value;
                if (xmlRpcName == "")
                    xmlRpcName = name;
            }
        }
        public String XmlRpcName { get { return xmlRpcName; } set { xmlRpcName = value; } }
        public Type Type { get; set; }
        public string XmlRpcType { get; set; }
        private string name;
        private string xmlRpcName;
    }
}