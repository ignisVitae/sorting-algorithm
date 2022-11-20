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

                bool flag = true;
                int buf = 0;
                int left = minIndex;
                int right = midIndex + 1;

                for (int i = minIndex, j = 0; i <= maxIndex; i++, j++)
                {
                    if (items[left] < items[right])
                    {
                        buffer[j] = items[left];
                        left++;

                        if (left > midIndex) break;
                    }
                    else
                    {
                        buffer[j] = items[right];
                        right++;

                        if (right > maxIndex && left == minIndex)
                        {
                            int condition = midIndex + 1;
                            if ((maxIndex - minIndex + 1) % 2 != 0) condition = midIndex;

                            for (int k = maxIndex; k >= condition; k--, midIndex--)
                                items[k] = items[midIndex];

                            int l = 0;
                            if (!flag) l = minIndex - buf;
                            for (int k = minIndex; k < condition; k++, l++)
                                items[k] = buffer[l];

                            break;
                        }
                    }

                    if (i == midIndex && flag)
                    {
                        for (int k = midIndex + 1; k < right; k++, left++)
                            items[k] = items[left];

                        for (int k = minIndex, l = 0; k <= midIndex; k++, l++)
                            items[k] = buffer[l];

                        if (right > maxIndex) break;
                        flag = false;

                        left = midIndex + 1;
                        buf = midIndex + 1;
                        midIndex = (left + maxIndex) / 2;
                        right = midIndex + 1;
                        minIndex = left;
                        j = -1;
                        BreakMerge(items, buffer, minIndex, maxIndex);
                    }
                }
            }
        }
    }
}