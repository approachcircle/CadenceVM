using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CadenceVM
{
    public class ExecutionTimer
    {
        static Stopwatch stopwatch;
        public static void Start()
        {
            stopwatch = Stopwatch.StartNew();
        }

        public static void Stop()
        {
            if (stopwatch != null)
            {
                stopwatch.Stop();
            }
        }

        public static TimeSpan GetElapsed()
        {
            if (stopwatch != null)
            {
                return stopwatch.Elapsed;
            }
            throw new Exception("stopwatch was never started, cannot get elapsed time");
        }
    }
}
