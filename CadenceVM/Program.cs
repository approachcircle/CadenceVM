namespace CadenceVM
{
    public class Program
    {
        public static void Main(System.String[] args)
        {
            string filename = string.Empty;
            if (args.Length > 0)
            {
                filename = args[0];
            } else
            {
                Logger.Log(Level.Error, "you must provide a bytecode file to interpret");
                Environment.Exit(1);
                return;
            }
            Parser parser = new Parser(filename);
            parser.Parse();
            while (true)
            {
                Parser.Advance();
                if (Parser.GetToken().Equals(Token.INF))
                {
                    int loopStartPointer = Parser.GetTokenPointer();
                    while (true)
                    {
                        Parser.Advance();
                        if (Parser.GetToken().Equals(Token.INFE))
                        {
                            Parser.SetTokenPointer(loopStartPointer);
                            continue;
                        }
                        Dispatcher.Dispatch(Parser.GetToken());
                    }
                }
                Dispatcher.Dispatch(Parser.GetToken());
            }
        }
    }
}