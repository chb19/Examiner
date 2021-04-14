using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.BLL.Interfaces
{
    public interface ILoggerService
    {
        void LogInfo(string msg);
        void LogError(string msg);
        void LogFatal(string msg);
    }
}