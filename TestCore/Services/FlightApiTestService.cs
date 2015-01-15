using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestCommon;

namespace TestCore.Services
{
    public class FlightApiTestService //: IFlightApiTestService
    {
        public async Task<string> GetAuthenticationKeyAsync()
        {
            string authUrl = Utility.GenerateAuthenticationUrl();
            using (HttpClient httpClient = new HttpClient())
            {
                string deserializeObject = JsonConvert.DeserializeObject<string>(await httpClient.GetStringAsync(authUrl));
                return deserializeObject;
            }
        }

        public async Task<List<string>> GetTestUrls(int searchCount, string key)
        {
            string uri = "";
            List<string> uris = new List<string>();

            for (int i = 0; i < searchCount; i++)
            {
                string uriParameters = await Utility.GetRandomParameters();
                uri = Utility.GenerateSearchUrl() + "AuthenticationKey=" + key + uriParameters;
                uris.Add(uri);
            }
            return uris;
        }
    }
}