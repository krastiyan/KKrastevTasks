using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndCall
{
    public class MyIntListClass
    {
        protected int InitialCapacity;
        protected int LastFilledElementIndex = -1;
        protected int [] elementsList;

        //public MyListEventHandler OnListChange = new MyListEventHandler(MyListEventHandler.OnAddHandler, MyListEventHandler.OnRemoveHandler);
        public MyListEventHandler OnListChange = new MyListEventHandler(MyHandlersImplementations.OnAddHandler, MyHandlersImplementations.OnRemoveHandler);

        public MyIntListClass():this(2)
        { }

        public MyIntListClass(int initialCapacity)
        {
            InitialCapacity = initialCapacity;
            elementsList = new int [InitialCapacity];
        }

        protected int [] AllocateNewList(int capacity)
        {
            return new int [capacity];
        }


        protected int [] PutCurrentListIntoNew(int[] newArray)
        {
            int length = (newArray.Length > elementsList.Length) ? elementsList.Length : newArray.Length;
            for (int i = 0; i < length; i++) newArray[i] = elementsList[i];
            return newArray;
        }


        protected int [] GetListToAddTo()
        {
            if(elementsList.Length == LastFilledElementIndex+1)
            {
                Console.WriteLine($"\n\n\tExpanding list cpacity to {elementsList.Length + InitialCapacity}\n");
                int[] result = AllocateNewList(elementsList.Length + InitialCapacity);
                elementsList = PutCurrentListIntoNew(result);
            }

            return elementsList;
        }

        public bool Add(int value)
        {

            //Console.WriteLine($"\n\tAdding element with value {value}");
            OnListChange.InvokeOnAddEventHandler($"\n\tAdding element with value {value}");

            GetListToAddTo()[++LastFilledElementIndex] = value;

            Console.WriteLine($"\n\tNow LastFilledElementIndex={LastFilledElementIndex}");
            return true;
        }

        public bool Remove(int elementIndex)
        {

            //Console.WriteLine($"\n\tRemoving element on index {elementIndex}");
            OnListChange.InvokeOnRemoveEventHandler($"\n\tRemoving element on index {elementIndex}");

            if (elementIndex < 0 || elementIndex > elementsList.Length
                || elementIndex > LastFilledElementIndex)
            {
                Console.WriteLine($"\n\tERROR: Provided index {elementIndex} has invalid valkue:\n\t\tis <0,\n\t\tis > list capacityy,\n\t\tor is > index of LastElementWithValue");
            }
            if(LastFilledElementIndex<0)
            {
                Console.WriteLine("\n\tNo element present in list!!");
            }

            int [] result = new int [elementsList.Length-1];
            int indexToCopy = 0;
            for (int i=0;i<result.Length;i++)
            {
                if (i == elementIndex) indexToCopy++;
                result[i] = elementsList[indexToCopy++];
            }

            elementsList = result;

            return true;
        }
        
        public bool Contains(int value)
        {
            foreach(int ele in elementsList)
            {
                if (ele == value) return true;
            }
            return false;
        }

        public int Get(int index)
        {
            if(index<0 || index>LastFilledElementIndex)
            {
                Console.WriteLine($"\n\tERROR: Provided index {index} < 0 or > index of LastElementWithValue!!");
                return -1;
            }
            return elementsList[index];
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(elementsList.Length*3);
            for(int i= 0; i < elementsList.Length; i++)
            {
                builder.Append(elementsList[i] + ",");
            }
            return builder.ToString();
        }
    }
}
