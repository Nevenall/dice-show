using System;
using System.Linq;
using Xunit;
using DiceShow;


namespace DiceShow.Tests
{
    public class Tests
    {
        [Fact]
        public void random_roller_returns_distributed_results()
        {
            var roller = new RandomRoller();

            var counts = new int[10];
            var distribution = new double[10];
            var iterations = 10000;

            var results = Enumerable.Range(1, iterations).Select(i =>
            {
                var r = roller.Roll(0, 9);
                counts[r]++;
                distribution[r] = (double)counts[r] / iterations;
                return r;
            }).ToArray();


            Assert.All(results, r => Assert.InRange(r, 0, 9));
            Assert.All(distribution, d => Assert.True(.1 - d <= .01, $"distribution out of .01 range"));
        }


    }
}
