using System;
namespace XmlRpcLight.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class XmlRpcMemberAttribute : Attribute
    {
        public XmlRpcMemberAttribute() { }
        public XmlRpcMemberAttribute(string member)
        {
            Member = member;
        }
        public string Member { get; set; } = "";
        public string Description { get; set; } = "";
        public override string ToString()
        {
            string value = "Member : " + Member;
            return value;
        }

    }
}