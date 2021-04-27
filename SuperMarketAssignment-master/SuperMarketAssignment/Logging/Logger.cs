using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Logging
{
    public class Logger : ILogger
    {
        public void write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
