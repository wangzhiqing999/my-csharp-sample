using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using G0001_Sudoku.Model;



namespace G0001_Sudoku.Service
{


    /// <summary>
    /// 数据管理类创建.
    /// 
    /// 
    /// 本类用于创建 6x6 面积的数据类.
    /// </summary>
    public class ItemMasterCreater6x6 : AbstractItemMasterCreater
    {


        /// <summary>
        /// 初始化 宫分组数据.
        /// </summary>
        /// <param name="result"></param>
        protected override void InitBox(ItemMaster result)
        {
            // 由于是 6x6 的。
            // 每一个宫的大小为 3x2
            // (3x2) (3x2)
            // (3x2) (3x2)
            // (3x2) (3x2) 
            // 共六个宫.
            int boxWidth = 3;
            int boxHeight = 2;

            // 处理宫格.
            base.InitRectangleBox(result, boxWidth, boxHeight);

        }
    }



}
