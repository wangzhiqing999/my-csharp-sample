using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0051_Jigsaw.Service
{

    /// <summary>
    /// 移动处理事件
    /// </summary>
    /// <param name="step">移动的单元格</param>
    /// <param name="direction">移动的方向</param>
    public delegate void MovingHandler(MoveStep step, MoveDirection direction);



    /// <summary>
    /// 拼图数据.
    /// </summary>
    public class Puzzle
    {
        /// <summary>
        /// 定义事件.
        /// </summary>
        public event MovingHandler Moving;


        /// <summary>
        /// 边框长度.
        /// </summary>
        public int PuzzleSize { protected set; get; }

        /// <summary>
        /// 拼图画面的元素个数.
        /// 
        /// 对于 3x3 面积的拼图来说， 元素个数 = 8
        /// 对于 4x4 面积的拼图来说， 元素个数 = 15
        /// </summary>
        public int PuzzleItemCount
        {
            get
            {
                return PuzzleSize * PuzzleSize - 1;
            }
        }


        /// <summary>
        /// 拼图的二维数组.
        /// </summary>
        protected int[,] PuzzleArray { set; get; }


        /// <summary>
        /// 返回拼图得 一维数组.
        /// </summary>
        protected int[] TempPuzzleArray
        {
            get
            {
                return this.PuzzleArray.Cast<int>().ToArray();
            }
        }




        /// <summary>
        /// 移动操作列表.
        /// </summary>
        public List<MoveStep> MoveStepList { protected set; get; }



        /// <summary>
        /// 构造函数.
        /// </summary>
        public Puzzle()
        {
            MoveStepList = new List<MoveStep>();
        }



        /// <summary>
        /// 对外的索引器. 允许外部查询当前拼图的数据.（只读属性）
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < PuzzleSize && j >= 0 && j < PuzzleSize)
                {
                    return PuzzleArray[i,j];
                }
                else
                {
                    return -1;
                }
            }
        }




        /// <summary>
        /// 初始化拼图.
        /// </summary>
        public void InitPuzzle()
        {
            // 初始化拼图的二维数组.
            PuzzleArray = new int[PuzzleSize, PuzzleSize];

            // 设置随机数值.
            SetRandomData();


            // 假如随机随得太好了，刚好是完成的状态，那么重新随机.
            while (IsFinish)
            {
                SetRandomData();
            }
        }





        /// <summary>
        /// 设置随机数值.
        /// </summary>
        protected void SetRandomData()
        {
            // 根据 1 到 拼图画面的元素个数 之间的数据列表， 进行随机排序.
            var query =
                from data in Enumerable.Range(1, this.PuzzleItemCount)
                orderby Guid.NewGuid()
                select data;

            // 随机排序数据到临时列表.
            List<int> randomList = query.ToList();

            int index = 0;

            // 开始向结果列表填写数据.
            for (int i = 0; i < PuzzleSize; i++)
            {
                for (int j = 0; j < PuzzleSize; j++)
                {
                    if (index < randomList.Count)
                    {
                        PuzzleArray[i, j] = randomList[index++];
                    }
                }
            }

        }



        /// <summary>
        /// 是否已经处理完成.
        /// </summary>
        public bool IsFinish
        {
            get
            {
                int startIndex = 1;

                // 如果 右下角单元格不为0， 不需要逐行比较了，直接返回 fasle.
                if (PuzzleArray[PuzzleSize - 1, PuzzleSize-1] != 0)
                {
                    return false;
                }


                // 开始逐行比较
                // 中间只要有任意一行不匹配，直接返回 false.
                for (int i = 0; i < PuzzleSize; i++)
                {
                    for (int j = 0; j < PuzzleSize; j++)
                    {
                        if (PuzzleArray[i, j] != startIndex++)
                        {
                            return false;
                        }

                        if (startIndex >= PuzzleItemCount)
                        {
                            // 全部数据核对完毕.
                            break;
                        }
                    }
                }

                // 返回.
                return true; 
            }
        }





        /// <summary>
        /// 坐标为 (i,j) 上面的元素. 是否可移动.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool IsMoveAble(int i, int j)
        {
            if (PuzzleArray[i, j] == 0)
            {
                // 空格不能移动.
                return false;
            }
            // 上边是0 (空格).
            if (PuzzleArray[i, Math.Max(0, j - 1)] == 0)
            {
                // 可以上移.
                return true;
            }
            // 左边是0 (空格).
            if (PuzzleArray[Math.Max(0, i - 1), j] == 0)
            {
                // 可以左移.
                return true;
            }
            // 下边是0 (空格).
            if (PuzzleArray[i, Math.Min(PuzzleSize - 1, j + 1)] == 0)
            {
                // 可以下移.
                return true;
            }
            // 右边是0(空格).
            if (PuzzleArray[Math.Min(PuzzleSize - 1, i + 1), j] == 0)
            {
                // 可以右移.
                return true;
            }


            // 上左下右都不是空格.
            return false;
        }



        /// <summary>
        /// 移动 坐标为 (i,j) 上面的元素.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool Move(int i, int j)
        {
            //Console.WriteLine("Move({0}, {1})", i, j);

            if (PuzzleArray[i, j] == 0)
            {
                // 空格不能移动.
                return false;
            }

            // 左边是0 (空格).
            if ( j > 0 &&  PuzzleArray[i, j - 1] == 0)
            {
                // 左移.
                PuzzleArray[i, j-1] = PuzzleArray[i, j];
                PuzzleArray[i, j] = 0;


                MoveStep ms = new MoveStep(i, j);
                MoveStepList.Add(ms);
                if (Moving != null)
                {
                    Moving(ms, MoveDirection.Left);
                }

                return true;
            }

            // 上边是0 (空格).
            if (i > 0 && PuzzleArray[i - 1, j] == 0)
            {
                // 上移.
                PuzzleArray[i - 1, j] = PuzzleArray[i, j];
                PuzzleArray[i, j] = 0;

                MoveStep ms = new MoveStep(i, j);
                MoveStepList.Add(ms);
                if (Moving != null)
                {
                    Moving(ms, MoveDirection.Up);
                }
                return true;
            }


            // 右边是0 (空格).
            if ( j<PuzzleSize-1 &&  PuzzleArray[i, j + 1] == 0)
            {
                // 右移.
                PuzzleArray[i, j + 1] = PuzzleArray[i, j];
                PuzzleArray[i, j] = 0;

                MoveStep ms = new MoveStep(i, j);
                MoveStepList.Add(ms);
                if (Moving != null)
                {
                    Moving(ms, MoveDirection.Right);
                }
                return true;
            }

            // 下边是0(空格).
            if (i < PuzzleSize - 1 && PuzzleArray[i + 1, j] == 0)
            {
                // 下移.
                PuzzleArray[i + 1, j] = PuzzleArray[i, j];
                PuzzleArray[i, j] = 0;

                MoveStep ms = new MoveStep(i, j);
                MoveStepList.Add(ms);
                if (Moving != null)
                {
                    Moving(ms, MoveDirection.Down);
                }
                return true;
            }


            // 上左下右都不是空格.
            return false;
        }


        /// <summary>
        /// 用于调试的输出.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // 结果缓冲.
            StringBuilder buff = new StringBuilder();

            for (int i = 0; i < PuzzleSize; i++)
            {
                buff.AppendFormat("|");
                for (int j = 0; j < PuzzleSize; j++)
                {
                    buff.AppendFormat("  {0:00}  |", PuzzleArray[i, j]);
                }
                // 换行.
                buff.AppendLine();
            }

            // 返回.
            return buff.ToString();
        }





        /// <summary>
        /// 函数p(x)定义为：x数所在位置前面的数比x小的数的个数.
        /// </summary>
        public int GetP(int[,] puzzleArray)
        {
            // 二维数组切换为一维数组.
            int[] tempPuzzleArray = puzzleArray.Cast<int>().ToArray();
            // 预期结果.
            int pCount = 0;
            for (int i = 0; i < tempPuzzleArray.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (tempPuzzleArray[j] < tempPuzzleArray[i])
                    {
                        pCount++;
                    }
                }
            }
            return pCount;
        }


    }


}
