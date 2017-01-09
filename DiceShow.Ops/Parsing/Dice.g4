// Define a grammar called Dice
// Dice grammar starts with only a single label and dice spec
// Don't forget to invoke bat file with -package DiceShow.Ops.Parsing.Internal

grammar Dice;
options { language=CSharp_v4_5; }

@members {  
	public const string GrammarVersion = "1.0.0";
	public const string VersionReleaseNotes = @"
		1.0.0 - Support for expression and result keywords
		0.1.2 - removed ; as a SEPARATOR option
		0.1.1 - Moved SEPARATOR
		0.1.0 - Multiple dice in groups with optional labels.
	";
}

statement: dice (SEPARATOR+ dice)*;
// actually, fudge dice should be rolled as 4f or 2f, the sides are already defined

dice: ID? INT ('d'|'D') INT (expression)?;

expression: 
	PLUS INT						# AddScalar
	| MINUS INT					# SubScalar
	| PLUS diceExp				# AddDiceExp
	| MINUS diceExp			# SubDiceExp
	| DROP target				# Drop
	| KEEP target				# Keep
	| COUNT target				# Count
	| REROLL target			# Reroll
	| EXPLODE target			# Explode
	| HIT INT (PLUS|MINUS) 	# Hit
;

diceExp: INT ('d'|'D') INT;

target: 
// consider making the int for target optional. 
// if there's no INT then the target is either the highest or lowest 
	INT (PLUS | MINUS | PLUSPLUS | MINUSMINUS)
	| LOWEST
	| HIGHEST
;

ID: [a-zA-Z]+;
SEPARATOR: [, ];
INT: [0-9]+;
PLUS: '+';
PLUSPLUS: '++';
MINUS: '-';
MINUSMINUS: '--';
DROP: 'drop' | 'Drop' | 'DROP';
KEEP: 'keep' | 'Keep' | 'KEEP';
COUNT: 'count' | 'Count' | 'COUNT';
REROLL: 'reroll' | 'Reroll' | 'REROLL';
EXPLODE: 'explode' | 'Explode' | 'EXPLODE';
HIT: 'hit' | 'Hit' | 'HIT';
LOWEST: 'lowest' | 'Lowest' | 'LOWEST';
HIGHEST: 'highest' | 'Highest' | 'HIGHEST';
