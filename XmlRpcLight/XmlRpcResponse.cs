using System;
namespace XmlRpcLight {
    public class XmlRpcResponse {
        public XmlRpcResponse() {
            retVal = null;
        }
        public XmlRpcResponse(object retValue) {
            retVal = retValue;
        }
        public Object retVal;
    }
}