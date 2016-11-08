using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndCall
{
    class Program
    {
        //Implement list with arrays & having methods: add, get(int index), remove, contains. Use event handlers, eventually actions and funcs.

        static void Main(string[] args)
        {

            MyIntListClass myList = new MyIntListClass(5);
            for (int i = 0; i < 7; i++) myList.Add(i);
            Console.WriteLine("\n\n\tmyList is now:\n" + myList);
            Console.WriteLine($"Check if list contains value 4 returns {myList.Contains(4)}");
            Console.WriteLine($"Will remove element on index 3 = {myList.Get(3)}");
            myList.Remove(3);
            Console.WriteLine("\n\n\tmyList is now:\n" + myList);
        }
    }
}
