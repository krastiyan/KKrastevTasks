using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public abstract class Sorter
    {
        public abstract int[] Sort(int[] arrayToSrt);
        protected int[] CopyIntArray(int[] source)
        {
            int[] result = new int[source.Length];
            for (int i = 0; i < source.Length; i++) result[i] = source[i];
            return result;
        }
        public static void PrintArrayInConsole(int[] printed)
        {
            foreach (int el in printed) Console.Write(el + ";");
        }
    }
}
