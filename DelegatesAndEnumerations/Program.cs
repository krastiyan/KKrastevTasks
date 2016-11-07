using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEnumerations
{
    class Program
    {
        //Enumerable choises = new Enumerable() { };

        //public enum Operations
        //{
        //    add,
        //    sub,
        //    mul
        //};

        public delegate int OperationToDo(int x, int y);

        public static void Main(string[] args)
        {


            Console.WriteLine("Enter 2 numbers using format <number><space><number>:");
            int[] numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Console.WriteLine("Enter operation to perform on numbers:");
            Operations operation = (Operations)Enum.Parse(typeof(Operations), Console.ReadLine());
            OperationToDo operationDone = OperationFactory.GiveMeOperation(operation);
            //Below switch replaced by call to factory
            //switch (operation)
            //{
            //    case Operations.add: operationDone += add; break;
            //    case Operations.sub: operationDone += subtract; break;
            //    case Operations.mul: operationDone += multiply; break;
            //}

            Console.WriteLine("Operation result is: " + operationDone(numbers[0], numbers[1]));

        }//main method

        public static int add(int x, int y)
        {
            Console.WriteLine($"\n\tPerforming {x} + {y}");
            return x + y;
        }

        public static int subtract(int x, int y)
        {
            Console.WriteLine($"\n\tPerforming {x} - {y}");
            return x - y;
        }

        public static int multiply(int x, int y)
        {
            Console.WriteLine($"\n\tPerforming {x} * {y}");
            return x * y;
        }
    }
}
//Use Delegate, Enumeration and console input to perform operation as chosen