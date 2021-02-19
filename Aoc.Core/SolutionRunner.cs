using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Aoc.Core
{
    public delegate SolvePart SolutionMapper(DayTask dayTask);

    public class SolutionRunner : ISolutionRunner
    {
        private IDayTaskGenerator _dayTaskGenerator;
        private SolutionMapper _solutionMapper;
        private int _cancelTimeMs;

        public SolutionRunner()
        {
            _cancelTimeMs = 10_000;
        }

        public SolutionRunner DayTaskGenerator(IDayTaskGenerator dayTaskFactory)
        {
            _dayTaskGenerator = dayTaskFactory;
            return this;
        }

        public SolutionRunner SolutionMapper(SolutionMapper solutionMapper)
        {
            _solutionMapper = solutionMapper;
            return this;
        }

        public SolutionRunner CancelTimeMs(int cancelTimeMs)
        {
            _cancelTimeMs = cancelTimeMs;
            return this;
        }

        public async Task<List<DayTaskResult>> Run()
        {
            List<DayTaskResult> dayTaskResults = new();
            Stopwatch timer = new();

            foreach (DayTask dayTask in _dayTaskGenerator?.Generate())
            {
                using CancellationTokenSource cts = new(_cancelTimeMs);
                DayTaskResult dayTaskResult = new() { DayTask = dayTask };
                object result = null;

                try
                {
                    SolvePart solvePart = _solutionMapper(dayTask);
                    timer.Start();
                    result = await Task.Run(() => solvePart(dayTask.Input, cts.Token));
                    timer.Stop();
                }
                catch (Exception ex)
                {
                    result = ex switch
                    {
                        TypeLoadException => "ERROR: Solution not found",
                        OperationCanceledException => "ERROR: Solution was canceled by timeout",
                        _ => $"ERROR: {ex.Message}"
                    };
                    dayTaskResult.IsError = true;
                }
                finally
                {
                    dayTaskResult.Result = result;
                    dayTaskResult.ElapsedMs = timer.ElapsedMilliseconds;
                    dayTaskResults.Add(dayTaskResult);
                    timer.Reset();
                }
            }
            return dayTaskResults;
        }

    }
}
