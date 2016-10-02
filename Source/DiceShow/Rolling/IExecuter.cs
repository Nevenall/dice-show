using DiceShow.Models;
namespace DiceShow
{
    public interface IExecuter
    {
        Executed Execute(Roll roll);
    }
}