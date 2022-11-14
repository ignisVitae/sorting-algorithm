using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sorting_algorithm
{
    public class NonOptimizedAlgorithm: ISortingAlgorithm
    {
        public void Sort (double[] items)
        {
            double[] buffer = new double[items.Count()];

            BreakMerge(items, buffer, 0, items.Count() - 1);
        }

        private void BreakMerge (double[] items, double[] buffer, int minIndex, int maxIndex)
        {
            if (minIndex < maxIndex)
            {
                int midIndex = (minIndex + maxIndex) / 2;

                BreakMerge(items, buffer, minIndex, midIndex);
                BreakMerge(items, buffer, midIndex + 1, maxIndex);

                int left = minIndex;
                int right = midIndex + 1;

                for (int i = minIndex; i <= maxIndex; i++)
                {
                    if (items[left] < items[right])
                    {
                        buffer[i] = items[left];
                        ++left;

                        if (left > midIndex)
                            for (int j = right; j <= maxIndex; j++)
                            {
                                i++;
                                buffer[i] = items[j];
                            }
                    }
                    else
                    {
                        buffer[i] = items[right];
                        ++right;

                        if (right > maxIndex && left <= midIndex)
                            for (int j = left; j <= midIndex; j++)
                            {
                                i++;
                                buffer[i] = items[j];
                            }
                    }
                }

                for (int i = 0; i <= maxIndex; i++)
                    items[i] = buffer[i];
            }
        }
    }
}