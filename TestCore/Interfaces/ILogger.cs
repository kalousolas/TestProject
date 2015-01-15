using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCore.Interfaces
{
    public interface ILogger
    {
        void Trace(string message);
        void Debug(string message, params object[] args);
        void Info(string message, params object[] args);
        void Error(string message, Exception ex);
        //void Warn(string message);
        //void Fatal(string message);
    }
}
