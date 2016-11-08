using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMyListWithArray
{
    public class MyHandlersIntImplementations
    {
        public static void OnAddHandler(int numberToType)
        {
            Console.WriteLine($"\n\tTyping in OnAddHandler number: {numberToType}\n");
        }

        public static void OnRemoveHandler(int numberToType)
        {
            Console.WriteLine($"\n\tTyping in OnRemoveHandler number: {numberToType}\n");
        }
    }
}
