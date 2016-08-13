namespace DiceShow {
	public interface IParsed {
		bool WasSuccessful { get; }
		IStatement Statement { get; }
		
		// if the parsing was not successful
		// this will contain the information
		// about that error, what the error is
		// maybe even a highlight of what went
		// erong if we can do it
		// 
		object Error { get; }
	}
}