using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMyListWithArray
{
    public class MyGenericListClass<T> : IEnumerable<T>
    {
        protected int InitialCapacity;
        protected int LastFilledElementIndex = -1;
        protected T[] elementsList;

        public MyListEventHandler<T> OnListChange = new MyListEventHandler<T>(GenericMyHandlersImplementations<T>.OnAddHandler, GenericMyHandlersImplementations<T>.OnRemoveHandler);

        public MyGenericListClass():this(2)
        { }

        public MyGenericListClass(int initialCapacity)
        {
            InitialCapacity = initialCapacity;
            elementsList = new T[InitialCapacity];
        }

        protected T [] AllocateNewList(int capacity)
        {
            return new T[capacity];
        }


        protected T [] PutCurrentListToNew(T[] newArray)
        {
            int length = (newArray.Length > elementsList.Length) ? elementsList.Length : newArray.Length;
            for (int i = 0; i < length; i++) newArray[i] = elementsList[i];
            return newArray;
        }


        protected T[] GetListToAddTo()
        {
            if(elementsList.Length == LastFilledElementIndex+1)
            {
                Console.WriteLine($"\n\n\tExpanding list cpacity to {elementsList.Length + InitialCapacity}\n");
                T[] result = AllocateNewList(elementsList.Length + InitialCapacity);
                elementsList = PutCurrentListToNew(result);
            }

            return elementsList;
        }

        public bool Add(T value)
        {

            //Console.WriteLine($"\n\tAdding element with value {value}");
            OnListChange.InvokeOnAddEventHandler(value);

            GetListToAddTo()[++LastFilledElementIndex] = value;

            Console.WriteLine($"\n\tNow LastFilledElementIndex={LastFilledElementIndex}");
            return true;
        }

        public bool Remove(int removedElementIndex)
        {

            Console.WriteLine($"\n\tRemoving element on index {removedElementIndex}");

            if (removedElementIndex < 0 || removedElementIndex > elementsList.Length
                || removedElementIndex > LastFilledElementIndex)
            {
                Console.WriteLine($"\n\tERROR: Provided index {removedElementIndex} has invalid valkue:\n\t\tis <0,\n\t\tis > list capacityy,\n\t\tor is > index of LastElementWithValue");
                return false;
            }
            if(LastFilledElementIndex<0)
            {
                Console.WriteLine("\n\tNo element present in list!!");
                return false;
            }

            T[] result = new T [elementsList.Length-1];
            int indexToCopy = 0;
            for (int i=0;i<result.Length;i++)
            {
                if (i == removedElementIndex)
                {
                    OnListChange.InvokeOnRemoveEventHandler(elementsList[indexToCopy]);
                    indexToCopy++;
                }
                result[i] = elementsList[indexToCopy++];
            }

            elementsList = result;
            LastFilledElementIndex--;
            return true;
        }
        
        public bool Contains(T value)
        {
            foreach(T ele in elementsList)
            {
                if (ele.Equals(value)) return true;
            }
            return false;
        }

        public T Get(int index)
        {
            if(index<0 || index>LastFilledElementIndex)
            {
                Console.WriteLine($"\n\tERROR: Provided index {index} < 0 or > index of LastElementWithValue!!");
                //return default(T);//would return default value for the concrete type T
                //Best practice is to throw below exception
                throw new ArgumentOutOfRangeException($"\n\tERROR: Provided index {index} < 0 or > index of LastElementWithValue!!");
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

        public IEnumerator<T> GetEnumerator()
        {
            for(int i=0; i<= LastFilledElementIndex; i++)
            {
                yield return elementsList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }//class
}
