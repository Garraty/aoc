using Aoc.Core;
using Aoc.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Aoc
{
    class Program
    {
        static async Task Main(string[] args)
        {

            IDayTaskGenerator dayTaskGenerator = new DayTaskGenerator().Year(2015).MinDay(1).MaxDay(1);

            SolutionMapper solutionMapper = (dayTask) =>
            {
                ISolution solution = (ISolution)Activator.CreateInstance("Aoc.Solution", $"Aoc.Solution.Y{dayTask.Year}.Day{dayTask.Day:00}").Unwrap();
                return dayTask.DayTaskPart switch
                {
                    DayTaskPart.One => solution.SolvePart1,
                    DayTaskPart.Two => solution.SolvePart2,
                    _ => throw new NotImplementedException()
                };
            };

            ISolutionRunner solutionRunner = new SolutionRunner().CancelTimeMs(1000).DayTaskGenerator(dayTaskGenerator).SolutionMapper(solutionMapper);

            List<DayTaskResult> dayTaskResults = await solutionRunner.Run();
            foreach (DayTaskResult dtr in dayTaskResults)
            {
                Console.WriteLine($"Y{dtr.DayTask.Year}.D{dtr.DayTask.Day:00}.P{(int)dtr.DayTask.DayTaskPart}: {dtr.Result} ({dtr.ElapsedMs}ms)");
            }
        }
    }
}
