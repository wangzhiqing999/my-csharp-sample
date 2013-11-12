using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0710_Merge.Sample;

namespace A0710_Merge
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
            // 旧列表.
            TestData[] oldList = new TestData[2] {
                new TestData() { Id = 1, Val = "A2" },
                new TestData() { Id = 3, Val = "C" }
            };
            // 新列表.
            TestData[] newList = new TestData[2] {
                new TestData() { Id = 1, Val = "A" },
                new TestData() { Id = 2, Val = "B" }
            };
            // 数据合并类.
            TestDataMerge merge = new TestDataMerge();
            // 数据合并.
            List<TestDataMerge.MergeResult> mergeResultList = merge.DoMerge(oldList, newList);
            // 输出 MERGE 结果.
            foreach (TestDataMerge.MergeResult result in mergeResultList)
            {
                Console.WriteLine(result);
            }
        }

        
    }
}
