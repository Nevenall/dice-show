using Antlr4.Runtime;
using DiceShow.Parsing;
using DiceShow.Models;
using System;

namespace DiceShow
{
    public class Parser : IParser
    {


        // so what is a good way to allow the parse to fail? 
        // ideally without throwing exceptions.
        //failure to parse is a legitimate return value. 
        // we could return a tuple that is either a roll, or an error result
        // or we could return an object that is metadata about the Parsing
        // ParseResult for example. that might be the most sensible way to do it. 
        // then it could even have additional info like how long it took to parse. 


        public Parsed Parse(string raw)
        {
            var ret = new Parsed();
            var internalParser = new DiceParser(new CommonTokenStream(new DiceLexer(new AntlrInputStream(raw))));
            var walker = new Antlr4.Runtime.Tree.ParseTreeWalker();
            var tree = internalParser.roll();
            var listener = new DiceListener();

            walker.Walk(listener, tree);

            if (tree.exception != null)
            {
                ret.Exception = tree.exception;
            }
            else if (listener.Error != null)
            {
                ret.Error = new ParseError
                {
                    Symbol = listener.Error.Symbol.Text,
                    Line = listener.Error.Symbol.Line,
                    Column = listener.Error.Symbol.Column
                };
            }
            else
            {
                ret.Roll = listener.Roll;
            }
            return ret;
        }

    }
}