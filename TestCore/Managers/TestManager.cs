using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCore.Managers
{
    class TestManager
    {
        private readonly List<Client> _clients = new List<Client>();

        public void AddClient(string url) { _clients.Add(new Client(url)); }

        public TestStats GetLatestStats()
        {
            var validDurations = from duration in _clients.Select(x => x.GetRollingAverageDuration())
                                 where duration.HasValue
                                 select duration.Value;

            return new TestStats
            {
                NumClients = _clients.Count(),
                AverageRequestDurationMillisecs = validDurations.Any() ? validDurations.Average() : 0,
                ErrorCount = _clients.Sum(x => x.GetErrorCount()),
                AverageRequestsPerClientSecond = _clients.Average(x => 1000 * x.GetRequestsAttemptedCount() / x.AgeMilliseconds)
            };
        }
    }

    class TestStats
    {
        public int NumClients { get; set; }
        public double AverageRequestDurationMillisecs { get; set; }
        public int ErrorCount { get; set; }
        public double AverageRequestsPerClientSecond { get; set; }
    }
}