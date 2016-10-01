using DiceShow.Models;
namespace DiceShow
{
    public interface IExecuter
    {
        Result Execute(Roll roll);
    }
}