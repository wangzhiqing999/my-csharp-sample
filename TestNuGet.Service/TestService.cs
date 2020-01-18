using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNuGet.DataAccess;

namespace TestNuGet.Service
{

    /// <summary>
    /// 用于测试 NuGet 打包的项目.
    /// 注意：项目打包时，需要在 生成 XML 那里打勾.
    /// 否则， NuGet 引用后，将没有备注说明.
    /// </summary>
    public class TestService
    {

        /// <summary>
        /// NuGet 引用的服务.
        /// </summary>
        private TestDataAccess _TestDataAccess = new TestDataAccess();


        /// <summary>
        /// 获取最大值.
        /// </summary>
        /// <returns></returns>
        public int GetMax()
        {
            int result = Int32.MinValue;
            int a = _TestDataAccess.GetA();
            int b = _TestDataAccess.GetB();
            int c = _TestDataAccess.GetC();

            if (a > result)
            {
                result = a;
            }
            if (b > result)
            {
                result = b;
            }
            if (c > result)
            {
                result = c;
            }
            return result;
        }

        /// <summary>
        /// 获取最小值.
        /// </summary>
        /// <returns></returns>
        public int GetMin()
        {
            int result = Int32.MaxValue;
            int a = _TestDataAccess.GetA();
            int b = _TestDataAccess.GetB();
            int c = _TestDataAccess.GetC();
            
            if(a < result)
            {
                result = a;
            }
            if (b < result)
            {
                result = b;
            }
            if (c < result)
            {
                result = c;
            }
            return result;
        }


        /// <summary>
        /// 获取合计值.
        /// </summary>
        /// <returns></returns>
        public int GetSum()
        {
            int a = _TestDataAccess.GetA();
            int b = _TestDataAccess.GetB();
            int c = _TestDataAccess.GetC();
            return a + b + c;
        }


        /// <summary>
        /// 获取平均值.
        /// </summary>
        /// <returns></returns>
        public int GetAvg()
        {
            int a = _TestDataAccess.GetA();
            int b = _TestDataAccess.GetB();
            int c = _TestDataAccess.GetC();
            return (a + b + c) / 3;
        }

    }
}
