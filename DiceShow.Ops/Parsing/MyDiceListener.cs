
namespace DiceShow.Ops.Parsing
{
	using System;
	using System.Linq;
	using System.Collections.ObjectModel;
	using Antlr4.Runtime;
	using Antlr4.Runtime.Misc;
	using Antlr4.Runtime.Tree;
	using DiceShow.Ops.Parsing.Internal;
	using DiceShow.Model;
	using System.Collections.Generic;

	public class DiceListener : IDiceListener
	{

		public Parsed Parsed { get; set; } = new Parsed();
		public Collection<IErrorNode> Errors { get; set; } = new Collection<IErrorNode>();
		private Stack<Dice> _dice = new Stack<Dice>();

		public void EnterEveryRule(ParserRuleContext context)
		{

		}

		public void ExitEveryRule(ParserRuleContext context)
		{

		}

		public void VisitTerminal(ITerminalNode node)
		{

		}

		public void VisitErrorNode(IErrorNode node)
		{
			Errors.Add(node);
		}


		public void EnterStatement([NotNull] DiceParser.StatementContext context)
		{
			Parsed.Statement = new Statement();
			Parsed.ParseTree = context.ToStringTree();
		}

		public void ExitStatement([NotNull] DiceParser.StatementContext context)
		{
			Parsed.Errors = from e in Errors
								 select new ParseError
								 {
									 Symbol = e.Symbol.Text,
									 Line = e.Symbol.Line,
									 Column = e.Symbol.Column
								 };
			Parsed.Exception = context.exception;
		}


		public void EnterDice(DiceParser.DiceContext context)
		{
			var dice = new Dice
			{
				Id = context.ID()?.Symbol.Text,
				Number = Convert.ToInt32(context.INT(0).Symbol.Text),
				Sides = Convert.ToInt32(context.INT(1).Symbol.Text),
			};

			Parsed.Statement.Dice.Add(dice);
			_dice.Push(dice);
		}

		public void ExitDice(DiceParser.DiceContext context)
		{
			_dice.Pop();
		}


		public void EnterExpression(DiceParser.ExpressionContext context)
		{
			// now we have some rich expression context to include
			// we could create a set of expression types
			// one for each way we can evaluate the results. 
			// expression is optional and associated with dice. 
			// so, 
			// we can analyze the expression and
			/// evaluation expression
			// 


		}
		public void ExitExpression(DiceParser.ExpressionContext context)
		{

		}


		public void EnterAddScalar([NotNull] DiceParser.AddScalarContext context)
		{
			/// we can adjust the top dice on the stack with this expression
			/// ScalarExpression
			var scalar = Convert.ToInt32(context.INT().Symbol.Text);
			_dice.Peek().Expression = new ScalarExpression(scalar);
		}

		public void ExitAddScalar([NotNull] DiceParser.AddScalarContext context)
		{

		}

		public void EnterSubScalar([NotNull] DiceParser.SubScalarContext context)
		{
			var scalar = Convert.ToInt32(context.INT().Symbol.Text);
			_dice.Peek().Expression = new ScalarExpression(-scalar);
		}

		public void ExitSubScalar([NotNull] DiceParser.SubScalarContext context)
		{

		}

		public void EnterAddDiceExp([NotNull] DiceParser.AddDiceExpContext context)
		{
			var s = "";
		}

		public void ExitAddDiceExp([NotNull] DiceParser.AddDiceExpContext context)
		{

		}

		public void EnterSubDiceExp([NotNull] DiceParser.SubDiceExpContext context)
		{
		}

		public void ExitSubDiceExp([NotNull] DiceParser.SubDiceExpContext context)
		{
		}

		public void EnterDrop([NotNull] DiceParser.DropContext context)
		{
			var s ="";
		}

		public void ExitDrop([NotNull] DiceParser.DropContext context)
		{
		}
		public void EnterKeep([NotNull] DiceParser.KeepContext context)
		{
		}

		public void ExitKeep([NotNull] DiceParser.KeepContext context)
		{
		}

		public void EnterCount([NotNull] DiceParser.CountContext context)
		{
		}

		public void ExitCount([NotNull] DiceParser.CountContext context)
		{
		}

		public void EnterReroll([NotNull] DiceParser.RerollContext context)
		{
		}

		public void ExitReroll([NotNull] DiceParser.RerollContext context)
		{
		}

		public void EnterExplode([NotNull] DiceParser.ExplodeContext context)
		{
		}

		public void ExitExplode([NotNull] DiceParser.ExplodeContext context)
		{
		}

		public void EnterHit([NotNull] DiceParser.HitContext context)
		{
		}

		public void ExitHit([NotNull] DiceParser.HitContext context)
		{
		}



		public void EnterDiceExp(DiceParser.DiceExpContext context)
		{

		}
		public void ExitDiceExp(DiceParser.DiceExpContext context)
		{

		}


		public void EnterTarget(DiceParser.TargetContext context)
		{

		}

		public void ExitTarget(DiceParser.TargetContext context)
		{

		}
	}
}