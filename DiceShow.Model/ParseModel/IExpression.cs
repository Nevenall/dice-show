namespace DiceShow.Model
{
	public interface IExpression
	{
		MyResult Eval(Dice dice);

		Target Target { get; set; }




	}

}