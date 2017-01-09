
namespace DiceShow.Ops.Parsing
{
	using System;
	using System.Collections.ObjectModel;
	using Antlr4.Runtime;
	using Antlr4.Runtime.Misc;
	using Antlr4.Runtime.Tree;
	using DiceShow.Ops.Parsing.Internal;
	using DiceShow.Model;

	public class DiceVisitor : DiceBaseVisitor<Parsed>
	{


		public override Parsed VisitStatement(DiceParser.StatementContext context)
		{
			var ret = new Parsed();


			return ret;
		}

		// public Parsed Visit(IParseTree tree)
		// {
		// 	return tree.Accept(this);
		// }

		// public Parsed VisitAddDiceExp([NotNull] DiceParser.AddDiceExpContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitAddScalar([NotNull] DiceParser.AddScalarContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitChildren(IRuleNode node)
		// {
		// 	for (int i = 0; i < node.ChildCount; ++i)
		// 	{
		// 		var child = node.GetChild(i);
		// 			node.Accept()
		// 	}
		// 	return null;
		// }

		// public Parsed VisitCount([NotNull] DiceParser.CountContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitDice([NotNull] DiceParser.DiceContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitDiceExp([NotNull] DiceParser.DiceExpContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitDrop([NotNull] DiceParser.DropContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitErrorNode(IErrorNode node)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitExplode([NotNull] DiceParser.ExplodeContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitExpression([NotNull] DiceParser.ExpressionContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitHit([NotNull] DiceParser.HitContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitKeep([NotNull] DiceParser.KeepContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitReroll([NotNull] DiceParser.RerollContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitStatement([NotNull] DiceParser.StatementContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitSubDiceExp([NotNull] DiceParser.SubDiceExpContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitSubScalar([NotNull] DiceParser.SubScalarContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitTarget([NotNull] DiceParser.TargetContext context)
		// {
		// 	throw new NotImplementedException();
		// }

		// public Parsed VisitTerminal(ITerminalNode node)
		// {
		// 	throw new NotImplementedException();
		// }
	}
}