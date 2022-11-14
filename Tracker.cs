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

            //TODO measure time

            return stopwatch.Elapsed;
        }
    }
}