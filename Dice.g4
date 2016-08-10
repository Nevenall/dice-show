// Define a grammar called Dice
grammar Dice;
r  : LABEL ;         						// match a label followed by dice specificiation
LABEL : [a-zA-Z \t\r\n]+ ':' ;         // match a label for a rolls
WS : [ \t\r\n]+ -> skip ; 					// skip spaces, tabs, newlines

