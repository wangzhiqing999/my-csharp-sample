using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0001_Sudoku.Model
{
    
    /// <summary>
    /// 固定数据的项目单元格.
    /// 
    /// 在数独计算中， 本类用于存储一个 单元格上的 初始化的， 有数字的数值信息.
    /// </summary>
    public class FixedItem : AbstractItem
    {
        /// <summary>
        /// 单元数据.
        /// </summary>
        public int IintValue { set; get; }



        /// <summary>
        /// 固定数据， 结果就是初始值.
        /// </summary>
        /// <returns></returns>
        public override int ResultValue()
        {
            return IintValue;
        }

    }


}
