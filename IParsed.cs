namespace DiceStream {
	public interface IParsed {
		bool WasSuccessful { get; }
		IStatement Statement { get; }
	}
}