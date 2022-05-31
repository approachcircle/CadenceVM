using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CadenceVM
{
    public class Dispatcher
    {
        public static void Dispatch(Token token)
        {
            switch (token)
            {
                case Token.HALT:
                    Environment.Exit(0);
                    break;
                case Token.PRINT:
                    Console.WriteLine(String.current);
                    break;
                case Token.SHUTDOWN:
                    Process.Start("shutdown", "/s /t 30");
                    break;
                case Token.SHUTDOWN_ABORT:
                    Process.Start("shutdown", "/a");
                    break;
                default:
                    Logger.Log(Level.Error, $"called to dispatch token: {token} without knowing what to do with it");
                    Logger.Log(Level.Error, $"maybe it's missing an implementation?");
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
