namespace Aoc.Core
{
    public enum DayTaskPart
    {
        One = 1,
        Two = 2
    }

    public record DayTask(int Year, int Day, DayTaskPart DayTaskPart, string Input);
}
