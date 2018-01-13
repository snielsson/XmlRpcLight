using System;
namespace XmlRpcLight.Attributes
{
    [AttributeUsage(AttributeTargets.ReturnValue)]
    public class XmlRpcReturnValueAttribute : Attribute
    {
        public string Description { get; set; } = "";
        public override string ToString()
        {
            string value = "Description : " + Description;
            return value;
        }

    }
}