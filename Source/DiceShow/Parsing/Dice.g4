// Define a grammar called Dice
// Dice grammar starts with only a single label and dice spec
grammar Dice;
options { language=CSharp_v4_5; }

roll:  dice (SEPARATOR dice)*;
// actually, fudge dice should be rolled as 4f or 2f, the sides are already defined
dice: ID? INT ('d'|'D') INT;

ID: [a-zA-Z]+ ;
SEPARATOR: [;, ]+;
INT: [0-9]+ ;