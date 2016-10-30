using DiceShow.Ops.Models;

namespace DiceShow.Ops.Rolling
{
    public interface IEvaluator
    {
        Evaluated Evaluate(Statement roll);
    }
}