using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogMocker
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            SomeLogic l = new SomeLogic(logger);
            l.ComplicatedLogic("asd");
        }
    }
}
