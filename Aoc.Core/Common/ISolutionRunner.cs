using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aoc.Core.Common
{
    public interface ISolutionRunner
    {
        Task<List<DayTaskResult>> Run();
    }

}
