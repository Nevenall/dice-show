// Define a grammar called Dice
// Dice grammar starts with only a single label and dice spec
grammar Dice;
options { language=CSharp_v4_5; }

roll: (DESCRIPTION ':')? dice (',' dice)*;
// actually, fudge dice should be rolled as 4f or 2f, the sides are already defined
dice: INT ('d'|'D') INT;
// dice have an optional identifier, and an optional expression. You might roll
// 2d6+4, or 2d6+1d4
// wonder how to do that? can dice be part of expression? I guess they can. 
// Or it could be dice or expression
//
	 
INT: [0-9]+ ;
DESCRIPTION: [a-zA-Z _]+ ;
ID: [a-zA-Z_]+;

// add rule to ignore whitespace