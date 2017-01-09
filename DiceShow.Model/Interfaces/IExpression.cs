namespace DiceShow.Model
{
	public interface IExpression
	{
		MyResult Eval(Dice dice);
		// if we have various implementations of iexpression to represent 
		// the different ways we can evaluate a collection of dice rolls.
		// dice rolls, that important. 
		// we can't evaluate just plain dice. We have to roll them first
		// then we can evaluate them. 
		// so, expressions inform the way we evaluate rolls
		// and then 

	}

}