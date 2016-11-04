using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks3Solutions
{
    class CopmlexTaskMain
    {
        private static Complex inputCopmlex(string messageToType)
        {
            bool done = false;
            string userInput = null;
            string[] parsedInput;
            int f1stInt=0, s2ndInt=0;
            do
            {
                Console.WriteLine(messageToType);
                userInput = Console.ReadLine();
                parsedInput = userInput.Split(new string[] { " " }, StringSplitOptions.None);
                if (!int.TryParse(parsedInput[0], out f1stInt))
                {
                    Console.WriteLine($"Invalid input {f1stInt} entered!");
                    continue;
                }

                if (!int.TryParse(parsedInput[1], out s2ndInt))
                {
                    Console.WriteLine($"Invalid input {s2ndInt} entered!");
                    continue;
                }
                Console.WriteLine("\nPassed through heree :-D\n");
                done = true;
            } while (!done);
            return new Complex(f1stInt, s2ndInt);
        }//inputCopmlex method

        public static void Main(string[] args)
        {
            string userInput = null, quitComand = "quit";
            Complex f1stComplex, s2ndComplex;
            const string addCommand ="add", subtractCommand="sub";
            do
            {
                f1stComplex = inputCopmlex("\n\nEnter 1st complex number in format {real} {imaginary}:");
                s2ndComplex = inputCopmlex("\n\nEnter 2nd complex number in format {real} {imaginary}:");

                Console.WriteLine("Enter add/sub operation to do with those 2 Complex numbers:");
                if ((userInput = Console.ReadLine()).Equals(quitComand))
                {
                    continue;
                }

                switch (userInput)
                {
                    case addCommand:
                        Console.WriteLine("\nAdding the 2 complexes resulted in:\n"+(f1stComplex+s2ndComplex));
                        break;
                    case subtractCommand:
                        Console.WriteLine("\nSubtracting the 2 complexes resulted in:\n" + (f1stComplex - s2ndComplex));
                        break;
                    default:
                        Console.WriteLine("\n\tUnknown command entered - try again ;)\n\n");
                        break;
                }

                Console.WriteLine("\n\nType go to continue / quit to exit:");
                userInput = Console.ReadLine();

            } while (!userInput.Equals(quitComand));

        }
    }
}
