using DiceShow.Sys.Models;

namespace DiceShow.Sys.Rolling
{
    public interface IEvaluator
    {
        Evaluated Evaluate(Statement roll);
    }
}