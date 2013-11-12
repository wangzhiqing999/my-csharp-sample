using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using G0001_Sudoku.Model;


namespace G0001_Sudoku.Service
{

    /// <summary>
    /// 抽象创建类.
    /// 
    /// 
    /// 这个类定义了基本的处理逻辑。
    /// 
    /// 用于根据一个数组， 创建一个 数据对象。
    /// 
    /// 基本的处理逻辑
    /// 
    /// 首先， 把基本的数据单元， 区分为 固定值 与 动态值。 分别加入相应的数据列表。
    /// 
    /// 然后，根据 数独的 类型， 创建相应的 数据组
    /// （行、列  是固定处理的）
    /// 宫需要外部设置参数进行处理。
    /// 对角线是属于  可选的处理。
    /// 
    /// 
    /// 所有的分组都加好以后，开始遍历每一个组，完成 每一个组内，可用数据列表初始化处理的操作.
    /// 
    /// </summary>
    public abstract class AbstractItemMasterCreater
    {

        /// <summary>
        /// 数组的大小.
        /// </summary>
        protected int sizeOfArray = 0;



        #region 基本处理方法.

        /// <summary>
        /// 初始化 项目单元数据.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="initArray"></param>
        protected void InitBaseItemData(ItemMaster result, int[,] initArray)
        {
            // 取得二维数组的 边长.
            sizeOfArray = Convert.ToInt32(Math.Sqrt(initArray.Length));

            // 遍历二维数组， 填写数据.
            for (int i = 0; i < sizeOfArray; i++)
            {
                for (int j = 0; j < sizeOfArray; j++)
                {

                    if (initArray[i, j] == 0)
                    {
                        // 等于零的情况.
                        DynamicsItem item = new DynamicsItem()
                        {
                            X = i,
                            Y = j,
                        };

                        // 初始化.
                        item.InitDefaultList(9);

                        // 加入 结果列表.
                        result.DynamicsItemList.Add(item);
                    }
                    else
                    {
                        // 非零的情况.
                        FixedItem item = new FixedItem()
                        {
                            X = i,
                            Y = j,
                            IintValue = initArray[i, j],
                        };

                        // 加入 固定结果列表.
                        result.FixItemList.Add(item);
                    }

                }
            }
        }




        /// <summary>
        /// 初始化 行分组数据.
        /// </summary>
        /// <param name="result"></param>
        protected void InitRow(ItemMaster result)
        {
            for (int i = 0; i < sizeOfArray; i++)
            {
                ItemGroup itemGroup = new ItemGroup()
                {
                    // 名称.
                    GroupName = String.Format("第{0}行", i),
                    // 固定数据列表.
                    FixItemList = result.FixItemList.Where(p => p.Y == i).ToList(),
                    // 动态数据列表.
                    DynamicsItemList = result.DynamicsItemList.Where(p => p.Y == i).ToList(),
                };
                // 加入数据组.
                result.ItemGroupList.Add(itemGroup);
            }
        }



        /// <summary>
        /// 初始化 列分组数据.
        /// </summary>
        /// <param name="result"></param>
        protected void InitCol(ItemMaster result)
        {
            for (int i = 0; i < sizeOfArray; i++)
            {
                ItemGroup itemGroup = new ItemGroup()
                {
                    // 名称.
                    GroupName = String.Format("第{0}列", i),
                    // 固定数据列表.
                    FixItemList = result.FixItemList.Where(p => p.X == i).ToList(),
                    // 动态数据列表.
                    DynamicsItemList = result.DynamicsItemList.Where(p => p.X == i).ToList(),
                };
                // 加入数据组.
                result.ItemGroupList.Add(itemGroup);
            }
        }


        #endregion 基本处理方法.




        #region 子类实现 或者调用的方法.


        /// <summary>
        /// 初始化 宫分组数据.
        /// </summary>
        /// <param name="result"></param>
        protected abstract void InitBox(ItemMaster result);



        /// <summary>
        /// 初始化 其它分组数据.
        /// </summary>
        /// <param name="result"></param>
        protected virtual void InitOther(ItemMaster result)
        {
            // 默认情况下，不做处理.
            // 该方法由子类 覆盖处理.
        }





