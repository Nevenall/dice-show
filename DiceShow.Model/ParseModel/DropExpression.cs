using System;

namespace DiceShow.Model
{
	public class DropExpression : IExpression
	{
		public Target Target
		{
			get; set;
		}

		public MyResult Eval(Dice dice)
		{
			throw new NotImplementedException();
		}
	}
}