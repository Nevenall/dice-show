using DiceShow.Models;

namespace DiceShow
{
    public interface IParser
    {

        Parsed Parse(string raw);


    }
}