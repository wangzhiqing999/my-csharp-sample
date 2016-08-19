using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AutoLazy;


namespace B1000_Fody_AutoLazy
{

    public class MockStaticGuid
    {

        /// <summary>
        /// GetGuid 方法， 被调用的次数.
        /// </summary>
        public static int GetCount;


        /// <summary>
        /// GetGuid 方法。
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        [Lazy]
        public static Guid GetGuid()
        {

            // 这里是用于测试的代码。
            // 实际的代码， 一般是 加载外部 文件/数据库， 获取数据后， 返回。

            ++GetCount;
            return Guid.NewGuid();
        }






        /// <summary>
        /// GuidProp 属性， 被获取的次数.
        /// </summary>
        public static int PropCount;


        /// <summary>
        /// GuidProp 属性
        /// </summary>
        [Lazy]
        public static Guid GuidProp
        {
            get
            {
                // 这里是用于测试的代码。
                // 实际的代码， 一般是 加载外部 文件/数据库， 获取数据后， 返回。

                
                ++PropCount;
                return Guid.NewGuid();
            }
        }





        /// <summary>
        /// GetKeyedCount 方法， 被调用的次数.
        /// </summary>
        public static int GetKeyedCount;
        


        /// <summary>
        /// GetKeyedCount 方法
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Lazy]
        public static Guid GetGuidByKey(Guid key)
        {

            // 这里是用于测试的代码。
            // 实际的代码， 一般是 加载外部 文件/数据库， 获取数据后， 返回。

            ++GetKeyedCount;
            return key;
        }


    }

}
