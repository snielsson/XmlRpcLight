using System.IO;
using System.Text;

namespace XmlRpcLight
{
    public static class XmlRpcUtil
    {
        public static void CopyStream(Stream src, Stream dst)
        {
            src.CopyTo(dst);

        }
        public static Stream StringAsStream(string S)
        {            
            return new MemoryStream(Encoding.UTF8.GetBytes(S));            
        }
    }
}