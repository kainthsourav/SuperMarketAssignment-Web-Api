using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Logging
{
   public interface ILogger
    {
        void write(string msg);
    }
}
