using System.Collections.Generic;

namespace Aoc.Core
{
    public interface IDayTaskGenerator
    {
        List<DayTask> Generate();
    }
}
