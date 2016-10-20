using DiceShow.Models;
namespace DiceShow
{
    public interface IEvaluator
    {
        Evaluated Evaluate(Statement roll);
    }
}