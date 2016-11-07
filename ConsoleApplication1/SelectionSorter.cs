using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class SelectionSorter : Sorter
    {
        public override int[] Sort(int[] arrayToSrt)
        {
            int[] result = base.CopyIntArray(arrayToSrt);
            for (int j = 0; j < result.Length - 1; j++)
            {
                /* find the min element in the unsorted a[j .. n-1] */

                /* assume the min is the first element */
                int iMin = j;
                /* test against elements after j to find the smallest */
                for (int i = j + 1; i < result.Length; i++)
                {
                    /* if this element is less, then it is the new minimum */
                    if (result[i] < result[iMin])
                    {
                        /* found new minimum; remember its index */
                        iMin = i;
                    }
                }

                if (iMin != j)
                {
                    //swap(a[j], a[iMin]);
                    int buf = result[j];
                    result[j] = result[iMin];
                    result[iMin] = buf;
                }
            }//copied sort

            return result;
        }//Sort method
    }
}
