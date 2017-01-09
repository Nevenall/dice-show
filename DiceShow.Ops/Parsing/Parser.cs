
namespace DiceShow.Ops.Parsing
{
	using Antlr4.Runtime;
	using System;
	using System.Linq;
	using DiceShow.Ops.Parsing.Internal;
	using DiceShow.Model;
	public class Parser : IParser
	{
		public Parsed Parse(string raw)
		{
			var ret = new Parsed();
			try
			{
				var internalParser = new DiceParser(new CommonTokenStream(new DiceLexer(new AntlrInputStream(raw))));
				var tree = internalParser.statement();
				var walker = new Antlr4.Runtime.Tree.ParseTreeWalker();
				var listener = new DiceListener();

				walker.Walk(listener, tree);

				ret = listener.Parsed;
			}
			catch (Exception ex)
			{
				ret.Exception = ex;
			}

			return ret;
		}

	}
}