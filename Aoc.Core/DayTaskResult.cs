namespace Aoc.Core
{
    public class DayTaskResult
    {
        public DayTask DayTask { get; set; }
        public object Result { get; set; }
        public long ElapsedMs { get; set; }
        public bool IsError { get; set; }
    };
}
