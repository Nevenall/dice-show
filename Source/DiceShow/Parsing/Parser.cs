using Antlr4.Runtime;
using DiceShow.Parsing;
using DiceShow.Models;
using System;
using System.Linq;

namespace DiceShow
{
    public class Parser : IParser
    {
        public Parsed Parse(string raw)
        {
            var ret = new Parsed();
            try
            {
                var internalParser = new DiceParser(new CommonTokenStream(new DiceLexer(new AntlrInputStream(raw))));
                var walker = new Antlr4.Runtime.Tree.ParseTreeWalker();
                var tree = internalParser.statement();
                var listener = new DiceListener();

                ret.ParseTree = tree.ToStringTree(internalParser);

                walker.Walk(listener, tree);


                ret.Exception = tree.exception;
                ret.Statement = listener.Statement;
                ret.Errors = from e in listener.Errors
                             select new ParseError
                             {
                                 Symbol = e.Symbol.Text,
                                 Line = e.Symbol.Line,
                                 Column = e.Symbol.Column
                             };
            }
            catch (Exception ex)
            {
                ret.Exception = ex;
            }

            return ret;
        }

    }
}