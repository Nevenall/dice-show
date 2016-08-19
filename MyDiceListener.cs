using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

public class MyDiceListener : IDiceListener {

    object Result = new object();


    public void EnterDice([NotNull] DiceParser.DiceContext context) {
        // the result is 
        // roll a NUMBER of dice of size SIDES  


    }

 
    public void EnterEveryRule(ParserRuleContext ctx) {

    }

    public void EnterStatement([NotNull] DiceParser.StatementContext context) {
      // does the context    
    }

    public void ExitDice([NotNull] DiceParser.DiceContext context) {
        
    }


    public void ExitEveryRule(ParserRuleContext ctx) {
        
    }

    public void ExitStatement([NotNull] DiceParser.StatementContext context) {
        
    }


    public IErrorNode Error {get;set;}

    public void VisitErrorNode(IErrorNode node) {
        Error = node;
    }

    public void VisitTerminal(ITerminalNode node) {
        
    }

 
}
