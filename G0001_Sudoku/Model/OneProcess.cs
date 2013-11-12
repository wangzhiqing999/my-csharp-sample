using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0001_Sudoku.Model
{

    /// <summary>
    /// 一次处理.
    /// 
    /// 在数独计算中, 本类用于存储 一个操作记录。
    /// 
    /// 也就是 在坐标 (x,y) 上面， 设置数据 Value.
    /// 
    /// </summary>
    public class OneProcess
    {

        /// <summary>
        /// X
        /// </summary>
        public int x { set; get; }


        /// <summary>
        /// Y
        /// </summary>
        public int y { set; get; }


        /// <summary>
        /// 设置的数值.
        /// </summary>
        public int Value { set; get; }



        public override string ToString()
        {
            return String.Format("({0}, {1})={2}", x, y, Value);
        }


    }


}
