
namespace DiceShow.Model
{
    public interface IEvaluator
    {
        Evaluated Evaluate(Statement roll);
    }
}