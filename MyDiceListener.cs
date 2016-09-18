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
        var dice = context.dice();

    }


    public void ExitStatement(DiceParser.StatementContext context) {

    }


    public void EnterDice(DiceParser.DiceContext context) {
        var s = "";
    }

    public void ExitDice(DiceParser.DiceContext context) {
        
    }

}
