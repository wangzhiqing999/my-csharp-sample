using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0206_Flyweight.Simple
{

    /// <summary>
    /// 享元工厂(FlyweightFactory)角色
    /// </summary>
    public class FlyweightFactory
    {

        /// <summary>
        /// 缓存享元数据的 Dictionary.
        /// </summary>
        private Dictionary<Char, IFlyweight> cacheDictionary = new Dictionary<Char, IFlyweight>();



        /// <summary>
        /// 工厂方法.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public IFlyweight Factory(Char state)
        {
            // 当一个客户端对象调用一个享元对象的时候，
            // 享元工厂角色会检查系统中是否已经有一个复合要求的享元对象。
            if (cacheDictionary.ContainsKey(state))
            {
                // 如果已经有了，享元工厂角色就应当提供这个已有的享元对象
                return cacheDictionary[state];
            }
            else
            {
                // 如果系统中没有一个适当的享元对象的话，享元工厂角色就应当创建一个合适的享元对象。
                IFlyweight fly = new ConcerteFlyweight(state);
                cacheDictionary.Add(state, fly);
                return fly;
            }
        }
    }
}
