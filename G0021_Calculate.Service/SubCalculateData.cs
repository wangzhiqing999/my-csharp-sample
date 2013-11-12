using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0021_Calculate.Service
{

    public class SubCalculateData : AbstractCalculateData 
    {
        /// <summary>
        /// 返回处理符号.
        /// </summary>
        /// <returns></returns>
        protected override string GetOperation()
        {
            return "-";
        }


        /// <summary>
        /// 计算处理.
        /// </summary>
        /// <returns></returns>
        protected override int DoCompute()
        {
            return ParamValue1 - ParamValue2;
        }
    }

}
