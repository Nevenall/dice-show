// Define a grammar called Dice
// Dice grammar starts with only a single label and dice spec
grammar Dice;
options { language=CSharp_v4_5; }

statement: (LABEL ':')? dice (',' dice)*;
// actually, fudge dice should be rolled as 4f or 2f, the sides are already defined
dice: NUMBER ('d'|'D') NUMBER;	 

NUMBER: [0-9]+;
LABEL: [a-zA-Z ,0-9_]+;