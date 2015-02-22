using System.IO;
namespace XmlRpcLight {
    public static class XmlRpcUtil {
        public static void CopyStream(Stream src, Stream dst) {
            var buff = new byte[4096];
            while (true) {
                int read = src.Read(buff, 0, 4096);
                if (read == 0)
                    break;
                dst.Write(buff, 0, read);
            }
        }
        public static Stream StringAsStream(string S) {
            var mstm = new MemoryStream();
            var sw = new StreamWriter(mstm);
            sw.Write(S);
            sw.Flush();
            mstm.Seek(0, SeekOrigin.Begin);
            return mstm;
        }
    }
}