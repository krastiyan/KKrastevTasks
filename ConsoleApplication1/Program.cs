using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an int array in format element;element;...;element");
            string[] input = Console.ReadLine().Split(';');
            int[] intArray = new int[input.Length];
            for (int i=0; i < input.Length ;i++) 
            {
                intArray[i] = int.Parse(input[i]);
            }

            Console.WriteLine("\nThe content of array from input is: ");
            Sorter.PrintArrayInConsole(intArray);

            Sorter f1stSorter = new SelectionSorter();
            int[] result = f1stSorter.Sort(intArray);
            Console.WriteLine("\n\nSorted array content is now: ");
            Sorter.PrintArrayInConsole(result);
            Console.WriteLine("\n\nThat's all, thanks :)");
        }
    }
}
