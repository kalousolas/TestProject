using System;
using System.Security.Policy;
using System.Threading.Tasks;
using TestFields;
using Url = TestFields.Url;


namespace TestCommon
{
    public static class Utility
    {
        public async static Task<string> GetRandomParameters()
        {
            /* IST AYT ESB ERC ADB */
            string[] airports = { "IST", "AYT", "ESB", "SAW", "ADB" };
            int index = new Random().Next(0, airports.Length-1);

            string from = await GetFrom(airports, index);
            string to = await GetTo(airports, index + 1);

            int adultCount = 2; //new Random().Next(1, 4);
            int childCount = 1; //new Random().Next(1, 4);
            int infantCount = 0; //new Random().Next(1, 4);
            const string CABIN_CODE = "Economy";
            string date = GenererateRandomDate().ToString("yyyy-MM-dd");//.Replace(".","-");//MM.dd.yyyy

            string uriParameters = String.Format("&From={0}" +
                                                 "&To={1}" +
                                                 "&Date={2}" +
                                                 "&Passenger.Adult={3}" +
                                                 "&Passenger.Child={4}" +
                                                 "&Passenger.Infant={5}" +
                                                 "&CabinCode={6}" +
                                                 "&type=xml", from, to, date, adultCount, childCount, infantCount, CABIN_CODE
                );
            return uriParameters;
        }

        private async static Task<string> GetTo(string[] airports,int index)
        {
            return airports[index];
        }

        private async static Task<string> GetFrom(string[] airports,int index)
        {
            return airports[index];
        }

        public static DateTime GenererateRandomDate()
        {
            int year = 2015;
            int month = new Random().Next(1, 12);
            int day = DateTime.DaysInMonth(year, month);

            int Day = new Random().Next(1, day);

            DateTime dt = new DateTime(year, month, Day);
            return dt;
        }
        public static string GenerateAuthenticationUrl()
        {
            string authUrl = Url.BASE_URL + String.Format("Authentication/Key?agencyCode={0}&ApiPassword={1}&userName=mgm@mikatur.com&Password=123456&type=json", Settings.agencyCode, Settings.apiPassword);

            return authUrl;

        }
        public static string GenerateSearchUrl()
        {

            string searchUrl = Url.BASE_URL+Url.SEARCH_FLIGHT_URL+"";

            return searchUrl;
        }


    }
}