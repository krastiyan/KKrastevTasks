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
            for (int i = 0; i < input.Length; i++)
            {
                intArray[i] = int.Parse(input[i]);
            }

            Console.WriteLine("\nThe content of array from input is: ");
            Sorter.PrintArrayInConsole(intArray);

            Console.WriteLine("\tChoose type of sort to do:\n1 - Selection sort\n2 - Bubble sort\n\t\t\tchoise: ");
            int choise;
            if (!int.TryParse(Console.ReadLine(), out choise))
            {
                Console.WriteLine("Not an int number entered for choise. Sorry, buy and good luck!");
            }
            else
            {
                Sorter f1stSorter;
                if (choise == 1)
                {
                    f1stSorter = new SelectionSorter();
                    Console.WriteLine("\n\nWill do Selection sort...\n");
                }
                else if (choise == 2)
                {
                    f1stSorter = new BubbleSorter();
                    Console.WriteLine("\n\nWill do Bubble sort...\n");
                }
                else
                {
                    f1stSorter = null;
                    Console.WriteLine("\n\nRequested to do UNKNOWN sort type!\n");
                    Console.ReadKey();
                    return;
                }
                int[] result = f1stSorter.Sort(intArray);
                Console.WriteLine("\n\nSorted array content is now: ");
                Sorter.PrintArrayInConsole(result);
                Console.WriteLine("\n\nThat's all, thanks :)");
            }
        }
    }
}
