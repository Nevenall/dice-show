using DiceShow.Ops.Models;

namespace DiceShow.Ops.Parsing
{
    public interface IParser
    {

        Parsed Parse(string raw);


    }
}