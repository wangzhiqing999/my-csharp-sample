using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0711_Merge.Sample;


namespace A0711_Merge
{
    class Program
    {
        static void Main(string[] args)
        {
            // 测试合并.
            TestMerge();
            Console.ReadLine();
        }


        /// <summary>
        /// 测试合并2
        /// </summary>
        static void TestMerge()
        {
            // 旧列表 [数据库后台数据，有ID信息 与 有效性标志信息。] .
            TestData[] oldList = new TestData[3] {
                new TestData() { Id = 1, Code="001", Val = "A", Availability=true },
                new TestData() { Id = 2, Code="002", Val = "B", Availability=true },
                new TestData() { Id = 3, Code="003", Val = "C", Availability=true }
            };
            // 新列表 [客户端导入数据，只有 Code与Val， 没有 ID与Availability 信息].
            TestData[] newList = new TestData[3] {
                new TestData() {  Code = "001", Val = "A123" },
                new TestData() {  Code = "002", Val = "B" },
                new TestData() {  Code = "004", Val = "D" }
            };
            // 数据合并类.
            Merge<TestData> merge = new Merge<TestData>();
            // 数据合并.
            List<Merge<TestData>.MergeResult> mergeResultList = merge.DoMerge(oldList, newList);
            // 输出 MERGE 结果.
            foreach (Merge<TestData>.MergeResult result in mergeResultList)
            {
                Console.WriteLine(result);
            }
        }


    }
}
