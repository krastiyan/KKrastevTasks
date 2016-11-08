using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndCall
{
    public delegate void MyListDelegate(string whatToType);

    public class MyListEventHandler
    {
        public event MyListDelegate OnAdd;
        public event MyListDelegate OnRemove;

        public MyListEventHandler(MyListDelegate onAddEvent, MyListDelegate onRemoveEvent)
        {
            OnAdd += onAddEvent;
            OnRemove += onRemoveEvent;
        }//Connstrutor

        public void InvokeOnAddEventHandler(string value)
        {
            OnAdd(value);
        }

        public void InvokeOnRemoveEventHandler(string value)
        {
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
