namespace DiceShow
{
    public class Result
    {
        // Result, is rolled dice.
        // how to represent that? 
        // we want know what each original die was
        //{ d6 = 3, d6 = 2 }
        // or d6{1, 5, 6, 3}, d10{2, 10, 6}
        //  then could order them
        // also, keep the dice in the same order as they were rolled
        // if dice have an id, then 
        // attack {d8: 4, 6, 5}
        // that is better \
        // {2d4: 3, 4}

		  


        public override string ToString()
        {
            return $"";
        }
    }
}