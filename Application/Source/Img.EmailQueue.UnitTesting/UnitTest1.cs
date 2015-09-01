using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Img.EmailQueue.Server;
using Img.EmailQueue.Server.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace Img.EmailQueue.UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void QueueApiTest()
        {

            string URI = "http://localhost:62902/api/queue/5";
            string myParameters = "param1=value1&param2=value2&param3=value3";

            /*
             unit testing
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, myParameters);
            }
            */
            Assert.IsTrue(true);

            
            //Assert.AreEqual(URI, null); // fails
            //Assert.IsTrue(URI.Equals(null)); // passes
            //Assert.AreSame(URI, "c");

        }

        [TestMethod]
        public void DequeueApiTest()
        {

            var sb = new StringBuilder();
            TextWriter w = new StringWriter(sb);
            var context = new HttpContext(new HttpRequest("", "http://localhost:62902/api/queue/5", ""), new HttpResponse(w));

            HttpContext.Current = context;

            Console.WriteLine(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority));
            Assert.IsTrue(true);

        }




    }
}
