using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNuGet.DataAccess
{


    /// <summary>
    /// 用于测试 NuGet 打包的项目.
    /// 注意：项目打包时，需要在 生成 XML 那里打勾.
    /// 否则， NuGet 引用后，将没有备注说明.
    /// </summary>
    public class TestDataAccess
    {

        /// <summary>
        /// 测试获取数据 A.
        /// 这里是测试代码，就简单返回数据。
        /// 实际业务，应该是从数据库获取数据。
        /// </summary>
        /// <returns></returns>
        public int GetA()
        {
            return 1;
        }


        /// <summary>
        /// 测试获取数据 B.
        /// 这里是测试代码，就简单返回数据。
        /// 实际业务，应该是从数据库获取数据。
        /// </summary>
        /// <returns></returns>
        public int GetB()
        {
            return 2;
        }



        /// <summary>
        /// 测试获取数据 C.
        /// 这里是测试代码，就简单返回数据。
        /// 实际业务，应该是从数据库获取数据。
        /// </summary>
        /// <returns></returns>
        public int GetC()
        {
            return 3;
        }

    }
}
