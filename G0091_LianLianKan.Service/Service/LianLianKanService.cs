using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0091_LianLianKan.Service
{


    public class LianLianKanService
    {



        /// <summary>
        /// 内部二维数组.
        /// </summary>
        private int[,] dataArray;


        /// <summary>
        /// 行.
        /// </summary>
        public int Row
        {
            private set;
            get;
        }

        /// <summary>
        /// 列.
        /// </summary>
        public int Col
        {
            private set;
            get;
        }

        /// <summary>
        /// 索引器.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public int this[int row, int col]
        {
            get
            {
                return dataArray[row, col];
            }
        }




        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="row">行数</param>
        /// <param name="col">列数</param>
        /// <param name="itemCount">项目类型数</param>
        public void Init(int row, int col, int itemCount = 10)
        {
            if (row * col % 2 == 1)
            {
                throw new ArgumentException("需要一个 偶数的 表格.");
            }

            this.Row = row;
            this.Col = col;

            // 初始化内部二维数组.
            dataArray = new int[row, col];


            // 准备用于填充的数据（先只放一半）
            int[] oneArray = new int[row * col / 2];
            for (int i = 0; i < oneArray.Length; i++)
            {
                oneArray[i] = i % itemCount + 1;
            }

            // 两个一半连接起来.
            List<int> allDataList = oneArray.Concat(oneArray).ToList();


            // 随机排序.
            var query =
                from data in allDataList
                orderby Guid.NewGuid()
                select data;
            allDataList = query.ToList();


            // 向二维数组填充.
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    dataArray[i, j] = allDataList[i * col + j];
                }
            }

        }



        /// <summary>
        /// 移除单元.
        /// </summary>
        /// <param name="item"></param>
        private void RemoveItem(LianLianKanItem item)
        {
            dataArray[item.Row, item.Col] = 0;
        }


        #region 1条线就能连接的情况


        /// <summary>
        /// 指定行是否是空行.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col1"></param>
        /// <param name="col2"></param>
        /// <returns></returns>
        private bool IsEmptyRow(int row, int col1, int col2)
        {

            if (row == 0 || row == this.Row - 1)
            {
                // 顶部 与 底部， 认为是可连接的.
                return true;
            }

            // 其他情况， 需要逐列判断.
            for (int i = Math.Min(col1, col2); i <= Math.Max(col1, col2); i++)
            {
                if (this.dataArray[row, i] != 0)
                {
                    // 存在有不是空格的情况.
                    return false;
                }
            }

            // 上面的循环， 如果能执行完， 认为是 可以连接的.
            return true;

        }




        /// <summary>
        /// 指定列是否是空列.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row1"></param>
        /// <param name="row2"></param>
        /// <returns></returns>
        private bool IsEmptyCol(int col, int row1, int row2)
        {

            if (col == 0 || col == this.Col - 1)
            {
                // 最左部 与 最右部， 认为是可连接的.
                return true;
            }

            // 其他情况， 需要逐行判断.
            for (int i = Math.Min(row1, row2); i <= Math.Max(row1, row2); i++)
            {
                if (this.dataArray[i, col] != 0)
                {
                    // 存在有不是空格的情况.
                    return false;
                }
            }

            // 上面的循环， 如果能执行完， 认为是 可以连接的.
            return true;

        }





        #endregion 1条线就能连接的情况






        #region 2条线就能连接的情况

        /// <summary>
        /// 是否存在空白交叉. (2条线能连接的情况)
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <returns></returns>
        private bool IsExistCrossRowCol(LianLianKanItem item1, LianLianKanItem item2)
        {
            if (item1.Row > item2.Row)
            {
                // item1 在 item2 下面.
                // 从下向上判断.
                for (int moveIndex = item1.Row - 1; moveIndex >= item2.Row; moveIndex--)
                {
                    if (dataArray[moveIndex, item1.Col] != 0)
                    {
                        // 存在阻挡.
                        return false;
                    }
                }
            }
            else
            {
                // item1 在 item2 上面.
                // 从上向下判断.
                for (int moveIndex = item1.Row + 1; moveIndex <= item2.Row; moveIndex++)
                {
                    if (dataArray[moveIndex, item1.Col] != 0)
                    {
                        // 存在阻挡.
                        return false;
                    }
                }
            }

            // 如果能执行到这里， 说明 Row 上面没有阻拦.
            if (item1.Col > item2.Col)
            {
                // item1 在 item2 右面.
                // 从左向右判断.
                for (int moveIndex = item2.Col + 1; moveIndex <= item1.Col; moveIndex++)
                {
                    if (dataArray[item2.Row, moveIndex] != 0)
                    {
                        // 存在阻挡.
                        return false;
                    }
                }
            }
            else
            {
                // item1 在 item2 左面.
                // 从右向左判断.
                for (int moveIndex = item2.Col - 1; moveIndex >= item1.Col; moveIndex--)
                {
                    if (dataArray[item2.Row, moveIndex] != 0)
                    {
                        // 存在阻挡.
                        return false;
                    }
                }
            }


            // 如果能执行到这里， 说明存在有路径
            return true;
        }


        #endregion 2条线就能连接的情况






        #region 3条线就能连接的情况


        /// <summary>
        /// 向上最大能移动到多少行.
        /// </summary>
        /// <param name="item1"></param>
        /// <returns></returns>
        private int GetMinMoveAbleRow(LianLianKanItem item1)
        {
            if (item1.Row == 0)
            {
                // 顶部， 不用移动.
                return 0;
            }
            int minRow1 = 0;
            for (minRow1 = item1.Row - 1; minRow1 >= 0; minRow1--)
            {
                if (dataArray[minRow1, item1.Col] != 0)
                {
                    // 存在阻挡.
                    minRow1++;
                    break;
                }
            }
            
            return Math.Max(0, minRow1);
        }


        /// <summary>
        /// 向下最多能移动到多少行.
        /// </summary>
        /// <param name="item1"></param>
        /// <returns></returns>
        private int GetMaxMoveAbleRow(LianLianKanItem item1)
        {
            if (item1.Row == this.Row - 1)
            {
                // 低部， 不用移动.
                return item1.Row;
            }

            int maxRow1 = 0;
            for (maxRow1 = item1.Row + 1; maxRow1 < this.Row; maxRow1++)
            {
                if (dataArray[maxRow1, item1.Col] != 0)
                {
                    // 存在阻挡.
                    maxRow1--;
                    break;
                }
            }
            return Math.Min(this.Row - 1, maxRow1);
        }



        /// <summary>
        /// 是否存在 3条线能连接的 行.
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <returns></returns>
        private bool IsExistThreeLineCrossRow(LianLianKanItem item1, LianLianKanItem item2)
        {
            // 最小/最大的 行数.
            int minRow1 = GetMinMoveAbleRow(item1);
            int minRow2 = GetMinMoveAbleRow(item2);

            int maxRow1 = GetMaxMoveAbleRow(item1);
            int maxRow2 = GetMaxMoveAbleRow(item2);


            for (int i = Math.Max(minRow1, minRow2); i <= Math.Min(maxRow1, maxRow2); i++)
            {
                if (IsEmptyRow(i, item1.Col, item2.Col))
                {
                    // 存在空行.
                    return true;
                }
            }

            // 不存在能连接的行.
            return false;
        }






        /// <summary>
        /// 向左最大能移动到多少列.
        /// </summary>
        /// <param name="item1"></param>
        /// <returns></returns>
        private int GetMinMoveAbleCol(LianLianKanItem item1)
        {
            if (item1.Col == 0)
            {
                // 左部， 不用移动.
                return 0;
            }
            int minCol1 = 0;
            for (minCol1 = item1.Col - 1; minCol1 >= 0; minCol1--)
            {
                if (dataArray[item1.Row, minCol1] != 0)
                {
                    // 存在阻挡.
                    minCol1++;
                    break;
                }
            }


            return Math.Max(0, minCol1);
        }


        /// <summary>
        /// 向右最多能移动到多少行.
        /// </summary>
        /// <param name="item1"></param>
        /// <returns></returns>
        private int GetMaxMoveAbleCol(LianLianKanItem item1)
        {
            if (item1.Col == this.Col - 1)
            {
                // 右部， 不用移动.
                return item1.Col;
            }

            int maxCol1 = 0;
            for (maxCol1 = item1.Col + 1; maxCol1 < this.Col; maxCol1++)
            {
                if (dataArray[item1.Row, maxCol1] != 0)
                {
                    // 存在阻挡.
                    maxCol1--;
                    break;
                }
            }


            return  Math.Min(this.Col - 1,  maxCol1);
        }





        /// <summary>
        /// 是否存在 3条线能连接的 列.
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <returns></returns>
        private bool IsExistThreeLineCrossCol(LianLianKanItem item1, LianLianKanItem item2)
        {
            // 最小/最大的 列数.
            int minCol1 = GetMinMoveAbleCol(item1);
            int minCol2 = GetMinMoveAbleCol(item2);

            int maxCol1 = GetMaxMoveAbleCol(item1);
            int maxCol2 = GetMaxMoveAbleCol(item2);


            for (int i = Math.Max(minCol1, minCol2); i <= Math.Min(maxCol1, maxCol2); i++)
            {
                if (IsEmptyCol(i, item1.Row, item2.Row))
                {
                    // 存在空行.
                    return true;
                }
            }

            // 不存在能连接的行.
            return false;
        }





        #endregion 3条线就能连接的情况






        /// <summary>
        /// 尝试连接.
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <returns></returns>
        public bool TryLianLian(LianLianKanItem item1, LianLianKanItem item2)
        {

            // 数据内容不相等的情况下， 直接忽略.
            if (dataArray[item1.Row, item1.Col] != dataArray[item2.Row, item2.Col])
            {
                return false;
            }


            // Step1.
            // 判断直接贴着的情况.
            if (item1.IsSideBySide(item2))
            {
                RemoveItem(item1);
                RemoveItem(item2);
                return true;
            }


            // Step2. ( 这里相当于 判断， 1条线就能连接的情况)
            // 判断 同行/同列的情况.
            if (item1.IsInOneRow(item2))
            {
                // 同一行.
                if (IsEmptyRow(item1.Row, item1.Col, item2.Col))
                {
                    RemoveItem(item1);
                    RemoveItem(item2);
                    return true;
                }
            }

            if (item1.IsInOneCol(item2))
            {
                // 同一列.
                if (IsEmptyCol(item1.Col, item1.Row, item2.Row))
                {
                    RemoveItem(item1);
                    RemoveItem(item2);
                    return true;
                }
            }


            // Step3. (这里相当于判断，  2条线能连接的情况)

            if (IsExistCrossRowCol(item1, item2)
                || IsExistCrossRowCol(item2, item1))
            {
                RemoveItem(item1);
                RemoveItem(item2);
                return true;
            }




            // Step4.(这里相当于判断，  3条线能连接的情况)
            if (IsExistThreeLineCrossRow(item1, item2)
                || IsExistThreeLineCrossCol(item1, item2))
            {
                RemoveItem(item1);
                RemoveItem(item2);
                return true;
            }





            // 其他情况， 认为不能操作.
            return false;
        }




        /// <summary>
        /// 调试用.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();

            for (int i = 0; i <= dataArray.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= dataArray.GetUpperBound(1); j++)
                {
                    buff.AppendFormat("{0:00}  ", dataArray[i, j]);
                }
                buff.AppendLine();
            }

            return buff.ToString();
        }





    }
}
