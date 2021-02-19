using System.Linq;
using Xunit;

namespace Aoc.Solution.Y2015.Tests
{
    public class Day01Tests
    {
        [Theory()]
        [InlineData(new string[] { "(())", "()()" }, 0)]
        [InlineData(new string[] { "(((", "(()(()(", "))(((((" }, 3)]
        [InlineData(new string[] { "())", "))(" }, -1)]
        [InlineData(new string[] { ")))", ")())())" }, -3)]
        public void SolvePart1Test(string[] input, int expected)
        {
            Day01 solution = new();
            input.ToList().ForEach(x => Assert.Equal(expected, solution.SolvePart1(x)));
        }

        [Theory()]
        [InlineData(")", 1)]
        [InlineData("()())", 5)]
        public void SolvePart2Test(string input, int expected)
        {
            Day01 solution = new();
            Assert.Equal(expected, solution.SolvePart2(input));
        }
    }
}
