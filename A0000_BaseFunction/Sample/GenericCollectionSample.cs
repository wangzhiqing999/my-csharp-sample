using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A001_BaseFunction.Sample
{

    /// <summary>
    /// 泛型演示集合操作的例子.
    /// </summary>
    class GenericCollectionSample
    {


        public GenericCollectionSample()
        {
            Console.WriteLine("***** GenericCollectionSample 泛型集合操作例子 *****");
        }




        
        /// <summary>
        /// List 的例子.
        /// </summary>
        public void ListSample()
        {
            Console.WriteLine("****List<T> : 使用大小可按需动态增加的数组");

            // 初始化.
            List<int> dataList = new List<int>();

            Console.WriteLine("***加入测试数据. 100/300/200/400 ");
            dataList.Add(100);
            dataList.Add(300);
            dataList.Add(200);
            dataList.Add(400);

            Console.WriteLine("***数据个数={0}", dataList.Count);

            Console.WriteLine("***测试 遍历数据:");
            foreach (int val in dataList)
            {
                Console.WriteLine(val);
            }

            Console.WriteLine("***测试 索引器:");
            for (int i = 0; i < dataList.Count; i++)
            {
                Console.WriteLine("索引为{0} 数据为{1}", i, dataList[i]);
            }

            Console.WriteLine("***测试 IndexOf :");
            int index = dataList.IndexOf(200);
            Console.WriteLine("200 所在的位置在:{0}", index);

            Console.WriteLine("***测试 IndexOf 从1开始找:");
            index = dataList.IndexOf(200, 1);
            Console.WriteLine("200 所在的位置在:{0}", index);

            Console.WriteLine("***测试 IndexOf 从3开始找:");
            index = dataList.IndexOf(200, 3);
            Console.WriteLine("200 所在的位置在:{0}", index);

            Console.WriteLine("***测试 IndexOf 从1和3之间找:");
            index = dataList.IndexOf(200, 1, 3);
            Console.WriteLine("200 所在的位置在:{0}", index);


            Console.WriteLine("***测试 未排序的 BinarySearch :");
            index = dataList.BinarySearch(200);
            Console.WriteLine("200 所在的位置在:{0}", index);

            Console.WriteLine("***测试 已排序的 BinarySearch :");
            dataList.Sort();
            index = dataList.BinarySearch(200);
            Console.WriteLine("200 所在的位置在:{0}", index);

            // 说明：
            // 如果找不到的话：
            // IndexOf  需要遍历整个 ArrayList
            // BinarySearch 则不需要。
            // 但是 BinarySearch 执行前，需要对 ArrayList 进行排序
            // 假如数据量不大，且检索的次数很少，可以直接用 IndexOf


            Console.WriteLine("***测试 对已排序的 进行反转 :");
            dataList.Reverse();
            foreach (int val in dataList)
            {
                Console.WriteLine(val);
            }


            // 方法结束.
            Console.WriteLine();

        }





        /// <summary>
        /// Dictionary 的例子.
        /// </summary>
        public void DictionarySample()
        {
            Console.WriteLine("****Dictionary <T1,T2>: 根据键的哈希代码进行组织[键/值]对的集合");

            // 初始化.
            Dictionary<string, int> table = new Dictionary<string, int>();

            Console.WriteLine("***加入测试数据. One=100/Three=300/Two=200/Four=400 ");
            table.Add("One", 100);
            table.Add("Three", 300);
            table.Add("Two", 200);
            table.Add("Four", 400);

            Console.WriteLine("***数据个数={0}", table.Count);
            Console.WriteLine("***测试 遍历数据:");
            foreach (KeyValuePair<string, int> de in table)
            {
                Console.WriteLine("{0} = {1}", de.Key, de.Value);
            }


            Console.WriteLine("***测试 取得 Keys");
            Dictionary<string, int>.KeyCollection keys = table.Keys;
            foreach (String key in keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("***测试 索引器:");
            foreach (String key in keys)
            {
                Console.WriteLine("{0} = {1}", key, table[key]);
            }

            // 方法结束.
            Console.WriteLine();
        }




        /// <summary>
        /// Queue 的例子.
        /// </summary>
        public void QueueSample()
        {
            Console.WriteLine("****Queue<T>: 先进先出 ");

            // 初始化.
            Queue<int> que = new Queue<int>();

            Console.WriteLine("***加入测试数据. 100/300/200/400 ");
            que.Enqueue(100);
            que.Enqueue(300);
            que.Enqueue(200);
            que.Enqueue(400);

            Console.WriteLine("***数据个数={0}", que.Count);

            // Peek() 返回位于 Queue 开始处的对象但不将其移除。
            Console.WriteLine("*** 队列 首个数据Peek()={0}", que.Peek());

            Console.WriteLine("***测试 遍历数据:");
            foreach (int val in que)
            {
                Console.WriteLine(val);
            }


            Console.WriteLine("***测试 遍历数据 出队列:");
            while (que.Count > 0)
            {
                Console.WriteLine(que.Dequeue());
            }

            // 方法结束.
            Console.WriteLine();
        }






        /// <summary>
        /// Stack 的例子.
        /// </summary>
        public void StackSample()
        {
            Console.WriteLine("****Stack <T>: 简单的后进先出");

            // 初始化.
            Stack<int> stack = new Stack<int>();

            Console.WriteLine("***加入测试数据. 100/300/200/400 ");
            stack.Push(100);
            stack.Push(300);
            stack.Push(200);
            stack.Push(400);

            Console.WriteLine("***数据个数={0}", stack.Count);

            // Peek() 返回位于 Stack 顶部的对象但不将其移除。
            Console.WriteLine("*** 堆栈 顶部的对象Peek()={0}", stack.Peek());

            Console.WriteLine("***测试 遍历数据:");
            foreach (int val in stack)
            {
                Console.WriteLine(val);
            }


            Console.WriteLine("***测试 遍历数据 POP:");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            // 方法结束.
            Console.WriteLine();
        }

 

    }
}
