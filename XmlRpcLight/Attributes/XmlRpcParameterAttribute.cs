using System;
namespace XmlRpcLight.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class XmlRpcParameterAttribute : Attribute
    {
        public XmlRpcParameterAttribute() { }
        public XmlRpcParameterAttribute(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public string Description { get; set; }
        public override string ToString()
        {
            string value = "Description : " + Description;
            return value;
        }

    }
}