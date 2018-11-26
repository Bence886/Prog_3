using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogMocker
{
    public enum LogLevel { Exception, Trace, Debug, Message, Warning, Error };
    public interface ILogger
    {
        void WriteLog(LogLevel level, string msg);
    }
}
