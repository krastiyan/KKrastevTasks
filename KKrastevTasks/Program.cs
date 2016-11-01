using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKrastevTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Careate 2-dimencional array as defined by user
            //Initialize array with user input values
            //Initialize array by default with integers from 0 to what's needed
            //Let user specify which array member to increment

            int xSize, ySize, value=0;
            Console.WriteLine("Enter xSize:");
            xSize = int.Parse(Console.ReadLine());
            //int.TryParse(Console.ReadLine(), ySize);
            Console.WriteLine("Enter ySize:");
            ySize = int.Parse(Console.ReadLine());

            var array = new int[xSize, ySize];

            for(int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++) array[i,j] = value++;
            }

            Console.WriteLine("Thanks, good user! ;)\nYour array content currently is:");
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++) Console.WriteLine($"Row {i} Column {j} = {array[i, j]}");
            }

            string endPlaySignal = "finitto!", userInput="";
            string[] coordinates;
            int xPointer, yPointer;
            //Console.WriteLine($"Which element of your {xSize},{ySize} matrix to increment\n /To exit enter: {endPlaySignal}/");
            do
            {
                Console.WriteLine($"Which element of your {xSize} {ySize} matrix to increment\n /To exit enter: {endPlaySignal}/");
                coordinates = Console.ReadLine().Split(' ');
                //Console.WriteLine($"\nuserInput={userInput}\n");
                userInput = coordinates[0];
                if (coordinates.Length < 2 && !userInput.Equals(endPlaySignal)) {
                        Console.WriteLine("Wrong input: Point element to increment like this: xPointer yPointer\n");
                        continue;
                }
                if (int.TryParse(userInput, out xPointer))
                {
                    if (!int.TryParse(coordinates[1], out yPointer))
                    {
                        Console.WriteLine($"Wrong input: value {coordinates[1]} not a digit!!");
                        continue;
                    }

                    if (xPointer >= xSize || xPointer < 0 || yPointer >= ySize || yPointer < 0)
                    {
                        Console.WriteLine($"Enter pointers between 0 and {xSize} for x axis, and between 0 and {ySize} for y axis! ;)");
                    }
                    else
                    {
                        array[xPointer, yPointer]++;
                        Console.WriteLine("Thanks, good user! ;)\nYour array content currently is:");
                        for (int i = 0; i < xSize; i++)
                        {
                            for (int j = 0; j < ySize; j++) Console.Write(array[i, j]);
                            Console.WriteLine();
                        }
                    }
                }
                else if (!userInput.Equals(endPlaySignal))
                {
                    Console.WriteLine($"Wrong input: value {userInput} not a digit!!");
                    continue;
                }
            } while (!userInput.Equals(endPlaySignal));

            Console.WriteLine("Thank you for playing! Have a nice day! :)");
        }
    }
}
