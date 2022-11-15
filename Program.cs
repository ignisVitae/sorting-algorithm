using System.IO;
using sorting_algorithm;

double[] array = new double[25120];
array.RandomFill();
TimeSpan measureTime = Tracker.MeasureTime(() => new UnOptimizedAlgorithm().Sort(array));

using (StreamWriter fileStream = new StreamWriter(@"C:\Users\13nas\Desktop\measureTime.txt", true))
    fileStream.WriteLine(measureTime.TotalMilliseconds);