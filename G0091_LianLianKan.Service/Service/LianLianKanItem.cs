using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0091_LianLianKan.Service
{


    /// <summary>
    /// 连连看的 单元格.
    /// </summary>
    public class LianLianKanItem
    {
        /// <summary>
        /// 行
        /// </summary>
        public int Row { set; get; }

        /// <summary>
        /// 列.
        /// </summary>
        public int Col { set; get; }



        /// <summary>
        /// 是否与另外一个相邻.
        /// </summary>
        /// <param name="otherItem"></param>
        /// <returns></returns>
        public bool IsSideBySide(LianLianKanItem otherItem)
        {
            if (this.Row == otherItem.Row)
            {
                // 同一行.
                if (Math.Abs(this.Col - otherItem.Col) == 1)
                {
                    // 列上相邻.
                    return true;
                }
            }


            if (this.Col == otherItem.Col)
            {
                // 同一列.
                if (Math.Abs(this.Row - otherItem.Row) == 1)
                {
                    // 行上相邻.
                    return true;
                }
            }

            // 其他情况，认为不相邻.
            return false;
        }


        /// <summary>
        /// 是否同一行.
        /// </summary>
        /// <param name="otherItem"></param>
        /// <returns></returns>
        public bool IsInOneRow(LianLianKanItem otherItem)
        {
            return this.Row == otherItem.Row;
        }

        /// <summary>
        /// 是否同一列.
        /// </summary>
        /// <param name="otherItem"></param>
        /// <returns></returns>
        public bool IsInOneCol(LianLianKanItem otherItem)
        {
            return this.Col == otherItem.Col;
        }

    }







}
