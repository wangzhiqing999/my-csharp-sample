using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;

namespace B1200_Redis.Sample
{

    /// <summary>
    /// 测试 SortedSet 的存储与获取.
    /// </summary>
    public class SortedSetTest : BasicTest
    {


        
        public void TestAddItemToSortedSetWithoutScore()
        {
            using (RedisClient client = GetRedisClient())
            {
                // 不提供 score 参数.
                // 排序是按照 添加的顺序，完成的。

                client.AddItemToSortedSet("SortedSetTest", "001");
                client.AddItemToSortedSet("SortedSetTest", "002");
                client.AddItemToSortedSet("SortedSetTest", "003");
                client.AddItemToSortedSet("SortedSetTest", "004");
                client.AddItemToSortedSet("SortedSetTest", "005");


                // 尝试追加重复的数据.
                client.AddItemToSortedSet("SortedSetTest", "002");
                client.AddItemToSortedSet("SortedSetTest", "004");



                foreach (var item in client.GetAllItemsFromSortedSet("SortedSetTest"))
                {
                    Console.WriteLine($"Get From SortedSet:  {item}");
                }

            }
        }




        public void TestAddItemToSortedSetWithScore()
        {
            using (RedisClient client = GetRedisClient())
            {

                // 5条记录.
                client.AddItemToSortedSet("SortedSetTestS", "001", 100);
                client.AddItemToSortedSet("SortedSetTestS", "002", 100);
                client.AddItemToSortedSet("SortedSetTestS", "003", 100);
                client.AddItemToSortedSet("SortedSetTestS", "004", 100);
                client.AddItemToSortedSet("SortedSetTestS", "005", 100);


                // 模拟各种 投票的操作.
                client.IncrementItemInSortedSet("SortedSetTestS", "001", new Random().Next(1, 100));
                client.IncrementItemInSortedSet("SortedSetTestS", "002", new Random().Next(1, 100));
                client.IncrementItemInSortedSet("SortedSetTestS", "003", new Random().Next(1, 100));
                client.IncrementItemInSortedSet("SortedSetTestS", "004", new Random().Next(1, 100));
                client.IncrementItemInSortedSet("SortedSetTestS", "005", new Random().Next(1, 100));


                // 获取 分数最高的 3 条记录.
                foreach (var item in client.GetRangeWithScoresFromSortedSet("SortedSetTestS", 1, 3))
                {
                    Console.WriteLine($"Get Top3 From SortedSet: No={item.Key}; Score={item.Value}");
                }

            }
        }




    }
}
