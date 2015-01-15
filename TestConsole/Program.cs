using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                // const string API = "api/";
                // const string MEDIA_TYPE = "application/json";

                HttpResponseMessage response;
                client.BaseAddress = new Uri("http://pretestticket.mikatur.com.tr");
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MEDIA_TYPE));
                var content = new FormUrlEncodedContent(new[] 
                 {
                new KeyValuePair<string, string>("BankId",  Guid.NewGuid().ToString()),
                new KeyValuePair<string, string>("InstallmentId",  Guid.NewGuid().ToString()),
                new KeyValuePair<string, string>("CardOwner",  "test")
                 });
                HttpResponseMessage httpResponseMessage = client.PostAsync("/wsdl/Xml3DPayment.aspx/", content).Result;
                var result = httpResponseMessage;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(resultContent);
            }

        }
    }
}
