using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMyListWithArray
{
    public class MyHandlersStringImplementations
    {
        public static void OnAddHandler(string whatToType)
        {
            Console.WriteLine($"\n\tTyping in OnAddHandler: {whatToType}\n");
        }

        public static void OnRemoveHandler(string whatToType)
        {
            Console.WriteLine($"\n\tTyping in OnRemoveHandler: {whatToType}\n");
        }
    }
}
