using System.Collections.Generic;
using System.Linq;

namespace Aoc.Core
{

    public delegate string DayTaskInputGetter(int year, int day);

    public class DayTaskGenerator : IDayTaskGenerator
    {
        private int _year;
        private int _minDay;
        private int _maxDay;
        private List<DayTaskPart> _dayTaskParts;
        public DayTaskInputGetter _inputGetter;

        public DayTaskGenerator()
        {
            _dayTaskParts = new();
            _dayTaskParts.Add(DayTaskPart.One);
            _dayTaskParts.Add(DayTaskPart.Two);
        }

        public DayTaskGenerator Year(int year)
        {
            _year = year;
            return this;
        }

        public DayTaskGenerator Day(int day)
        {
            _minDay = _maxDay = day;
            return this;
        }
        public DayTaskGenerator MinDay(int day)
        {
            _minDay = day;
            return this;
        }

        public DayTaskGenerator MaxDay(int day)
        {
            _maxDay = day;
            return this;
        }

        public DayTaskGenerator OnlyPartOne()
        {
            _dayTaskParts.Clear();
            _dayTaskParts.Add(DayTaskPart.One);
            return this;
        }

        public DayTaskGenerator OnlyPartTwo()
        {
            _dayTaskParts.Clear();
            _dayTaskParts.Add(DayTaskPart.Two);
            return this;
        }

        public DayTaskGenerator InputGetter(DayTaskInputGetter inputGetter)
        {
            _inputGetter = inputGetter;
            return this;
        }

        public List<DayTask> Generate()
        {
            List<DayTask> dayTasks = new();
            foreach (int day in Enumerable.Range(_minDay, _maxDay - _minDay + 1))
            {
                foreach (DayTaskPart dayTaskPart in _dayTaskParts)
                {
                    DayTask dayTask = new(_year, day, dayTaskPart, _inputGetter?.Invoke(_year, day));
                    dayTasks.Add(dayTask);
                }
            }
            return dayTasks;
        }
    }
}
