# XmlRpcLight
C# XmlRpc library based on a trimmed down version of Xml-Rpc by Charles Cook.

XmlRpcLight has no dependencies on System.Web and is suitable for usage in ASP.NET 5 applications.

##Install from Nuget.org:

Install-Package XmlRpcLight.

##Usage: 
Derive a service class from XmlRpcService and mark methods with XmlRpcMethod attributes:

    private class SomeXmlRpcLightService : XmlRpcService {
        [XmlRpcMethod("someNamesSpace.someMethod")]
        public string SomeMethod(int id, string name) {
            return id + name; // return something.
        }
    }

Now instantiate this class and call Invoke with an Xml string to perform the Xml Rpc call:

    string xml =
        @"<?xml version=""1.0""?>
		<methodCall>
		  <methodName>someNamesSpace.someMethod</methodName>
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

	    var rpcService = new SomeXmlRpcLightService();
	    var resultXml = rpcService.Invoke(xml);

	   	// Now result will contain this XML:
		<?xml version=""1.0""?>
		<methodResponse>
		  <params>
		    <param>
		      <value>
		        <string>40bla bla</string>
		      </value>
		    </param>
		  </params>
		</methodResponse>";
	   	





