using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;

namespace B1200_Redis.Sample
{

    /// <summary>
    /// 测试 Set 的存储与获取.
    /// </summary>
    public class SetTest : BasicTest
    {


        public void TestAddItemToSet()
        {
            using (RedisClient client = GetRedisClient())
            {

                client.AddItemToSet("SetTest", "001");
                client.AddItemToSet("SetTest", "002");
                client.AddItemToSet("SetTest", "003");
                client.AddItemToSet("SetTest", "004");
                client.AddItemToSet("SetTest", "005");


                // 尝试追加重复的数据.
                client.AddItemToSet("SetTest", "002");
                client.AddItemToSet("SetTest", "004");



                foreach (var item in client.GetAllItemsFromSet("SetTest"))
                {
                    Console.WriteLine($"Get From Set:  {item}");
                }

            }
        }





    }

}
