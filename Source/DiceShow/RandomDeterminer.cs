

using System;

namespace DiceShow
{

    public class RandomDeterminer : IDeterminer
    {

        private static Random _random;
        private static object _sync;

        static RandomDeterminer()
        {
            // random works over several calls. 
            // If you create a new instance for each call you will get the same result often.
            _random = new Random();
        }

        public int Determine(int minimum, int maximum)
        {
            lock (_sync)
            {
                return _random.Next(minimum, maximum + 1);
            }
        }
    }
}