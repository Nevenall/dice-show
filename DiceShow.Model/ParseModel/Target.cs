namespace DiceShow.Model
{
	public class Target
	{
		public int Number { get; set; }

		public bool OpenEnded { get; set; }
		public bool GreaterThanOrEqual { get; set; }
		public bool LessThanOrEqual { get; set; }

		public bool Lowest { get; set; }
		public bool Highest { get; set; }
	}
}