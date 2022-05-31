using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CadenceVM
{
    public class Parser
    {
        string fileName;
        string fileText;
        static string[] tokens = Array.Empty<string>();
        static int tokenPointer;
        static Boolean EOF;

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
            this.fileText = File.ReadAllText(this.fileName);
            tokens = this.fileText.Split(";");
        }

        public static void Advance()
        {
            tokenPointer++;
            if (tokenPointer >= tokens.Length)
            {
                EOF = true;
            }
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
