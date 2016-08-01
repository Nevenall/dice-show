namespace DiceStream {
    public interface IExecute
    {
        IResult Execute(IStatement statement);
    }
}