using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadenceVM
{
    public enum Token
    {
        PRINT = 01,
        HALT = 98,
        SHUTDOWN = 02,
        SHUTDOWN_ABORT = 03,
        INF = 04,
        INFE = 05
    }
}
