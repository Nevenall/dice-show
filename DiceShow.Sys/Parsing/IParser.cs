using DiceShow.Sys.Models;

namespace DiceShow.Sys.Parsing
{
    public interface IParser
    {

        Parsed Parse(string raw);


    }
}