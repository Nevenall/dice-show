using DiceShow;

namespace DiceShow {
    public interface IExecute {
        IResult Execute(IStatement statement);
    }
}