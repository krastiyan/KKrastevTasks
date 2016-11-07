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
            int[] result = arrayToSrt.Select(x => x).ToArray();//base.CopyIntArray(arrayToSrt);
            result[0] = 5;
            Console.WriteLine(arrayToSrt[0]);
            return result.OrderBy(x => x).ToArray();
        }
    }
}


