using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace G0051_Jigsaw.Service
{


    /// <summary>
    /// 3x3  8个单元格的数据测试.
    /// </summary>
    [TestFixture]
    public class Puzzle8Test
    {

        /// <summary>
        /// 初始化测试.
        /// </summary>
        [Test]
        public void InitPuzzleTest()
        {
            // 拼图数据.
            Puzzle8 puzzle = new Puzzle8();

            // 初始化.
            puzzle.InitPuzzle();

            // 3x3 拼图， 可用元素 = 8 个.
            Assert.AreEqual(8, puzzle.PuzzleItemCount);

            // 初始化出来的数据， 不应该是已经完成的数据.
            Assert.IsFalse(puzzle.IsFinish);


            // 右下角最后一个数据为 0.
            Assert.AreEqual(0, puzzle[2, 2]);

            // 其他数据都不为0.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i != 2 && j != 2)
                    {
                        Assert.AreNotEqual(0, puzzle[i, j]);
                    }
                }
            }


            // 输出到控制台调试信息.
            Console.WriteLine(puzzle);



            

            // 第一行没法移动.
            for (int j = 0; j < 3; j++)
            {
                Assert.IsFalse(puzzle.IsMoveAble(0, j));
            }
            // 第一列没法移动.
            for (int i = 0; i < 3; i++)
            {
                Assert.IsFalse(puzzle.IsMoveAble(i, 0));
            }

            // 中间那个无法移动.
            Assert.IsFalse(puzzle.IsMoveAble(1, 1));

            // 可移动的测试.
            Assert.IsTrue(puzzle.IsMoveAble(1, 2));
            Assert.IsTrue(puzzle.IsMoveAble(2, 1));
        }



        [Test]
        public void IsFinishTest()
        {
            int[,] dataArrayCase1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase1 = new Puzzle8(dataArrayCase1);
            Assert.IsTrue(puzzleCase1.IsFinish);


        }




        /// <summary>
        /// 测试数据移动1.
        /// </summary>
        [Test]
        public void Move01Test()
        {
            int[,] dataArrayCase1 = {{1,2,3},{4,5,6},{7,8,0}};
            // 拼图数据.
            Puzzle8 puzzleCase1 = new Puzzle8(dataArrayCase1);
            // 尝试移动.
            puzzleCase1.AutoMove01();
            // 结果：1已经在指定位置，不需要移动.
            Assert.AreEqual(0, puzzleCase1.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase1[0, 0]);
            Assert.AreEqual(0, puzzleCase1[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase1);


            int[,] dataArrayCase2 = { 
                                    { 2, 1, 3 }, 
                                    { 4, 5, 6 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase2 = new Puzzle8(dataArrayCase2);
            // 尝试移动.
            puzzleCase2.AutoMove01();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase2.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase2[0, 0]);
            Assert.AreEqual(0, puzzleCase2[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase2);



            int[,] dataArrayCase3 = { 
                                    { 2, 3, 1 }, 
                                    { 4, 5, 6 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase3 = new Puzzle8(dataArrayCase3);
            // 尝试移动.
            puzzleCase3.AutoMove01();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase3.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase3[0, 0]);
            Assert.AreEqual(0, puzzleCase3[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase3);



            int[,] dataArrayCase4 = { 
                                    { 2, 3, 4 }, 
                                    { 1, 5, 6 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase4 = new Puzzle8(dataArrayCase4);
            // 尝试移动.
            puzzleCase4.AutoMove01();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase4.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase4[0, 0]);
            Assert.AreEqual(0, puzzleCase4[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase4);



            int[,] dataArrayCase5 = { 
                                    { 2, 3, 4 }, 
                                    { 5, 1, 6 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase5 = new Puzzle8(dataArrayCase5);
            // 尝试移动.
            puzzleCase5.AutoMove01();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase5.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase5[0, 0]);
            Assert.AreEqual(0, puzzleCase5[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase5);




            int[,] dataArrayCase6 = { 
                                    { 2, 3, 4 }, 
                                    { 5, 6, 1 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase6 = new Puzzle8(dataArrayCase6);
            // 尝试移动.
            puzzleCase6.AutoMove01();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase6.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase6[0, 0]);
            Assert.AreEqual(0, puzzleCase6[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase6);





            int[,] dataArrayCase7 = { 
                                    { 2, 3, 4 }, 
                                    { 5, 6, 7 }, 
                                    { 1, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase7 = new Puzzle8(dataArrayCase7);
            // 尝试移动.
            puzzleCase7.AutoMove01();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase7.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase7[0, 0]);
            Assert.AreEqual(0, puzzleCase7[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase7);





            int[,] dataArrayCase8 = { 
                                    { 2, 3, 4 }, 
                                    { 5, 6, 7 }, 
                                    { 8, 1, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase8 = new Puzzle8(dataArrayCase8);
            // 尝试移动.
            puzzleCase8.AutoMove01();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase8.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase8[0, 0]);
            Assert.AreEqual(0, puzzleCase8[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase8);
        }


        /// <summary>
        /// 测试数据移动2.
        /// </summary>
        [Test]
        public void Move02Test()
        {
            int[,] dataArrayCase1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase1 = new Puzzle8(dataArrayCase1);
            // 尝试移动.
            puzzleCase1.AutoMove02();
            // 结果：2已经在指定位置，不需要移动.
            Assert.AreEqual(0, puzzleCase1.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase1[0, 0]);
            Assert.AreEqual(2, puzzleCase1[0, 1]);
            Assert.AreEqual(0, puzzleCase1[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase1);





            int[,] dataArrayCase3 = { 
                                    { 1, 3, 2 }, 
                                    { 4, 5, 6 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase3 = new Puzzle8(dataArrayCase3);
            // 尝试移动.
            puzzleCase3.AutoMove02();
            // 结果：2已经发生移动.
            Assert.AreNotEqual(0, puzzleCase3.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase3[0, 0]);
            Assert.AreEqual(2, puzzleCase3[0, 1]);
            Assert.AreEqual(0, puzzleCase3[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase3);



            int[,] dataArrayCase4 = { 
                                    { 1, 3, 4 }, 
                                    { 2, 5, 6 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase4 = new Puzzle8(dataArrayCase4);
            // 尝试移动.
            puzzleCase4.AutoMove02();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase4.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase4[0, 0]);
            Assert.AreEqual(2, puzzleCase4[0, 1]);
            Assert.AreEqual(0, puzzleCase4[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase4);


            int[,] dataArrayCase5 = { 
                                    { 1, 3, 4 }, 
                                    { 5, 2, 6 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase5 = new Puzzle8(dataArrayCase5);
            // 尝试移动.
            puzzleCase5.AutoMove02();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase5.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase5[0, 0]);
            Assert.AreEqual(2, puzzleCase5[0, 1]);
            Assert.AreEqual(0, puzzleCase5[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase5);



            int[,] dataArrayCase6 = { 
                                    { 1, 3, 4 }, 
                                    { 5, 6, 2 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase6 = new Puzzle8(dataArrayCase6);
            // 尝试移动.
            puzzleCase6.AutoMove02();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase6.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase6[0, 0]);
            Assert.AreEqual(2, puzzleCase6[0, 1]);
            Assert.AreEqual(0, puzzleCase6[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase6);



            int[,] dataArrayCase7 = { 
                                    { 1, 3, 4 }, 
                                    { 5, 6, 7 }, 
                                    { 2, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase7 = new Puzzle8(dataArrayCase7);
            // 尝试移动.
            puzzleCase7.AutoMove02();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase7.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase7[0, 0]);
            Assert.AreEqual(2, puzzleCase7[0, 1]);
            Assert.AreEqual(0, puzzleCase7[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase7);

            int[,] dataArrayCase8 = { 
                                    { 1, 3, 4 }, 
                                    { 5, 6, 7 }, 
                                    { 8, 2, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase8 = new Puzzle8(dataArrayCase8);
            // 尝试移动.
            puzzleCase8.AutoMove02();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase8.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase8[0, 0]);
            Assert.AreEqual(2, puzzleCase8[0, 1]);
            Assert.AreEqual(0, puzzleCase8[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase8);

        }




        /// <summary>
        /// 测试数据移动3.
        /// </summary>
        [Test]
        public void Move03Test()
        {
            int[,] dataArrayCase1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase1 = new Puzzle8(dataArrayCase1);
            // 尝试移动.
            puzzleCase1.AutoMove03();
            // 结果：2已经在指定位置，不需要移动.
            Assert.AreEqual(0, puzzleCase1.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase1[0, 0]);
            Assert.AreEqual(2, puzzleCase1[0, 1]);
            Assert.AreEqual(3, puzzleCase1[0, 2]);
            Assert.AreEqual(0, puzzleCase1[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase1);




            int[,] dataArrayCase4 = { 
                                    { 1, 2, 4 }, 
                                    { 3, 5, 6 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase4 = new Puzzle8(dataArrayCase4);
            // 尝试移动.
            puzzleCase4.AutoMove03();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase4.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase4[0, 0]);
            Assert.AreEqual(2, puzzleCase4[0, 1]);
            Assert.AreEqual(3, puzzleCase4[0, 2]);
            Assert.AreEqual(0, puzzleCase4[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase4);





            int[,] dataArrayCase5 = { 
                                    { 1, 2, 4 }, 
                                    { 5, 3, 6 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase5 = new Puzzle8(dataArrayCase5);
            // 尝试移动.
            puzzleCase5.AutoMove03();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase5.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase5[0, 0]);
            Assert.AreEqual(2, puzzleCase5[0, 1]);
            Assert.AreEqual(3, puzzleCase5[0, 2]);
            Assert.AreEqual(0, puzzleCase5[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase5);





            int[,] dataArrayCase6 = { 
                                    { 1, 2, 4 }, 
                                    { 5, 6, 3 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase6 = new Puzzle8(dataArrayCase6);
            // 尝试移动.
            puzzleCase6.AutoMove03();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase6.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase6[0, 0]);
            Assert.AreEqual(2, puzzleCase6[0, 1]);
            Assert.AreEqual(3, puzzleCase6[0, 2]);
            Assert.AreEqual(0, puzzleCase6[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase6);



            int[,] dataArrayCase7 = { 
                                    { 1, 2, 4 }, 
                                    { 5, 6, 7 }, 
                                    { 3, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase7 = new Puzzle8(dataArrayCase7);
            // 尝试移动.
            puzzleCase7.AutoMove03();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase7.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase7[0, 0]);
            Assert.AreEqual(2, puzzleCase7[0, 1]);
            Assert.AreEqual(3, puzzleCase7[0, 2]);
            Assert.AreEqual(0, puzzleCase7[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase7);




            int[,] dataArrayCase8 = { 
                                    { 1, 2, 4 }, 
                                    { 5, 6, 7 }, 
                                    { 8, 3, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase8 = new Puzzle8(dataArrayCase8);
            // 尝试移动.
            puzzleCase8.AutoMove03();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase8.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase8[0, 0]);
            Assert.AreEqual(2, puzzleCase8[0, 1]);
            Assert.AreEqual(3, puzzleCase7[0, 2]);
            Assert.AreEqual(0, puzzleCase8[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase8);


        }



        /// <summary>
        /// 测试数据移动4.
        /// </summary>
        [Test]
        public void Move04Test()
        {
            int[,] dataArrayCase1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase1 = new Puzzle8(dataArrayCase1);
            // 尝试移动.
            puzzleCase1.AutoMove04();
            // 结果：2已经在指定位置，不需要移动.
            Assert.AreEqual(0, puzzleCase1.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase1[0, 0]);
            Assert.AreEqual(2, puzzleCase1[0, 1]);
            Assert.AreEqual(3, puzzleCase1[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(0, puzzleCase1[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase1);



            int[,] dataArrayCase5 = { 
                                    { 1, 2, 3 }, 
                                    { 5, 4, 6 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase5 = new Puzzle8(dataArrayCase5);
            // 尝试移动.
            puzzleCase5.AutoMove04();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase5.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase5[0, 0]);
            Assert.AreEqual(2, puzzleCase5[0, 1]);
            Assert.AreEqual(3, puzzleCase5[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(0, puzzleCase5[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase5);




            int[,] dataArrayCase6 = { 
                                    { 1, 2, 3 }, 
                                    { 5, 6, 4 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase6 = new Puzzle8(dataArrayCase6);
            // 尝试移动.
            puzzleCase6.AutoMove04();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase6.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase6[0, 0]);
            Assert.AreEqual(2, puzzleCase6[0, 1]);
            Assert.AreEqual(3, puzzleCase6[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(0, puzzleCase6[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase6);



            int[,] dataArrayCase7 = { 
                                    { 1, 2, 3 }, 
                                    { 5, 6, 7 }, 
                                    { 4, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase7 = new Puzzle8(dataArrayCase7);
            // 尝试移动.
            puzzleCase7.AutoMove04();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase7.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase7[0, 0]);
            Assert.AreEqual(2, puzzleCase7[0, 1]);
            Assert.AreEqual(3, puzzleCase7[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(0, puzzleCase7[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase7);



            int[,] dataArrayCase8 = { 
                                    { 1, 2, 3 }, 
                                    { 5, 6, 7 }, 
                                    { 8, 4, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase8 = new Puzzle8(dataArrayCase8);
            // 尝试移动.
            puzzleCase8.AutoMove04();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase8.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase8[0, 0]);
            Assert.AreEqual(2, puzzleCase8[0, 1]);
            Assert.AreEqual(3, puzzleCase7[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(0, puzzleCase8[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase8);
        }



        /// <summary>
        /// 测试数据移动5.
        /// </summary>
        [Test]
        public void Move05Test()
        {
            int[,] dataArrayCase1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase1 = new Puzzle8(dataArrayCase1);
            // 尝试移动.
            puzzleCase1.AutoMove05();
            // 结果：2已经在指定位置，不需要移动.
            Assert.AreEqual(0, puzzleCase1.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase1[0, 0]);
            Assert.AreEqual(2, puzzleCase1[0, 1]);
            Assert.AreEqual(3, puzzleCase1[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(5, puzzleCase1[1, 1]);
            Assert.AreEqual(0, puzzleCase1[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase1);




            int[,] dataArrayCase6 = { 
                                    { 1, 2, 3 }, 
                                    { 4, 6, 5 }, 
                                    { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase6 = new Puzzle8(dataArrayCase6);
            // 尝试移动.
            puzzleCase6.AutoMove05();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase6.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase6[0, 0]);
            Assert.AreEqual(2, puzzleCase6[0, 1]);
            Assert.AreEqual(3, puzzleCase6[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(5, puzzleCase1[1, 1]);
            Assert.AreEqual(0, puzzleCase6[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase6);



            int[,] dataArrayCase7 = { 
                                    { 1, 2, 3 }, 
                                    { 4, 6, 7 }, 
                                    { 5, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase7 = new Puzzle8(dataArrayCase7);
            // 尝试移动.
            puzzleCase7.AutoMove05();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase7.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase7[0, 0]);
            Assert.AreEqual(2, puzzleCase7[0, 1]);
            Assert.AreEqual(3, puzzleCase7[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(5, puzzleCase1[1, 1]);
            Assert.AreEqual(0, puzzleCase7[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase7);



            int[,] dataArrayCase8 = { 
                                    { 1, 2, 3 }, 
                                    { 4, 6, 7 }, 
                                    { 8, 5, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase8 = new Puzzle8(dataArrayCase8);
            // 尝试移动.
            puzzleCase8.AutoMove05();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase8.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase8[0, 0]);
            Assert.AreEqual(2, puzzleCase8[0, 1]);
            Assert.AreEqual(3, puzzleCase7[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(5, puzzleCase1[1, 1]);
            Assert.AreEqual(0, puzzleCase8[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase8);
        }



        /// <summary>
        /// 测试数据移动6.
        /// </summary>
        [Test]
        public void Move06Test()
        {
            int[,] dataArrayCase1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase1 = new Puzzle8(dataArrayCase1);
            // 尝试移动.
            puzzleCase1.AutoMove06();
            // 结果：2已经在指定位置，不需要移动.
            Assert.AreEqual(0, puzzleCase1.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase1[0, 0]);
            Assert.AreEqual(2, puzzleCase1[0, 1]);
            Assert.AreEqual(3, puzzleCase1[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(5, puzzleCase1[1, 1]);
            Assert.AreEqual(6, puzzleCase1[1, 2]);
            Assert.AreEqual(0, puzzleCase1[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase1);



            int[,] dataArrayCase7 = { 
                                    { 1, 2, 3 }, 
                                    { 4, 5, 7 }, 
                                    { 6, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase7 = new Puzzle8(dataArrayCase7);
            // 尝试移动.
            puzzleCase7.AutoMove06();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase7.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase7[0, 0]);
            Assert.AreEqual(2, puzzleCase7[0, 1]);
            Assert.AreEqual(3, puzzleCase7[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(5, puzzleCase1[1, 1]);
            Assert.AreEqual(6, puzzleCase1[1, 2]);
            Assert.AreEqual(0, puzzleCase7[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase7);



            int[,] dataArrayCase8 = { 
                                    { 1, 2, 3 }, 
                                    { 4, 5, 7 }, 
                                    { 8, 6, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase8 = new Puzzle8(dataArrayCase8);
            // 尝试移动.
            puzzleCase8.AutoMove06();
            // 结果：1已经发生移动.
            Assert.AreNotEqual(0, puzzleCase8.MoveStepList.Count);
            Assert.AreEqual(1, puzzleCase8[0, 0]);
            Assert.AreEqual(2, puzzleCase8[0, 1]);
            Assert.AreEqual(3, puzzleCase7[0, 2]);
            Assert.AreEqual(4, puzzleCase1[1, 0]);
            Assert.AreEqual(5, puzzleCase1[1, 1]);
            Assert.AreEqual(6, puzzleCase1[1, 2]);
            Assert.AreEqual(0, puzzleCase8[2, 2]);
            // 输出到控制台调试信息.
            Console.WriteLine(puzzleCase8);
        }



        /// <summary>
        /// 有解/无解测试.
        /// </summary>
        [Test]
        public void HaveSolutionTest()
        {
            int[,] dataArrayCase1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase1 = new Puzzle8(dataArrayCase1);
            // 该数据是有解的.
            Assert.IsTrue(puzzleCase1.HaveSolution());

            int[,] dataArrayCase2 = { { 2, 1, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase2 = new Puzzle8(dataArrayCase2);
            // 该数据是无解的.
            Assert.IsFalse(puzzleCase2.HaveSolution());

            int[,] dataArrayCase3 = { { 1, 2, 3 }, { 4, 5, 6 }, { 8, 7, 0 } };
            // 拼图数据.
            Puzzle8 puzzleCase3 = new Puzzle8(dataArrayCase3);
            // 该数据是无解的.
            Assert.IsFalse(puzzleCase3.HaveSolution());
        }
    }

}
