using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService2
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://localhost:8004/Service1.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string JustSleep1Min()
        {
            System.Threading.Thread.Sleep(new TimeSpan(0, 1, 0));//sleep for a minute
            return "Hello World";
        }

        [WebMethod]
        public string FlushAndSleep1Min()
        {
            Context.Response.Write("Data...Data...");
            Context.Response.Flush();
            System.Threading.Thread.Sleep(new TimeSpan(0, 1, 0));//sleep for a minute
            return "Hello World";
        }

        [WebMethod]
        public string NoFlushAndSleep1Min()
        {
            Context.Response.Write("Data...Data...");
            System.Threading.Thread.Sleep(new TimeSpan(0, 1, 0));//sleep for a minute
            return "Hello World";
        }
    }
}