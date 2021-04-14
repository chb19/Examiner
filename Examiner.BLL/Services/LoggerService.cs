using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.BLL.Interfaces
{
    public class LoggerService : ILoggerService
    {
        public LoggerService() { }

        public void LogInfo(string msg)
        {
            Log.Information(msg);
        }

        public void LogError(string msg)
        {
            Log.Error(msg);
        }

        public void LogFatal(string msg)
        {
            Log.Fatal(msg);
        }
    }
}