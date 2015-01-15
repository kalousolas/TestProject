using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFields
{
    public struct Url
    {
        public const string BASE_URL = "http://localhost:2885/api/";
        public const string SEARCH_FLIGHT_URL = "Flight/SearchFlight?";
    }

    public struct InitialParameters
    {
        public const int SAMPLE_INTERVAL = 12000;
        public const int CLIENT_INCREMENT_PER_INTERVAL = 5;
        public const string LOG_FILENAME = "results.txt";
    }
}