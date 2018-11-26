using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogMocker
{
    public class SomeLogic
    {
        ILogger log;

        public SomeLogic(ILogger log)
        {
            this.log = log;
        }

        public void ComplicatedLogic(string someTextToProcess)
        {
            if (someTextToProcess == null)
            {
                log.WriteLog(LogLevel.Exception, "U passed null but no probs ill just take care of it.");
                someTextToProcess = "Here ya go fixed.";
            }
            log.WriteLog(LogLevel.Trace, "ComplicatedLogic method started.");
            //valami logika
            log.WriteLog(LogLevel.Debug, "Processing: " + someTextToProcess);
            //mégtöbb logika
            log.WriteLog(LogLevel.Trace, "ComplicatedLogic method finished.");
        }
    }
}
