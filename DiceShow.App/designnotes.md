So, how does the parse tree listener handle assembling the results? 
we can do an error, 
can we accumulate the results through a visit?



if we enter a dice, we want to assemlbe results equal to the number. 

the dice parser can do two things
1. it can parse the dice and calculate the reuslts., 
2. or it can assemble a datastucture of dice that we can then calculate the results on

I like the second better because then we have better separate of concerns. 


when we get to the web app part I want to be able to store the initial text and the parsed results. 

we have to parse the entire statement to figure out how to calculate each result and also to display them. those are legtitimate things. 

The dice parser will construct an abstract structure.
Basically a roll. 

one roll or logged roll. it's not logged until it's written. 
this is more like a roll. close enough anyway. 

So, the dice parser constructs a Roll object which can then be evaluated. it also means that the we can test the evaluation by manually constructing test objects. 
K. Good. 


Roll
	