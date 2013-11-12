using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace A001_BaseFunction.Sample
{
    
    /// <summary>
    /// 用于演示集合操作的例子.
    /// </summary>
    public class CollectionSample
    {


        public CollectionSample()
        {
            Console.WriteLine("***** CollectionSample 集合操作例子 *****");
        }


        /// <summary>
        /// ArrayList 的例子.
        /// </summary>
        public void ArrayListSample()
        {

            Console.WriteLine("****ArrayList : 使用大小可按需动态增加的数组");

            // 初始化.
            ArrayList dataList = new ArrayList();

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
        /// Hashtable 的例子.
        /// </summary>
        public void HashtableSample()
        {
            Console.WriteLine("****Hashtable : 根据键的哈希代码进行组织[键/值]对的集合");

            // 初始化.
            Hashtable table = new Hashtable();

            Console.WriteLine("***加入测试数据. One=100/Three=300/Two=200/Four=400 ");
            table.Add("One", 100);
            table.Add("Three", 300);
            table.Add("Two", 200);
            table.Add("Four", 400);

            Console.WriteLine("***数据个数={0}", table.Count);
            Console.WriteLine("***测试 遍历数据:");
            foreach (DictionaryEntry de in table)
            {
                Console.WriteLine("{0} = {1}", de.Key, de.Value);
            }

            Console.WriteLine("***测试 取得 Keys");
            ICollection keys = table.Keys;
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
            Console.WriteLine("****Queue : 先进先出 ");

            // 初始化.
            Queue que = new Queue();

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
        /// SortedList 的例子.
        /// </summary>
        public void SortedListSample()
        {
            Console.WriteLine("****SortedList : 按键排序并可按照键和索引访问[键/值]对的集合");

            // 初始化.
            SortedList sLst = new SortedList();

            Console.WriteLine("***加入测试数据. One=100/Three=300/Two=200/Four=400 ");
            sLst.Add("One", 100);
            sLst.Add("Three", 300);
            sLst.Add("Two", 200);
            sLst.Add("Four", 400);

            Console.WriteLine("***数据个数={0}", sLst.Count);
            Console.WriteLine("***测试 遍历数据:");
            foreach (DictionaryEntry de in sLst)
            {
                Console.WriteLine("{0} = {1}", de.Key, de.Value);
            }

            Console.WriteLine("***测试 取得 Keys");
            ICollection keys = sLst.Keys;
            foreach (String key in keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("***测试 索引器:");
            foreach (String key in keys)
            {
                Console.WriteLine("{0} = {1}", key, sLst[key]);
            }

            // 方法结束.
            Console.WriteLine();
        }


        /// <summary>
        /// Stack 的例子.
        /// </summary>
        public void StackSample()
        {
            Console.WriteLine("****Stack : 简单的后进先出");

            // 初始化.
            Stack stack = new Stack();

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
