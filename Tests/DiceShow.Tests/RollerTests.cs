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

            var results = Enumerable.Range(1, 1000).Select(i =>
            {
                var r = roller.Roll(0, 9);
                counts[r]++;
                distribution[r] = (double)counts[r] / i;
                return r;
            }).ToArray();


            Assert.True(results.All(r => r >= 0 && r <= 9));


            System.Console.WriteLine(string.Join(",", from d in distribution select .1 - d));

            // test that a particular result is no more common then another

        }


    }
}
