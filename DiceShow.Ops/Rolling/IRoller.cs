namespace DiceShow.Ops.Rolling
{

    /// <summary>
    /// Determine a result 
    /// </summary>
    public interface IRoller
    {
        int Roll(int minimum, int maximum);
    }
}