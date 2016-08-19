// Define a grammar called Dice
// Dice grammar starts with only a single label and dice spec
grammar Dice;
options { language=CSharp_v4_5; }

LABEL: [a-zA-Z ,]+;
SEMICOLON: ':';
COMMA: ',';

NUMBER: [0-9]+;

DEE: [dD];
EHPH: [fF];

statement: dice ;
dice: NUMBER (DEE|EHPH) NUMBER;	 

