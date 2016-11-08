using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMyListWithArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //Implement list with arrays & having methods: add, get(int index), remove, contains. Use event handlers, eventually actions and funcs.

            MyGenericListClass<int> myList = new MyGenericListClass<int>(5);
            for (int i = 0; i < 7; i++) myList.Add(i);
            int searchedValue = 4;

            //MyGenericListClass<string> myList = new MyGenericListClass<string>(5);
            //for (int i = 0; i < 7; i++) myList.Add("string." + i);
            //string searchedValue = "string." + 4;

            Console.WriteLine("\n\n\tmyList is now:\n" + myList);

            Console.WriteLine($"Check if list contains value {searchedValue} returns {myList.Contains(searchedValue)}");

            Console.WriteLine($"Will remove element on index 3 = {myList.Get(3)}");

            myList.Remove(3);
            Console.WriteLine("\n\n\tmyList is now:\n" + myList);

        }
    }
}
