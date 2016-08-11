using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace G0101_Maze.Service
{
    [TestFixture]
    public class MazeTest
    {


        /// <summary>
        /// 基本 Getter 属性测试.
        /// </summary>
        [Test]
        public void BaseGetterTest()
        {
            // 默认构造函数创建的 迷宫.  
            Maze maze = new Maze();

            // 预期行.
            Assert.AreEqual(Maze.DefaultMaze.GetLength(0), maze.MazeRows);
            // 预期列.
            Assert.AreEqual(Maze.DefaultMaze.GetLength(1), maze.MazeColumns);


            // 第1行，第1列 是开始.
            Assert.AreEqual(Maze.START_FLAG, maze[0, 0]);
            // 第1行 2,3,4 
            Assert.AreEqual(0, maze[0, 1]);
            Assert.AreEqual(0, maze[0, 2]);
            Assert.AreEqual(0, maze[0, 3]);



            // 第2行 1,2,3,4 
            Assert.AreEqual(1, maze[1, 1]);
            Assert.AreEqual(1, maze[1, 1]);
            Assert.AreEqual(1, maze[1, 2]);
            Assert.AreEqual(0, maze[1, 3]);



            // 第3行，第1列 是结束.
            Assert.AreEqual(Maze.FINISH_FLAG, maze[2, 0]);
            // 第3行 2,3,4 
            Assert.AreEqual(0, maze[2, 1]);
            Assert.AreEqual(0, maze[2, 2]);
            Assert.AreEqual(0, maze[2, 3]);




        }



        /// <summary>
        /// 基本 Getter 属性测试.
        /// </summary>
        [Test]
        public void GameTest()
        {

            // 默认构造函数创建的 迷宫.  
            Maze maze = new Maze();

            // 第1行，第1列 是开始.
            Assert.AreEqual(Maze.START_FLAG, maze[0, 0]);

            // 开始.
            maze.Start();


            // 第1行，第1列 是开始. 人在开始的位置上.
            Assert.AreEqual(Maze.START_FLAG | Maze.PLAYER_FLAG, maze[0, 0]);


            // 第1行，第1列   
            // 上，下，左， 都不能移动.
            Assert.IsFalse(maze.Up());
            Assert.IsFalse(maze.Down());
            Assert.IsFalse(maze.Left());

            // 尝试移动到 第一行，第2列.
            Assert.IsTrue(maze.Rigth());
            // 未到达终点.
            Assert.IsFalse(maze.IsFinish);



            // 现在在 第1行，第2列  
            // 上，下， 都不能移动.
            Assert.IsFalse(maze.Up());
            Assert.IsFalse(maze.Down());

            // 尝试移动到 第一行，第3列.
            Assert.IsTrue(maze.Rigth());
            // 未到达终点.
            Assert.IsFalse(maze.IsFinish);


            // 现在在 第1行，第3列  
            // 上，下， 都不能移动.
            Assert.IsFalse(maze.Up());
            Assert.IsFalse(maze.Down());

            // 尝试移动到 第一行，第4列.
            Assert.IsTrue(maze.Rigth());
            // 未到达终点.
            Assert.IsFalse(maze.IsFinish);





            // 现在在 第1行，第4列  
            // 上，右， 都不能移动.
            Assert.IsFalse(maze.Up());
            Assert.IsFalse(maze.Rigth());

            // 尝试移动到 第2行，第4列.
            Assert.IsTrue(maze.Down());
            // 未到达终点.
            Assert.IsFalse(maze.IsFinish);




            // 现在在 第2行，第4列  
            // 左，右， 都不能移动.
            Assert.IsFalse(maze.Left());
            Assert.IsFalse(maze.Rigth());

            // 尝试移动到 第3行，第4列.
            Assert.IsTrue(maze.Down());
            // 未到达终点.
            Assert.IsFalse(maze.IsFinish);




            // 现在在 第3行，第4列  
            // 下，右， 都不能移动.
            Assert.IsFalse(maze.Down());
            Assert.IsFalse(maze.Rigth());

            // 尝试移动到 第3行，第3列.
            Assert.IsTrue(maze.Left());
            // 未到达终点.
            Assert.IsFalse(maze.IsFinish);



            // 现在在 第3行，第3列  
            // 上，下， 都不能移动.
            Assert.IsFalse(maze.Up());
            Assert.IsFalse(maze.Down());

            // 尝试移动到 第3行，第2列.
            Assert.IsTrue(maze.Left());
            // 未到达终点.
            Assert.IsFalse(maze.IsFinish);



            // 现在在 第3行，第2列  
            // 上，下， 都不能移动.
            Assert.IsFalse(maze.Up());
            Assert.IsFalse(maze.Down());

            // 尝试移动到 第3行，第1列.
            Assert.IsTrue(maze.Left());
            // 到达终点.
            Assert.IsTrue(maze.IsFinish);

        }

    }
}
