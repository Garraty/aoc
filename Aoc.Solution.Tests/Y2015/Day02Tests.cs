using System.Linq;
using Xunit;

namespace Aoc.Solution.Y2015.Tests
{
    public class Day02Tests
    {
        [Theory()]
        [InlineData("2x3x4", 58)]
        [InlineData("1x1x10", 43)]
        public void SolvePart1Test(string input, int expected)
        {
            Day02 solution = new();
            Assert.Equal(expected, solution.SolvePart1(input));
        }

        [Theory()]
        [InlineData("2x3x4", 34)]
        [InlineData("1x1x10", 14)]
        public void SolvePart2Test(string input, int expected)
        {
            Day02 solution = new();
            Assert.Equal(expected, solution.SolvePart2(input));
        }
    }
}
