using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;
using XmlRpcLight.Attributes;
namespace XmlRpcLight {
    public abstract class XmlRpcService : MarshalByRefObject {
        [XmlRpcMethod("system.listMethods", IntrospectionMethod = true, Description = "Return an array of all available XML-RPC methods on this Service.")]
        public string[] System__List__Methods___() {
            XmlRpcServiceInfo svcInfo = XmlRpcServiceInfo.CreateServiceInfo(GetType());
            var alist = new ArrayList();
            foreach (XmlRpcMethodInfo mthdInfo in svcInfo.Methods) {
                if (!mthdInfo.IsHidden) alist.Add(mthdInfo.XmlRpcName);
            }
            return (String[]) alist.ToArray(typeof (string));
        }

        [XmlRpcMethod("system.methodSignature", IntrospectionMethod = true, Description = "Given the name of a method, return an array of legal signatures. Each signature is an array of strings. The first item of each signature is the return type, and any others items are parameter types.")]
        public Array System__Method__Signature___(string MethodName) {
            XmlRpcServiceInfo svcInfo = XmlRpcServiceInfo.CreateServiceInfo(GetType());
            XmlRpcMethodInfo mthdInfo = svcInfo.GetMethod(MethodName);
            if (mthdInfo == null) throw new XmlRpcFaultException(880, "Request for information on unsupported method");
            if (mthdInfo.IsHidden) throw new XmlRpcFaultException(881, "Information not available on this method");
            var alist = new ArrayList {
                XmlRpcServiceInfo.GetXmlRpcTypeString(mthdInfo.ReturnType)
            };
            foreach (XmlRpcParameterInfo paramInfo in mthdInfo.Parameters) {
                alist.Add(XmlRpcServiceInfo.GetXmlRpcTypeString(paramInfo.Type));
            }
            var types = (string[]) alist.ToArray(typeof (string));
            var retalist = new ArrayList {
                types
            };
            Array retarray = retalist.ToArray(typeof (string[]));
            return retarray;
        }

        [XmlRpcMethod("system.methodHelp", IntrospectionMethod = true, Description = "Given the name of a method, return a help string.")]
        public string System__Method__Help___(string MethodName) {
            XmlRpcServiceInfo svcInfo = XmlRpcServiceInfo.CreateServiceInfo(GetType());
            XmlRpcMethodInfo mthdInfo = svcInfo.GetMethod(MethodName);
            if (mthdInfo == null) throw new XmlRpcFaultException(880, "Request for information on unsupported method");
            if (mthdInfo.IsHidden) throw new XmlRpcFaultException(881, "Information not available for this method");
            return mthdInfo.Doc;
        }

        public string Invoke(string xml) {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml))) {
                using (var resultStream = Invoke(stream)) {
                    var bytes = new byte[resultStream.Length];
                    resultStream.Read(bytes, 0, bytes.Length);
                    var result = Encoding.UTF8.GetString(bytes);
                    return result;
                }
            }
        }

        public Stream Invoke(Stream requestStream) {
            try {
                var serializer = new XmlRpcSerializer();
                var serviceAttr = this.GetAttribute<XmlRpcServiceAttribute>();
                if (serviceAttr != null) {
                    if (serviceAttr.XmlEncoding != null) serializer.XmlEncoding = Encoding.GetEncoding(serviceAttr.XmlEncoding);
                    serializer.UseIntTag = serviceAttr.UseIntTag;
                    serializer.UseStringTag = serviceAttr.UseStringTag;
                    serializer.UseIndentation = serviceAttr.UseIndentation;
                    serializer.Indentation = serviceAttr.Indentation;
                }
                XmlRpcRequest xmlRpcReq = serializer.DeserializeRequest(requestStream, GetType());
                XmlRpcResponse xmlRpcResp = Invoke(xmlRpcReq);
                Stream responseStream = new MemoryStream();
                serializer.SerializeResponse(responseStream, xmlRpcResp);
                responseStream.Seek(0, SeekOrigin.Begin);
                return responseStream;
            }
            catch (Exception ex) {
                XmlRpcFaultException fex;
                if (ex is XmlRpcException) fex = new XmlRpcFaultException(0, ex.Message);
                else {
                    var exception = ex as XmlRpcFaultException;
                    fex = exception ?? new XmlRpcFaultException(0, ex.Message);
                }
                var serializer = new XmlRpcSerializer();
                Stream responseStream = new MemoryStream();
                serializer.SerializeFaultResponse(responseStream, fex);
                responseStream.Seek(0, SeekOrigin.Begin);
                return responseStream;
            }
        }

        public XmlRpcResponse Invoke(XmlRpcRequest request) {
            MethodInfo mi = request.mi ?? GetType().GetMethod(request.method);
            Object reto;
            try {
                reto = mi.Invoke(this, request.args);
            }
            catch (Exception ex) {
                if (ex.InnerException != null) throw ex.InnerException;
                throw ex;
            }
            var response = new XmlRpcResponse(reto);
            return response;
        }

        private bool IsVisibleXmlRpcMethod(MethodInfo mi) {
            bool ret = false;
            Attribute attr = Attribute.GetCustomAttribute(mi, typeof (XmlRpcMethodAttribute));
            if (attr != null) {
                var mattr = (XmlRpcMethodAttribute) attr;
                ret = !mattr.Hidden;
            }
            return ret;
        }
    }
}