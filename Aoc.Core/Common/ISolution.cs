using System.Threading;

namespace Aoc.Core.Common
{

    public delegate object SolvePart(string input, CancellationToken token = default);

    public delegate SolvePart SolutionMapper(DayTask dayTask);

    public interface ISolution
    {
        object SolvePart1(string input, CancellationToken token = default);
        object SolvePart2(string input, CancellationToken token = default);
    }
}
