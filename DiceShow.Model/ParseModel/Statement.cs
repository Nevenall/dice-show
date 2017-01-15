
namespace DiceShow.Model
{
	using System.Linq;
	using System.Collections.ObjectModel;

	///
	public class Statement
	{
		public Collection<Dice> Dice { get; set; } = new Collection<Dice>();

		public override string ToString()
		{
			return $"{string.Join(", ", Dice)}";
		}

	}

}