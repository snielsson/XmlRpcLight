using System;
using System.Reflection;
using System.Threading;
namespace XmlRpcLight {
    public class XmlRpcRequest {
        public XmlRpcRequest() {}
        public XmlRpcRequest(string methodName, object[] parameters, MethodInfo methodInfo) {
            method = methodName;
            args = parameters;
            mi = methodInfo;
        }
        public XmlRpcRequest(string methodName, object[] parameters, MethodInfo methodInfo, string XmlRpcMethod, Guid proxyGuid) {
            method = methodName;
            args = parameters;
            mi = methodInfo;
            xmlRpcMethod = XmlRpcMethod;
            proxyId = proxyGuid;
        }
        public XmlRpcRequest(string methodName, Object[] parameters) {
            method = methodName;
            args = parameters;
        }
        public String method;
        public Object[] args;
        public MethodInfo mi;
        public Guid proxyId;
        private static int _created;
        public int number = Interlocked.Increment(ref _created);
        public String xmlRpcMethod;
    }
}