// Define a grammar called Dice
// Dice grammar starts with only a single label and dice spec
grammar Dice;
options {language=CSharp_v4_5;}
statement : LABEL SEMICOLON dice ;    // statment is a LABEL terminated by : followed by dice and an optional modifer expression
dice : (NUMBER die);					// dice are a number and a die 
die :  (DEE|EHPH) SIDES;  			// die is a D or F and the number of sides


LABEL : [a-zA-Z ,]+ ; 
SEMICOLON : ':';
NUMBER : [0-9]+ ;
SIDES : [0-9]+ ;
DEE : [dD] ;
EHPH : [fF] ;
