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
    /// 本类用于创建 9x9 面积的数据类.
    /// </summary>
    public class ItemMasterCreater9x9 : AbstractItemMasterCreater
    {

        /// <summary>
        /// 初始化 宫分组数据.
        /// </summary>
        /// <param name="result"></param>
        protected override void InitBox(ItemMaster result)
        {
            // 因为是 9x9 的， 每一个宫大小为  3x3, 是正方形.
            // 因此按照正方形方式处理.
            base.InitSquareBox(result);
        }








        /*
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="initArray"></param>
        /// <returns></returns>
        public ItemMaster CreateItemMaster(int[,] initArray)
        {
            // 预期结果.
            ItemMaster result = new ItemMaster();


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
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




            // 单元格数据填写完毕以后.
            // 开始构造数据组.
            

            // 首先处理列.
            for (int i = 0; i < 9; i++)
            {
                ItemGroup itemGroup = new ItemGroup()
                {
                    // 名称.
                    GroupName = String.Format("第{0}列", i),
                    // 固定数据列表.
                    FixItemList = result.FixItemList.Where(p=>p.X == i).ToList(),
                    // 动态数据列表.
                    DynamicsItemList = result.DynamicsItemList.Where(p=>p.X == i).ToList(),
                };


                // 加入数据组.
                result.ItemGroupList.Add(itemGroup);
            }


            // 然后处理行.
            for (int i = 0; i < 9; i++)
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
                            p => p.X >= i*3 && p.X < (i+1)*3 
                                && p.Y >= j*3 && p.Y < (j+1)*3).ToList(),
                        // 动态数据列表.
                        DynamicsItemList = result.DynamicsItemList.Where(
                            p => p.X >= i*3 && p.X < (i+1)*3 
                                && p.Y >= j*3 && p.Y < (j+1)*3).ToList(),
                    };

                    // 加入数据组.
                    result.ItemGroupList.Add(itemGroup);
                }
            }



            // 初始化每一个组.
            foreach (ItemGroup itemGroup in result.ItemGroupList)
            {
                itemGroup.InitDefaultUsableValueList();
            }



            // 返回.
            return result;
        }
        */


    }


}
