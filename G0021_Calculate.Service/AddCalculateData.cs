using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0021_Calculate.Service
{

    /// <summary>
    /// 加  操作的处理.
    /// </summary>
    public class AddCalculateData : AbstractCalculateData
    {

        /// <summary>
        /// 返回处理符号.
        /// </summary>
        /// <returns></returns>
        protected override string GetOperation()
        {
            return "+";
        }


        /// <summary>
        /// 计算处理.
        /// </summary>
        /// <returns></returns>
        protected override int DoCompute()
        {
            return ParamValue1 + ParamValue2;
        }
    }
}
