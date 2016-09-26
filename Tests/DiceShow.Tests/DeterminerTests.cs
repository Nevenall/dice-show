using System;
using System.Linq;
using Xunit;
using DiceShow;


namespace DiceShow.Tests
{
    public class Tests
    {
        [Fact]
        public void random_determiner_returns_distributed_results()
        {
            var determiner = new RandomDeterminer();

            var counts = new int[10];
            var distribution = new double[10];

            var results = Enumerable.Range(1, 1000).Select(i =>
            {
                var r = determiner.Determine(0, 9);
                counts[r]++;
                distribution[r] = (double)counts[r] / i;
                return r;
            }).ToArray();


            Assert.True(results.All(r => r >= 0 && r <= 9));


            System.Console.WriteLine(string.Join(",", distribution));

            // test that a particular result is no more common then another

        }


    }
}
