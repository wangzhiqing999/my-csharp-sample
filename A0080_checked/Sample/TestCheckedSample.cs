using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0080_checked.Sample
{
    class TestCheckedSample
    {

        /// <summary>
        /// 测试  使用 checked 关键字
        /// 检查数据溢出 的情况.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public short CheckAdd(short val1, short val2)
        {
            short result = 0;
            try
            {
                result = checked((short)(val1 + val2));
            }
            catch (OverflowException)
            {
                Console.WriteLine("数据溢出！");
            }
            return result;
        }


        /// <summary>
        /// 测试  不使用 checked 关键字
        /// 检查数据溢出 的情况.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public short UnCheckAdd(short val1, short val2)
        {
            short result = 0;
            result = (short)(val1 + val2);
            return result;
        }

    }
}
