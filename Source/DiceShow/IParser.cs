using DiceShow.Models;

namespace DiceShow
{
    public interface IParser
    {

        Roll Parse(string raw);


    }
}