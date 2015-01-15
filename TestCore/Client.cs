using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;

namespace TestCore
{
    public class Client
    {
        private readonly string _url;
        private readonly Thread _thread;
        private readonly List<HttpStatusCode> _errorCodes = new List<HttpStatusCode>();
        private readonly List<double> _durations = new List<double>();
        private int _numRequestsAttempted = 0;
        private readonly DateTime _birthDate = DateTime.Now;
        private readonly object _stateLock = new object();

        public Client(string url)
        {
            _url = url;
            _thread = new Thread(() =>
            {
                while (true)
                {
                    PerformWebRequest();
                }
            });
            _thread.Start();
        }

        private void PerformWebRequest()
        {
            DateTime start = DateTime.Now;

            var request = WebRequest.Create(_url);
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    lock (_stateLock)
                    {
                        _numRequestsAttempted++;
                        _durations.Add(DateTime.Now.Subtract(start).TotalMilliseconds);
                        if (response.StatusCode != HttpStatusCode.OK)
                            _errorCodes.Add(response.StatusCode);
                    }
                }
            }
            catch (Exception exception)
            {
                lock (_stateLock)
                {
                    _numRequestsAttempted++;
                    if (exception.Message.Contains("timed out"))
                        _errorCodes.Add(HttpStatusCode.RequestTimeout);
                    else
                        _errorCodes.Add(HttpStatusCode.Unused);
                }
            }
        }

        public double? GetRollingAverageDuration()
        {
            lock (_stateLock)
            {
                if (_durations.Count == 0)
                    return null;
                return Enumerable.Reverse(_durations).Take(3).Average();
            }
        }

        public int GetErrorCount()
        {
            lock (_stateLock)
            {
                return _errorCodes.Count;
            }
        }

        public int GetRequestsAttemptedCount()
        {
            lock (_stateLock)
            {
                return _numRequestsAttempted;
            }
        }

        public double AgeMilliseconds { get { return DateTime.Now.Subtract(_birthDate).TotalMilliseconds; } }
    }
}