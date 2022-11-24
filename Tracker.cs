using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace sorting_algorithm
{
    public class Tracker
    {
        public static TimeSpan MeasureTime (Action func)
        {
            Stopwatch stopwatch = new();

            stopwatch.Start();
            func.DynamicInvoke();
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static List<TimeSpan> MeasureTime (List<Action> funcList)
        {
            Stopwatch stopwatch = new();
            List<TimeSpan> measureTimeList = new();

            foreach (var func in funcList)
            {
                stopwatch.Start();
                func.DynamicInvoke();
                stopwatch.Stop();

                measureTimeList.Add(stopwatch.Elapsed);
                stopwatch.Reset();
            }

            return measureTimeList;
        }
    }
}