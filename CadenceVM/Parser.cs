using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CadenceVM
{
    public class Parser
    {
        string fileName;
        string fileText;
        static string[] tokens = Array.Empty<string>();
        static int tokenPointer;

        public Parser(string filename, int pointer = -1)
        {
            this.fileName = filename;
            this.fileText = string.Empty;
            tokenPointer = pointer;
            if (!File.Exists(filename))
            {
                Logger.Log(Level.Error, $"the file '{filename}' does not exist here");
                Environment.Exit(1);
                return;
            }
        }

        public void Parse()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            this.fileText = File.ReadAllText(this.fileName);
            tokens = this.fileText.Split(";");
            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}s {1:00}ms", elapsed.Seconds, elapsed.Milliseconds);
            Logger.Log(Level.Info, $"parsed {tokens.Length - 1} tokens in {elapsedTime}");
        }

        public static void Advance()
        {
            tokenPointer++;
        }

        public static Token GetToken()
        {
            return Tokenizer.GetToken(tokens[tokenPointer]);
        }

        public static int GetTokenPointer()
        {
            return tokenPointer;
        }

        public static void SetTokenPointer(int pointer)
        {
            tokenPointer = pointer;
        }
    }
}
