using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static string RequestConsoleInput()
        {
            Console.WriteLine("\n\t\tChoose from following options:"
                + "\n\t0 - Enter Person's data from console"
                + "\n\t1 - Print Person's data on console"
                + "\n\t2 - Enter Person's data from file"
                + "\n\t3 - Print Person's data into file"
                + "\n\tquit - Exit program"
                );
            return Console.ReadLine();
        }//RequestConsoleInput

    }
}
