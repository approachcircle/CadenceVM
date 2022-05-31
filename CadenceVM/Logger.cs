using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadenceVM
{
    public class Logger
    {
        public static void Log(Level level, Object content)
        {
            if (level.Equals(Level.Error))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            } else if (level.Equals(Level.Warning))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine($"[CADENCE {level.ToString()}] {content}");
            Console.ResetColor();
        }
    }

    public enum Level
    {
        Error,
        Warning,
        Info
    }
}
