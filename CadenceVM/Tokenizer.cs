using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadenceVM
{
    public class Tokenizer
    {
        public static Token GetToken(string tokenString)
        {
            if (tokenString.Length <= 0)
            {
                return Token.HALT;
            }
            Boolean isPrint = tokenString[0] == '0' && tokenString[1] == '1';

            if (isPrint)
            {
                string literalTrailing = tokenString.Split("{")[1];
                string literal = literalTrailing.Split("}")[0];
                String.current = literal;
                return Token.PRINT;
            }
            if (!int.TryParse(tokenString, out int tokenValue))
            {
                Logger.Log(Level.Error, $"token number: {Parser.GetTokenPointer() + 1}");
                Environment.Exit(1);
                return Token.HALT;
            }
            foreach (Token token in Enum.GetValues(typeof(Token)))
            {
                if (tokenValue == (int) token)
                {
                    return token;
                }
            }
            Logger.Log(Level.Error, $"token number: {Parser.GetTokenPointer() + 1} does not match any known tokens");
            Environment.Exit(1);
            return Token.HALT;
        }
    }
}
