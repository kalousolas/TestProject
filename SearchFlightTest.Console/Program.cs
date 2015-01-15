using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestCore.Services;

namespace SearchFlightTest.Console
{
    class Program
    {
        private const int SEARCH_COUNT = 10;
        static FlightApiTestService service = new FlightApiTestService();
        //public const string BASE_URL = "http://localhost:2885/api/";

        private static void Main(string[] args)
        {
            try
             {
                 RunAsync().Wait();
             }
             catch (Exception ex)
             { 
             }          
        }

        private static async Task RunAsync()
        {
            string key = await GetKey();

            IEnumerable<string> urlCollection = await service.GetTestUrls(SEARCH_COUNT, key);

            Parallel.ForEach(urlCollection, async url => await GetSearchFlight(url));
        }

        private async static Task GetSearchFlight(string url)
        {
            string result;

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    result = response.StatusCode.ToString();
                }
            }

            const string FILE_NAME = @"D:\SearchLogs\{0}.xml";

            string fileName = string.Empty;
            try
            {
                fileName = string.Format(FILE_NAME, DateTime.Now.ToShortTimeString().Replace(":", "-") + "-" + DateTime.Now.Second + "___" + Guid.NewGuid().ToString().Replace("-", string.Empty));
                

            }
            catch (Exception ex)
            {
            }

            StreamWriter logFile = File.CreateText(fileName);
            using (logFile)
            {
                logFile.Write(url + Environment.NewLine + result);
            }
        }

        private static async Task<string> GetKey()
        {
            return await service.GetAuthenticationKeyAsync();
        }
    }
}
