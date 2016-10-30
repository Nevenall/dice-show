

using System;

namespace DiceShow.Ops.Rolling
{

    public class RandomRoller : IRoller
    {

        private static Random _random = new Random();
        private static object _sync = new object();

        public int Roll(int minimum, int maximum)
        {
            lock (_sync)
            {
                /// .net random is not inclusive on the max end, so we make so.
                return _random.Next(minimum, maximum + 1);
            }
        }
    }
}