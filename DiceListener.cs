//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.3.1-SNAPSHOT
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Dice.g4 by ANTLR 4.5.3.1-SNAPSHOT

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="DiceParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.3.1-SNAPSHOT")]
[System.CLSCompliant(false)]
public interface IDiceListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="DiceParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] DiceParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DiceParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] DiceParser.StatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DiceParser.dice"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDice([NotNull] DiceParser.DiceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DiceParser.dice"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDice([NotNull] DiceParser.DiceContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DiceParser.die"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDie([NotNull] DiceParser.DieContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DiceParser.die"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDie([NotNull] DiceParser.DieContext context);
}
