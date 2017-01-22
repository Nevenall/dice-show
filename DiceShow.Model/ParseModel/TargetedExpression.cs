using System;

namespace DiceShow.Model
{
	public class TargetedExpression : IExpression
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