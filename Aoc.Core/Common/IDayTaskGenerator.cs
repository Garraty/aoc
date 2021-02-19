using System.Collections.Generic;

namespace Aoc.Core.Common
{
    public interface IDayTaskGenerator
    {
        List<DayTask> Generate();
    }
}