        /// <summary>
        /// 初始化 长方形的宫格.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="boxWidth"></param>
        /// <param name="boxHeight"></param>
        protected void InitRectangleBox(ItemMaster result, int boxWidth, int boxHeight)
        {
            // 处理宫格.
            for (int i = 0; i < this.sizeOfArray / boxWidth; i++)
            {
                for (int j = 0; j < this.sizeOfArray / boxHeight; j++)
                {
                    ItemGroup itemGroup = new ItemGroup()
                    {
                        // 名称.
                        GroupName = String.Format("第{0}/{1}宫", i, j),
                        // 固定数据列表.
                        FixItemList = result.FixItemList.Where(
                            p => p.X >= i * boxWidth && p.X < (i + 1) * boxWidth
                                && p.Y >= j * boxHeight && p.Y < (j + 1) * boxHeight).ToList(),
                        // 动态数据列表.
                        DynamicsItemList = result.DynamicsItemList.Where(
                            p => p.X >= i * boxWidth && p.X < (i + 1) * boxWidth
                                && p.Y >= j * boxHeight && p.Y < (j + 1) * boxHeight).ToList(),
                    };

                    // 加入数据组.
                    result.ItemGroupList.Add(itemGroup);
                }
            }
        }


        /// <summary>
        /// 初始化 正方形的宫格.
        /// </summary>
        /// <param name="result"></param>
        protected void InitSquareBox(ItemMaster result)
        {
            // 每个宫的 长宽.
            int boxSize = sizeOfArray / 3;

            // 处理宫格.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ItemGroup itemGroup = new ItemGroup()
                    {
                        // 名称.
                        GroupName = String.Format("第{0}/{1}宫", i, j),
                        // 固定数据列表.
                        FixItemList = result.FixItemList.Where(
                            p => p.X >= i * boxSize && p.X < (i + 1) * boxSize
                                && p.Y >= j * boxSize && p.Y < (j + 1) * boxSize).ToList(),
                        // 动态数据列表.
                        DynamicsItemList = result.DynamicsItemList.Where(
                            p => p.X >= i * boxSize && p.X < (i + 1) * boxSize
                                && p.Y >= j * boxSize && p.Y < (j + 1) * boxSize).ToList(),
                    };

                    // 加入数据组.
                    result.ItemGroupList.Add(itemGroup);
                }
            }
        }


        /// <summary>
        /// 初始化 对角线分组.
        /// </summary>
        /// <param name="result"></param>
        protected void InitDiagonal(ItemMaster result)
        {            
            ItemGroup itemGroup = new ItemGroup()
            {
                // 名称.
                GroupName = String.Format("对角线(x=y)"),
                // 固定数据列表.
                FixItemList = result.FixItemList.Where(p => p.X == p.Y).ToList(),
                // 动态数据列表.
                DynamicsItemList = result.DynamicsItemList.Where(p => p.X == p.Y).ToList(),
            };
            // 加入数据组.
            result.ItemGroupList.Add(itemGroup);


            ItemGroup itemGroup2 = new ItemGroup()
            {
                // 名称.
                GroupName = String.Format("对角线(x=Size-y)"),
                // 固定数据列表.
                FixItemList = result.FixItemList.Where(p => p.X == sizeOfArray - p.Y).ToList(),
                // 动态数据列表.
                DynamicsItemList = result.DynamicsItemList.Where(p => p.X == sizeOfArray - p.Y).ToList(),
            };
            // 加入数据组.
            result.ItemGroupList.Add(itemGroup2);
        }


        #endregion








        #region 提供给外部调用的方法.

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="initArray"></param>
        /// <returns></returns>
        public ItemMaster CreateItemMaster(int[,] initArray)
        {
            // 预期结果.
            ItemMaster result = new ItemMaster();

            // 初始化 项目单元数据.
            InitBaseItemData(result, initArray);

            // 初始化 行分组数据.
            InitRow(result);

            // 初始化 列分组数据.
            InitCol(result);

            // 初始化 宫分组数据.
            InitBox(result);

            // 初始化 其它分组数据.
            InitOther(result);



            // 初始化每一个组.
            foreach (ItemGroup itemGroup in result.ItemGroupList)
            {
                itemGroup.InitDefaultUsableValueList();
            }


            // 返回.
            return result;
        }


        #endregion





    }


}
