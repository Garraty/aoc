using Aoc.Core;
using System.Linq;
using System.Threading;

namespace Aoc.Solution.Y2015
{
    public class Day01 : ISolution
    {
        public object SolvePart1(string input, CancellationToken token = default)
        {
            return input.ToCharArray().Aggregate(0, (floor, ch) => floor + MoveDirection(ch));
        }

        public object SolvePart2(string input, CancellationToken token = default)
        {
            int floor = 0;
            foreach ((char ch, int pos) in input.ToCharArray().Select((ch, pos) => (ch, pos)))
            {
                floor += MoveDirection(ch);
                if (floor == -1)
                    return pos + 1;
            }
            return -1;
        }

        public int MoveDirection(char ch) => ch == '(' ? 1 : -1;
    }
}
