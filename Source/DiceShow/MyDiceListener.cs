using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

public class DiceListener : IDiceListener {

    object Result = new object();

    public IErrorNode Error { get; set; }

    public void EnterEveryRule(ParserRuleContext context) {

    }

    public void ExitEveryRule(ParserRuleContext context) {

    }
    public void VisitErrorNode(IErrorNode node) {
        Error = node;
    }

    public void VisitTerminal(ITerminalNode node) {
        
    }

 
    public void EnterStatement(DiceParser.StatementContext context) {


    }


    public void ExitStatement(DiceParser.StatementContext context) {
// get the dice context we created
    }


    public void EnterDice(DiceParser.DiceContext context) {
    //   context.Dice =  new Dice{ context.}; 


System.Console.WriteLine("found '{0}' dice of '{1}' sides", context.INT(0), context.INT(1) );


    }

    public void ExitDice(DiceParser.DiceContext context) {
        
    }

}
