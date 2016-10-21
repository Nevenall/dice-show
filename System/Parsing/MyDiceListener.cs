using System;
using System.Collections.ObjectModel;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DiceShow.Models;

namespace DiceShow.Parsing
{
    public class DiceListener : IDiceListener
    {

        public Statement  Statement { get; set; }

        public Collection<IErrorNode> Errors { get; set; } = new Collection<IErrorNode>();




        public void EnterEveryRule(ParserRuleContext context)
        {

        }

        public void ExitEveryRule(ParserRuleContext context)
        {

        }
        public void VisitErrorNode(IErrorNode node)
        {
            Errors.Add(node);
        }

        public void VisitTerminal(ITerminalNode node)
        {

        }

        public void EnterStatement([NotNull] DiceParser.StatementContext context)
        {
            Statement = new Statement {  };
        }

        public void ExitStatement([NotNull] DiceParser.StatementContext context)
        {

        }


        public void EnterDice(DiceParser.DiceContext context)
        {
            Statement.Dice.Add(new Dice
            {
                Id = context.ID()?.Symbol.Text,
                Number = Convert.ToInt32(context.INT(0).Symbol.Text),
                Sides = Convert.ToInt32(context.INT(1).Symbol.Text)
            });
        }

        public void ExitDice(DiceParser.DiceContext context)
        {

        }
    }
}