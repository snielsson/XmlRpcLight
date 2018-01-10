using System;
using System.Reflection;
namespace XmlRpcLight
{
    public class XmlRpcMethodInfo : IComparable
    {

        public bool IsHidden { get; set; }

        public string Doc { get; set; } = "";


        public MethodInfo MethodInfo { get; set; }

        public string MiName { get; set; } = "";
      
        public XmlRpcParameterInfo[] Parameters { get; set; }     

        public Type ReturnType { get; set; }

        public string ReturnXmlRpcType { get; set; }


        public string ReturnDoc { get; set; } = "";


        public string XmlRpcName { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is XmlRpcMethodInfo xmi)
            {
                return this.XmlRpcName.CompareTo(xmi.XmlRpcName);
            }
            throw new ArgumentOutOfRangeException(nameof(obj), $"should be type {typeof(XmlRpcMethodInfo)}");
        }


    }
}