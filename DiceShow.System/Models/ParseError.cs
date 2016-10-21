namespace DiceShow.Models
{

    public class ParseError
    {

        public string Symbol { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }

        public override string ToString()
        {
            return $"{{Symbol = {Symbol} Line = {Line} Column = {Column}}}";
        }
    }
}