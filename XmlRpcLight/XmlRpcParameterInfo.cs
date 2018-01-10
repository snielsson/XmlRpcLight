using System;
namespace XmlRpcLight
{
    public class XmlRpcParameterInfo
    {
        public string Doc { get; set; }
        public bool IsParams { get; set; }
        public String Name
        {
            get { return name; }
            set
            {
                name = value;

                if (string.IsNullOrEmpty(XmlRpcName))
                    XmlRpcName = name;
            }
        }
        public string XmlRpcName { get; set; }
        public Type Type { get; set; }
        public string XmlRpcType { get; set; }
        private string name;

    }
}