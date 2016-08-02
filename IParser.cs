namespace DiceStream {

    /// <summary>
    /// Parse a dice request in an executable statement
    /// </summary>
    public interface IParser {
        IParsed Parse(string rawStatement);
    }
}