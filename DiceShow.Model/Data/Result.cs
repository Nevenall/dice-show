namespace DiceShow.Model
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;


	public class MyResult
	{
		public IEnumerable<RolledDice> RolledDice { get; set; }
			
		public override string ToString()
		{
			var q = from d in RolledDice
					select $"{d.Id} {{d{d.Sides}: {string.Join(", ", d.Rolls)}}}";

			return $"{string.Join(" ", q)}";
		}
	}
}