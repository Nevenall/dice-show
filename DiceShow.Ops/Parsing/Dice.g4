// Define a grammar called Dice
// Dice grammar starts with only a single label and dice spec
// Don't forget to invoke bat file with -package DiceShow.Ops.Parsing.Internal

grammar Dice;
options { language=CSharp_v4_5; }

@members {  
	public const string GrammarVersion = "0.1.2";
	public const string VersionReleaseNotes = @"
		0.1.2 - removed ; as a SEPARATOR option
		0.1.1 - Moved SEPARATOR
		0.1.0 - Multiple dice in groups with optional labels.
	";
}

statement: dice (SEPARATOR+ dice)*;
// actually, fudge dice should be rolled as 4f or 2f, the sides are already defined
dice: ID? INT ('d'|'D') INT;

ID: [a-zA-Z]+ ;
SEPARATOR: [, ];
INT: [0-9]+ ;