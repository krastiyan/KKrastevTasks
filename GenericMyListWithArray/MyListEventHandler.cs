using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMyListWithArray
{
    public delegate void MyListDelegate<T>(T whatToType);

    public class MyListEventHandler<T>
    {
        public event MyListDelegate<T> OnAdd;
        public event MyListDelegate<T> OnRemove;

        public MyListEventHandler(MyListDelegate<T> onAddEvent, MyListDelegate<T> onRemoveEvent)
        {
            OnAdd += onAddEvent;
            OnRemove += onRemoveEvent;
        }//Connstrutor

        public void InvokeOnAddEventHandler(T value)
        {
            Console.WriteLine($"\n\tAdding element with value {value.ToString()}");
            OnAdd(value);
        }

        public void InvokeOnRemoveEventHandler(T value)
        {
            Console.WriteLine($"\n\tAt Removing element typing its value: {value.ToString()}");
            OnRemove(value);
        }

        //public static void OnAddHandler(string whatToType)
        //{
        //    Console.WriteLine($"\n\tTyping in OnAddHandler: {whatToType}\n");
        //}

        //public static void OnRemoveHandler(string whatToType)
        //{
        //    Console.WriteLine($"\n\tTyping in OnRemoveHandler: {whatToType}\n");
        //}
    }//Event handler class
}
