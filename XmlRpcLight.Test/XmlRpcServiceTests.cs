using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using XmlRpcLight.Attributes;
namespace XmlRpcLight.Test {
    [TestFixture]
    public class XmlRpcServiceTests {
        private class Post {
            public int PostId { get; set; }
            public string PostText { get; set; }
        }

        //[XmlRpcService]
        private class SomeXmlRpcLightService : XmlRpcService {
            public static int newPostCalls;
            public static readonly List<Post> receivedPosts = new List<Post>();
            [XmlRpcMethod("someNameSpace.someMethod")]
            public string SomeMethod(int id, string name, Post post) {
                Interlocked.Increment(ref newPostCalls);
                receivedPosts.Add(post);
                return id + name;
            }
        }

        [Test]
        public void XmpRpcServiceInvokeWorks() {
            string xml =
                @"<?xml version=""1.0""?>
<methodCall>
  <methodName>someNameSpace.someMethod</methodName>
  <params>
    <param>
        <value><i4>40</i4></value>
    </param>
    <param>
        <value><string>bla bla</string></value>
    </param>
    <param>
        <value>
            <struct>
              <member>
                <name>PostId</name>
                <value><i4>1</i4></value>
              </member>
              <member>
                <name>PostText</name>
                <value><string>2</string></value>
              </member>
            </struct>
        </value>
    </param>
  </params>
</methodCall>";
            var sut = new SomeXmlRpcLightService();
            Assert.AreEqual(0, SomeXmlRpcLightService.newPostCalls);
            Assert.AreEqual(0, SomeXmlRpcLightService.receivedPosts.Count);
            string result = sut.Invoke(xml);
            const string expectedResult = @"<?xml version=""1.0""?>
<methodResponse>
  <params>
    <param>
      <value>
        <string>40bla bla</string>
      </value>
    </param>
  </params>
</methodResponse>";
            Assert.AreEqual(1, SomeXmlRpcLightService.newPostCalls);
            Assert.AreEqual(1, SomeXmlRpcLightService.receivedPosts.Count);
            Assert.AreEqual(1, SomeXmlRpcLightService.receivedPosts[0].PostId);
            Assert.AreEqual("2", SomeXmlRpcLightService.receivedPosts[0].PostText);
            Assert.AreEqual(expectedResult, result);
        }
    }
}