using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MintaZH_2
{
    public class StringProcessor
    {
        public int AllTimeouts { get; set; }
        private string to = "Request timed out.";
        private object alltoLock = new object();
        public int IsTimedOut(string input)
        {
            if (input.Contains(to))
            {
                string[] lines = input.Split('\n');
                int tos = lines.Where(x => x.Contains(to)).Count();
                lock (alltoLock)
                {
                    AllTimeouts += tos;
                }
                return tos;
            }
            return 0;
        }


    }
}
