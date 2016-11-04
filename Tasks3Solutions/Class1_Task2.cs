using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks3Solutions
{
    public class Class1_Task2
    {
        public static void Main(string[] args)
        {
            //Resolving tasks 1 and 2 together

            Console.Write("\nPlease enter person's name:");
            string nameInput = Console.ReadLine();
            Console.Write("\nPlease enter person's age:");
            //int ageInput = int.Parse(Console.ReadLine());
            int ageInput;
            if (int.TryParse(Console.ReadLine(), out ageInput)) {
                Console.WriteLine("Successfully added age value :)");
            } else
            {
                Console.WriteLine("Could NOT add age value ):");
            }
            Person object1, object2, object3;
            object1 = new Person();
            object2 = new Person(nameInput);
            object3 = new Person(nameInput, ageInput);
            Console.WriteLine($"1st Person data: name {object1.Name} age {object1.age}");
            Console.WriteLine($"2nd Person data: name {object2.Name} age {object2.age}");
            Console.WriteLine($"3rd Person data: name {object3.Name} age {object3.age}");
        }
    }//Class1

    }//namespace
