// Define a grammar called Dice
// Dice grammar starts with only a single label and dice spec
grammar Dice;
options { language=CSharp_v4_5; }

statement: LABEL SEMICOLON dice;
dice: NUMBER (DEE|EHPH) SIDES;	 

LABEL: [a-zA-Z ,]+;
SEMICOLON: ':';
COMMA: ',';

NUMBER: [0-9]+;
SIDES: [0-9]+;

DEE: [dD];
EHPH: [fF];
