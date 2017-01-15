using System;

namespace DiceShow.Model
{
	public class DiceExpression : IExpression
	{


		public DiceExpression()
		{

		}

		public Target Target
		{
			get; set;
		}

		public MyResult Eval(Dice dice)
		{
			/// A dice expression inmplies addition, BUT
			// we might want to explode or reroll the additional die
			// d6 + d6++  roll a d6 and roll and add a d6 that explodes on 


			throw new NotImplementedException();
		}
	}
}