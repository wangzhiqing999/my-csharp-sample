using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyWCFService.DataContract;
using MyWCFService.ServiceContract;


namespace MyWCFService.Service
{

    /// <summary>
    /// WCF 接口实现类.
    /// </summary>
    public class CalculatorService : ICalculator
    {
        /// <summary>
        /// 加
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Add(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// 减
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Sub(int x, int y)
        {
            return x - y;
        }


        /// <summary>
        /// 乘
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Mul(int x, int y)
        {
            return x * y;
        }

        /// <summary>
        /// 除
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public DivResult Div(int x, int y)
        {
            DivResult result = new DivResult()
            {
                  DivData = x / y,
                  ModData = x % y
            };

            return result;
        }
    }
}
