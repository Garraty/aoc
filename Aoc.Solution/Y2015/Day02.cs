using Aoc.Core.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Aoc.Solution.Y2015
{
    public class Day02 : ISolution
    {
        public object SolvePart1(string input, CancellationToken token = default)
        {
            var sizes = GetSizes(input);
            return sizes.Select(x => CalcSquare(x)).Sum();
        }

        public object SolvePart2(string input, CancellationToken token = default)
        {
            var sizes = GetSizes(input);
            return sizes.Select(x => CalcBowRibbon(x)).Sum();
        }

        public List<List<int>> GetSizes(string input)
        {
            List<List<int>> result = new();
            string[] list = input.Split(new[] { "\r\n", "\n", "\r" }, System.StringSplitOptions.None);

            foreach (string item in list)
            {
                List<int> boxSizes = new();
                item.Split('x').ToList().ForEach(x => boxSizes.Add(int.Parse(x)));
                result.Add(boxSizes);
            }
            return result;
        }
        public int CalcSquare(List<int> sizes)
        {
            sizes.Sort();
            return 2 * (sizes[0] * sizes[1] + sizes[1] * sizes[2] + sizes[2] * sizes[0]) + sizes[0] * sizes[1];
        }

        public int CalcBowRibbon(List<int> sizes)
        {
            sizes.Sort();
            return 2 * (sizes[0] + sizes[1]) + sizes[0] * sizes[1] * sizes[2];
        }
    }
}
