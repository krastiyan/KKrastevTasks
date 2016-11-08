using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMyListWithArray
{
    public class GenericMyHandlersImplementations<T>
    {
        public static void OnAddHandler(T whatToType)
        {
            Console.WriteLine($"\n\tTyping in OnAddHandler: {whatToType}\n");
        }

        public static void OnRemoveHandler(T whatToType)
        {
            Console.WriteLine($"\n\tTyping in OnRemoveHandler: {whatToType}\n");
        }
    }
}
