using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    [System.Web.Services.WebServiceBindingAttribute(Name = "MyClientSoap", Namespace = "http://localhost:8004/")]
    public partial class MyClient : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        public MyClient(string url)
        {
            base.Url = url;
        }

        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost:8004/HelloWorld", RequestNamespace = "http://localhost:8004/", ResponseNamespace = "http://localhost:8003/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("HelloWorldResult", DataType = "string")]
        public string HelloWorld()
        {
            object[] results = this.Invoke("HelloWorld", new object[] {});
            return ((string)(results[0]));
        }


    }
}