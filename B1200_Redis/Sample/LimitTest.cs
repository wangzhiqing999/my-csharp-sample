using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;

namespace B1200_Redis.Sample
{
    /// <summary>
    /// 用于测试 使用 Redis 来限制访问频率的操作.
    /// </summary>
    public class LimitTest : BasicTest
    {


        /// <summary>
        /// 起始时间.
        /// </summary>
        private readonly static DateTime StartDate = new DateTime(2020, 1, 1);



        /// <summary>
        /// 是否允许完成指定动作.
        /// </summary>
        /// <param name="userId">用户</param>
        /// <param name="actionKey">动作</param>
        /// <param name="period">时间范围（单位秒）</param>
        /// <param name="maxCount">时间范围内，最多允许执行多少次操作</param>
        /// <returns></returns>
        public bool IsActionAllowed(string userId, string actionKey, int period, int maxCount)
        {
            using (RedisClient client = GetRedisClient())
            {
                string key = $"hist:{userId}:{actionKey}";
                // 时间计算标志 = 现在 - 起始时间 直接的总毫秒数.
                long nowTs = Convert.ToInt64((DateTime.Now - StartDate).TotalMilliseconds);
                // 删除非时间段内的请求数据（清除老访问数据，比如 period=60 时，标识清除 60s 以前的请求记录）
                client.ZRemRangeByScore(key, 0, nowTs - period * 1000);

                // 当前请求次数.
                long currCount = client.ZCard(key);
                if (currCount >= maxCount)
                {
                    // 超过最大请求次数，执行限流
                    return false;
                }
                // 未达到最大请求数，正常执行业务,请求记录 +1
                client.ZAdd(key, nowTs, Encoding.ASCII.GetBytes(nowTs.ToString()));
                return true;
            }
        }




    }
}
