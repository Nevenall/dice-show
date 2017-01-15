using System;

namespace DiceShow.Model
{



	public class ScalarExpression : IExpression
	{

		private int _scalar;

		public ScalarExpression(int scalar)
		{
			_scalar = scalar;
		}

		public Target Target
		{
			get; set;
		}

		public MyResult Eval(Dice dice)
		{
			// may change the signature from dice to a collection do rolled dice,
			// becuase that is what we are really interpreting.
			// scalar expression implies we add the dice for a total

			throw new NotImplementedException();

		}
	}
}