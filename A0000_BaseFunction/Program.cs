using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A001_BaseFunction.Sample;

namespace A001_BaseFunction
{
    class Program
    {

        static void Main(string[] args)
        {
            // 用于演示集合操作的例子.
            CollectionSample collectionSample = new CollectionSample();

            // ArrayList
            collectionSample.ArrayListSample();

            // Hashtable
            collectionSample.HashtableSample();

            // Queue
            collectionSample.QueueSample();

            // SortedList
            collectionSample.SortedListSample();

            // Stack
            collectionSample.StackSample();

      





            GenericCollectionSample genericCollectionSample = new GenericCollectionSample();

            // List<T>
            genericCollectionSample.ListSample();

            // Dictionary <T1,T2>
            genericCollectionSample.DictionarySample();

            // Queue<T>
            genericCollectionSample.QueueSample();

            // Stack<T>
            genericCollectionSample.StackSample();

            Console.ReadLine();

        }

    }
}
