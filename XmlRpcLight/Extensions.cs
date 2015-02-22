using System;
namespace XmlRpcLight {
    public static class Extensions {
        public static T GetAttribute<T>(this object @this) where T : class {
            return Attribute.GetCustomAttribute(@this.GetType(), typeof (T)) as T;
        }
    }
}