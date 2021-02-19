using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aoc.Core
{
    public interface ISolutionRunner
    {
        Task<List<DayTaskResult>> Run();
    }
}
