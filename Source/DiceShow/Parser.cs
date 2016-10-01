using Antlr4.Runtime;
using DiceShow.Parsing;
using DiceShow.Models;

namespace DiceShow
{
    public class Parser : IParser
    {




        public Roll Parse(string raw)
        {
            var internalParser = new DiceParser(new CommonTokenStream(new DiceLexer(new AntlrInputStream(raw))));
            var walker = new Antlr4.Runtime.Tree.ParseTreeWalker();
            var listener = new DiceListener();

            walker.Walk(listener, internalParser.roll());

            return listener.Roll;

        }

    }
}