using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sorting_algorithm
{
    public class OptimizedAlgorithm: ISortingAlgorithm
    {
        public void Sort (double[] items)
        {
            double[] buffer = new double[(items.Count() - 1) / 2 + 1];

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

                        if (left > midIndex) break;
                    }
                    else
                    {
                        buffer[i] = items[right];
                        ++right;

                        if (right > maxIndex)
                        {
                            int condition = midIndex + 1;
                            if (items.Count() % 2 == 0) condition = midIndex;

                            for (int k = maxIndex; k >= condition; k--)
                                items[k] = items[k - condition];

                            for (int k = 0; k < condition; k++)
                                items[k] = buffer[k];

                            break;
                        }
                    }

                    if (i == midIndex && left < midIndex && right < maxIndex)
                    {
                        for (int k = midIndex + 1; k < right; k++)
                            items[k] = items[k - left + 1];

                        for (int k = 0; k <= midIndex; k++)
                            items[k] = buffer[k];

                        left = midIndex + 1;
                        midIndex = (left + maxIndex) / 2;
                    }
                }

                for (int k = midIndex + 1; k <= maxIndex; k++)
                    items[k] = buffer[k - midIndex - 1];
            }
        }
    }
}