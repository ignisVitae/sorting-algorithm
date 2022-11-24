using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sorting_algorithm
{
    public static class Extension
    {
        public static void RandomFill (this double[] items)
        {
            Random obj = new();
            for (int i = 0 ; i <= items.Length - 1; i++)
                items[i] = obj.NextDouble();
        }

        public static void ValidateArray (this double[] items)
        {
            bool error = false;

            for (int i = 0; i <= items.Count() - 2; i++)
                if (items[i] > items[i + 1])
                {
                    System.Console.WriteLine($"- Error [{i}] and [{i + 1}]");
                    error = true;
                }

            if (error)
            {
                System.Console.WriteLine("Sorted array:");

                for (int i = 0; i < items.Count(); i++)
                    System.Console.WriteLine($"[{i}] {items[i]}");
            }
            else System.Console.WriteLine(" - Validation was successful");

            System.Console.WriteLine();
        }
    }
}