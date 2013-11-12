using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0001_Sudoku.Model
{

    /// <summary>
    /// 抽象的项目单元格.
    /// 
    /// 
    /// 在数独计算中， 本类用于存储一个 单元格上的数值信息.
    /// </summary>
    public abstract class AbstractItem
    {

        /// <summary>
        /// 横坐标.
        /// </summary>
        public int X { set; get; }


        /// <summary>
        /// 纵坐标.
        /// </summary>
        public int Y { set; get; }




        /// <summary>
        /// 结果.
        /// </summary>
        /// <returns></returns>
        public abstract int ResultValue();


    }



}
