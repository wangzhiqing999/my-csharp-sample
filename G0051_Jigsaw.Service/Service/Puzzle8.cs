using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0051_Jigsaw.Service
{


    public class Puzzle8 : Puzzle
    {

        /// <summary>
        /// 默认的预期的结果.
        /// </summary>
        protected int[,] DefaultPuzzleResultArray =  { 
                { 1, 2, 3 }, 
                { 4, 5, 6 }, 
                { 7, 8, 0 } 
            };


        /// <summary>
        /// 构造函数.
        /// </summary>
        public Puzzle8()
        {
            // 边长为 3.
            PuzzleSize = 3;
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataArray">外部指定的数组.</param>
        public Puzzle8(int[,] dataArray)
        {
            // 边长为 3.
            PuzzleSize = 3;

            // 使用外部指定的数组.
            PuzzleArray = dataArray;
        }


 


        #region 自动处理第一行.


        /// <summary>
        /// 将 01 移动至左上角， 坐标 [0,0] 的位置.
        /// 
        /// 移动完毕后，要求 坐标 [0，0] = 1;  [2, 2] = 0;
        /// </summary>
        public void AutoMove01()
        {
            // 1  x  x
            // x  x  x
            // x  x  
            if (base.PuzzleArray[0, 0] == 1)
            {
                // 不需要处理.
                // 因为已经在 指定位置了.
                return;
            }

            // 逆时针处理.
            // x  1  x
            // x  x  x
            // x  x  
            // ----------
            // x  x  1
            // x  x  x
            // x  x  
            // ----------
            // x  x  x
            // x  x  1
            // x  x  
            if (base.PuzzleArray[0, 1] == 1
                || base.PuzzleArray[0, 2] == 1 
                || base.PuzzleArray[1, 2] == 1)
            {
                base.Move(2, 1);
                base.Move(2, 0);
                base.Move(1, 0);
                base.Move(0, 0);
                base.Move(0, 1);
                base.Move(0, 2);

                base.Move(1, 2);
                base.Move(2, 2);

                // 递归处理. 直到 [0,0]=1
                AutoMove01();
                return;
            }


            // 顺时针处理.
            // x  x  x
            // 1  x  x
            // x  x  
            // ----------
            // x  x  x
            // x  x  x
            // 1  x  
            // ----------
            // x  x  x
            // x  x  x
            // x  1  
            if (base.PuzzleArray[1, 0] == 1
                || base.PuzzleArray[2, 0] == 1
                || base.PuzzleArray[2, 1] == 1)
            {
                base.Move(1, 2);
                base.Move(0, 2);
                base.Move(0, 1);
                base.Move(0, 0);
                base.Move(1, 0);
                base.Move(2, 0);

                base.Move(2, 1);
                base.Move(2, 2);

                // 递归处理.
                AutoMove01();
                return;
            }


            // x  x  x
            // x  1  x
            // x  x  
            if (base.PuzzleArray[1, 1] == 1)
            {
                base.Move(1, 2);
                base.Move(0, 2);
                base.Move(0, 1);
                base.Move(1, 1);
                base.Move(2, 1);
                base.Move(2, 2);

                // 把 01 从 [1，1] 移动到 [0,1]
                // 再把 [2,2] 设置为空白.
                // 然后递归处理.
                AutoMove01();
                return;
            }

        }


        /// <summary>
        /// 将 02 移动至正上方坐标 [0,1] 的位置.
        /// 
        /// 移动完毕后，要求 坐标 [0，0] = 1;  [0, 1] = 2;   [2, 2] = 0;
        /// </summary>
        public void AutoMove02()
        {
            // 1  2  x
            // x  x  x
            // x  x  
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2)
            {
                // 不需要处理.
                // 因为已经在 指定位置了.
                return;
            }


            // 逆时针处理.
            // 1  x  2
            // x  x  x
            // x  x  
            // ----------
            // 1  x  x
            // x  x  2
            // x  x  

            if (base.PuzzleArray[0, 0] == 1 
                && (base.PuzzleArray[0, 2] == 2
                || base.PuzzleArray[1, 2] == 2))
            {
                base.Move(2, 1);
                base.Move(1, 1);
                base.Move(0, 1);
                base.Move(0, 2);
                base.Move(1, 2);
                base.Move(2, 2);

                // 递归处理.
                AutoMove02();
                return;
            }


            // 顺时针处理.
            // 1  x  x
            // x  2  x
            // x  x
            // ----------
            // 1  x  x
            // x  x  x
            // x  2
            if (base.PuzzleArray[0, 0] == 1
                && (base.PuzzleArray[1, 1] == 2
                || base.PuzzleArray[2, 1] == 2))
            {
                base.Move(1, 2);
                base.Move(0, 2);
                base.Move(0, 1);
                base.Move(1, 1);
                base.Move(2, 1);
                base.Move(2, 2);
                // 递归处理.
                AutoMove02();
                return;
            }


            // 顺时针处理 2.
            // 1  x  x
            // 2  x  x
            // x  x
            // ----------
            // 1  x  x
            // x  x  x
            // 2  x
            if (base.PuzzleArray[0, 0] == 1
                && (base.PuzzleArray[1, 0] == 2
                || base.PuzzleArray[2, 0] == 2))
            {
                base.Move(1, 2);
                base.Move(1, 1);
                base.Move(1, 0);
                base.Move(2, 0);
                base.Move(2, 1);
                base.Move(2, 2);
                // 递归处理.
                AutoMove02();
                return;
            }
        }




        /// <summary>
        /// 将 03 移动至正上方坐标 [0,2] 的位置.
        /// 
        /// 移动完毕后，要求 坐标 [0，0] = 1;  [0, 1] = 2;  [0, 2] = 3;  [2, 2] = 0;
        /// </summary>
        public void AutoMove03()
        {
            // 1  2  3
            // x  x  x
            // x  x  
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[0, 2] == 3)
            {
                // 不需要处理.
                // 因为已经在 指定位置了.
                return;
            }


            // 1  2  x
            // x  3  x
            // x  x
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[1, 1] == 3)
            {
                base.Move(2, 1);
                base.Move(2, 0);
                base.Move(1, 0);
                base.Move(0, 0);
                base.Move(0, 1);
                base.Move(1, 1);
                base.Move(1, 2);
                base.Move(0, 2);
                base.Move(0, 1);
                base.Move(0, 0);
                base.Move(1, 0);
                base.Move(2, 0);
                base.Move(2, 1);
                base.Move(2, 2);
                return;
            }


            // 顺时针处理.
            // 1  2  x
            // 3  x  x
            // x  x
            // --------
            // 1  2  x
            // x  x  x
            // 3  x
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 &&
                (base.PuzzleArray[1, 0] == 3 || base.PuzzleArray[2, 0] == 3))
            {

                base.Move(1, 2);
                base.Move(1, 1);
                base.Move(1, 0);
                base.Move(2, 0);
                base.Move(2, 1);
                base.Move(2, 2);

                // 递归处理.
                AutoMove03();

                return;
            }


            // 逆时针处理.
            // 1  2  x
            // x  x  3
            // x  x
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[1, 2] == 3)
            {
                base.Move(2, 1);
                base.Move(1, 1);
                base.Move(1, 2);
                base.Move(2, 2);

                // 递归处理.
                AutoMove03();
                return;
            }


            // 1  2  x
            // x  x  x
            // x  3
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[2, 1] == 3)
            {
                base.Move(1, 2);
                base.Move(1, 1);
                base.Move(2, 1);
                base.Move(2, 2);

                // 递归处理.
                AutoMove03();
                return;
            }

        }



        /// <summary>
        /// 移动第一行.
        /// </summary>
        public void AutoMoveFirstLine()
        {
            this.AutoMove01();
            this.AutoMove02();
            this.AutoMove03();
        }


        #endregion




        #region 自动处理第二行.



        /// <summary>
        /// 将 04 移动至左中， 坐标 [1,0] 的位置.
        /// 
        /// 移动完毕后，要求 坐标 
        /// [0，0] = 1;  [0, 1] = 2;  [0, 2] = 3;  
        /// [1, 0] = 4;  
        /// [2, 2] = 0;
        /// </summary>
        public void AutoMove04()
        {
            // 1  2  3
            // 4  x  x
            // x  x  
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[0, 2] == 3
                && base.PuzzleArray[1, 0] == 4)
            {
                // 不需要处理.
                // 因为已经在 指定位置了.
                return;
            }

            // 顺时针.
            // 1  2  3
            // x  x  x
            // 4  x  
            // ----------
            // 1  2  3
            // x  x  x
            // x  4
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[0, 2] == 3
                && (base.PuzzleArray[2, 0] == 4 || base.PuzzleArray[2, 1] == 4))
            {
                base.Move(1, 2);
                base.Move(1, 1);
                base.Move(1, 0);
                base.Move(2, 0);
                base.Move(2, 1);
                base.Move(2, 2);

                // 递归处理.
                AutoMove04();
            }

            // 逆时针.
            // 1  2  3
            // x  4  x  
            // x  x  
            // ----------
            // 1  2  3
            // x  x  4
            // x  x
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[0, 2] == 3
                && (base.PuzzleArray[1, 1] == 4 || base.PuzzleArray[1, 2] == 4))
            {
                base.Move(2, 1);
                base.Move(2, 0);
                base.Move(1, 0);
                base.Move(1, 1);
                base.Move(1, 2);
                base.Move(2, 2);

                // 递归处理.
                AutoMove04();
            }

        }


        /// <summary>
        /// 将 05 移动至正中， 坐标 [1,1] 的位置.
        /// 
        /// 移动完毕后，要求 坐标 
        /// [0，0] = 1;  [0, 1] = 2;  [0, 2] = 3;  
        /// [1, 0] = 4;  [1, 1] = 5;  
        /// [2, 2] = 0;
        /// </summary>
        public void AutoMove05()
        {
            // 1  2  3
            // 4  5  x
            // x  x  
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[0, 2] == 3
                && base.PuzzleArray[1, 0] == 4 && base.PuzzleArray[1, 1] == 5)
            {
                // 不需要处理.
                // 因为已经在 指定位置了.
                return;
            }

            // 简单顺时针.
            // 1  2  3
            // 4  x  x
            // x  5  
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[0, 2] == 3
                && base.PuzzleArray[1, 0] == 4 && base.PuzzleArray[2, 1] == 5)
            {
                base.Move(1, 2);
                base.Move(1, 1);
                base.Move(2, 1);
                base.Move(2, 2);
                return;
            }

            // 简单逆时针.
            // 1  2  3
            // 4  x  5
            // x  x
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[0, 2] == 3
                && base.PuzzleArray[1, 0] == 4 && base.PuzzleArray[1, 2] == 5)
            {
                base.Move(2, 1);
                base.Move(1, 1);
                base.Move(1, 2);
                base.Move(2, 2);
                return;
            }

            // 复杂处理.
            // 1  2  3
            // 4  x  x
            // 5  x
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[0, 2] == 3
                && base.PuzzleArray[1, 0] == 4 && base.PuzzleArray[2, 0] == 5)
            {
                base.Move(2, 1);
                base.Move(2, 0);
                base.Move(1, 0);
                base.Move(1, 1);
                base.Move(2, 1);
                base.Move(2, 2);
                base.Move(1, 2);
                base.Move(1, 1);
                base.Move(1, 0);
                base.Move(2, 0);
                base.Move(2, 1);
                base.Move(1, 1);
                base.Move(1, 2);
                base.Move(2, 2);
                return;
            }

        }



        /// <summary>
        /// 将 06 移动至右中， 坐标 [1,2] 的位置.
        /// 
        /// 移动完毕后，要求 坐标 
        /// [0，0] = 1;  [0, 1] = 2;  [0, 2] = 3;
        /// [1, 0] = 4;  [1, 1] = 5;  [1, 2] = 6;
        /// [2, 2] = 0;
        /// </summary>
        public void AutoMove06()
        {
            // 1  2  3
            // 4  5  6
            // x  x  
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[0, 2] == 3
                && base.PuzzleArray[1, 0] == 4 && base.PuzzleArray[1, 1] == 5 && base.PuzzleArray[1, 2] == 6)
            {
                // 不需要处理.
                // 因为已经在 指定位置了.
                return;
            }

            // 位置一.
            // 1  2  3
            // 4  5  x
            // 6  x  
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[0, 2] == 3
                && base.PuzzleArray[1, 0] == 4 && base.PuzzleArray[1, 1] == 5 && base.PuzzleArray[2, 0] == 6)
            {
                base.Move(2, 1);
                base.Move(2, 0);
                base.Move(1, 0);
                base.Move(1, 1);
                base.Move(2, 1);
                base.Move(2, 2);
                base.Move(1, 2);
                base.Move(1, 1);
                base.Move(1, 0);
                base.Move(2, 0);
                base.Move(2, 1);
                base.Move(2, 2);
                return;
            }


            // 位置二.
            // 1  2  3
            // 4  5  x
            // x  6
            if (base.PuzzleArray[0, 0] == 1 && base.PuzzleArray[0, 1] == 2 && base.PuzzleArray[0, 2] == 3
                && base.PuzzleArray[1, 0] == 4 && base.PuzzleArray[1, 1] == 5 && base.PuzzleArray[2, 1] == 6)
            {
                base.Move(2, 1);
                base.Move(2, 0);
                base.Move(1, 0);
                base.Move(1, 1);
                base.Move(1, 2);
                base.Move(2, 2);
                base.Move(2, 1);
                base.Move(1, 1);
                base.Move(1, 0);
                base.Move(2, 0);
                base.Move(2, 1);
                base.Move(2, 2);
                return;
            }
        }



        /// <summary>
        /// 移动第二行.
        /// </summary>
        public void AutoMoveSecondLine()
        {
            AutoMove04();
            AutoMove05();
            AutoMove06();
        }


        #endregion



        /// <summary>
        /// 自动处理.
        /// </summary>
        public void AutoMove()
        {
            AutoMoveFirstLine();
            AutoMoveSecondLine();
        }



        /// <summary>
        /// 利用奇偶性判断所给出的初始状态有无解.
        /// </summary>
        /// <returns></returns>
        public bool HaveSolution()
        {
            int pDefault = base.GetP(DefaultPuzzleResultArray);
            int pCurrent = base.GetP(PuzzleArray);
            return pDefault % 2 == pCurrent % 2;
        }





    }


}
