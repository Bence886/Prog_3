using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogMocker
{
    public class ConsoleLogger : ILogger
    {
        public void WriteLog(LogLevel level, string msg)
        {
            Console.WriteLine($"{level.ToString()} : {msg}");
        }
    }
}
