
namespace DiceShow.Ops.Rolling
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using DiceShow.Model;

	public class Executer : IEvaluator
	{

		private IRoller _roller;
		public Executer(IRoller roller)
		{
			_roller = roller;
		}

		public Evaluated Evaluate(Statement statement)
		{
			var ret = new Evaluated();

			try
			{
				ret.Result = new MyResult();
				ret.Result.RolledDice = from d in statement.Dice
												select new RolledDice
												{
													Id = d.Id,
													Number = d.Number,
													Sides = d.Sides,
													Rolls = Enumerable.Range(1, d.Number).Select(idx =>
													{
														var roll = _roller.Roll(1, d.Sides);
                                                        ret.TraceLog.Add($"Rolled {roll} for {d}");
														return roll;
													})
												};
			}
			catch (Exception ex)
			{
				ret.Exception = ex;
			}
			return ret;
		}
	}
}