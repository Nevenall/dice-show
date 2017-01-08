using System.Collections.Generic;

namespace DiceShow.Model
{

	public class RolledDice : Dice
	{
		public IEnumerable<int> Rolls { get; set; }


	}

}