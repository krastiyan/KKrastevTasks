using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BubbleSorter : Sorter
    {
        public override int[] Sort(int[] arrayToSrt)
        {
            int[] result = base.CopyIntArray(arrayToSrt);
            return result.OrderBy(x => x).ToArray();
        }
    }
}
