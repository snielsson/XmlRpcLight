using System;
using XmlRpcLight.Enums;
namespace XmlRpcLight.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Class)]
    public class XmlRpcMissingMappingAttribute : Attribute
    {
        public XmlRpcMissingMappingAttribute() { }
        public XmlRpcMissingMappingAttribute(MappingAction action)
        {
            Action = action;
        }
        public MappingAction Action { get; } = MappingAction.Error;
        public override string ToString()
        {
            return Action.ToString();

        }

    }
}