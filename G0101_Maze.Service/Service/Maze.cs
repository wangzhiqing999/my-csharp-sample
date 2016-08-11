using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0101_Maze.Service
{


    /// <summary>
    /// 移动处理事件
    /// </summary>
    /// <param name="step">移动的单元格</param>
    /// <param name="direction">移动的方向</param>
    public delegate void MovingHandler(MoveStep step, MoveDirection direction);

    /// <summary>
    /// 迷宫数据类.
    /// </summary>
    public class Maze
    {

        /// <summary>
        /// 定义事件.
        /// </summary>
        public event MovingHandler Moving;

        // 说明：
        // 每个位置 占用1个byte。
        // 1个 byte 有8位.
        // 第1位为1 表示 开始标志.
        // 第2位为1 表示 结束标志.

        // 第8位为0 表示 玩家可以站在这个位置上.
        // 第8为为1 表示 玩家不能站在这个位置上.

        // 第7位为1 表示 当前玩家正站在这个位置上.

        /// <summary>
        /// 迷宫的开始标志.
        /// 1000 0000
        /// </summary>
        public const byte START_FLAG = 0x80;

        /// <summary>
        /// 迷宫的结束标志.
        /// 0100 0000
        /// </summary>
        public const byte FINISH_FLAG = 0x40;


        /// <summary>
        /// 玩家的标志.
        /// 0000 0010
        /// </summary>
        public const byte PLAYER_FLAG = 0x02;


        /// <summary>
        /// 玩家离开标志.
        /// 1111 1101
        /// </summary>
        private const byte PLAYER_LEAVE_FLAG = 0xFD;


        /// <summary>
        /// 墙的标志.
        /// 0000 0001
        /// </summary>
        public const byte WALL_FLAG = 0x01;


        /// <summary>
        /// 迷宫的单元格.
        /// </summary>
        private byte[,] mazeItems;



        /// <summary>
        /// 默认的迷宫. 
        /// </summary>
        public static readonly byte[,] DefaultMaze = new byte[3, 4] {
            {START_FLAG, 0, 0, 0},
            {1, 1, 1, 0},
            {FINISH_FLAG, 0, 0, 0}
        };



        /// <summary>
        /// 默认构造函数.
        /// </summary>
        public Maze()
            : this(DefaultMaze)
        {
        }


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="mazeItems"></param>
        public Maze(byte[,] mazeItems)
        {
            this.mazeItems = new byte[ mazeItems.GetLength(0), mazeItems.GetLength(1)];
            Array.Copy(mazeItems, this.mazeItems, mazeItems.Length);
        }




        /// <summary>
        /// 迷宫行数.
        /// </summary>
        public int MazeRows {
            get
            {
                return this.mazeItems.GetLength(0);
            }
        }


        /// <summary>
        /// 迷宫列数.
        /// </summary>
        public int MazeColumns
        {
            get
            {
                return this.mazeItems.GetLength(1);
            }
        }


        /// <summary>
        /// 索引器.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public byte this[int row, int col]
        {
            get
            {
                return this.mazeItems[row, col];
            }
        }



        /// <summary>
        /// 玩家所在的行.
        /// </summary>
        private int playerRow = 0;

        /// <summary>
        /// 玩家所在的列.
        /// </summary>
        private int playerCol = 0;



        /// <summary>
        /// 开始.
        /// </summary>
        public void Start()
        {
            for (int i = 0; i < this.MazeRows; i++)
            {
                for (int j = 0; j < this.MazeColumns; j++)
                {
                    if (this.mazeItems[i, j] == START_FLAG)
                    {
                        playerRow = i;
                        playerCol = j;
                        // 人安排到  开始的位置上.
                        this.mazeItems[i, j] = (byte)(this.mazeItems[i, j] | PLAYER_FLAG);

                        if (Moving != null)
                        {
                            MoveStep ms = new MoveStep(i, j);
                            Moving(ms, MoveDirection.None);
                        }
                        return;
                    }
                }
            }
        }





        /// <summary>
        /// 玩家移动到指定位置.
        /// </summary>
        /// <param name="oldRow"></param>
        /// <param name="oldCol"></param>
        /// <param name="newRow"></param>
        /// <param name="newCol"></param>
        /// <returns></returns>
        private bool PlayerMoveTo(int oldRow, int oldCol, int newRow, int newCol)
        {
            if ((WALL_FLAG & this.mazeItems[newRow, newCol]) != 0)
            {
                // 新的位置有墙.
                return false;
            }

            // 将原有位置，设置为用户离开.
            this.mazeItems[oldRow, oldCol] = (byte)(this.mazeItems[oldRow, oldCol] & PLAYER_LEAVE_FLAG);
            
            // 目标位置，设置为用户存在.
            this.mazeItems[newRow, newCol] = (byte)(this.mazeItems[newRow, newCol] | PLAYER_FLAG);

            // 调整用户当前位置.
            playerRow = newRow;
            playerCol = newCol;



            if (Moving != null)
            {
                MoveStep ms = new MoveStep(oldRow, oldCol);
                if (oldCol == newCol)
                {
                    if (oldRow == newRow - 1)
                    {
                        // 下
                        Moving(ms, MoveDirection.Down);
                    }
                    else
                    {
                        // 上
                        Moving(ms, MoveDirection.Up);
                    }
                }
                else
                {
                    if (oldCol == newCol - 1)
                    {
                        // 右
                        Moving(ms, MoveDirection.Right);
                    }
                    else
                    {
                        // 左
                        Moving(ms, MoveDirection.Left);
                    }
                }
               
            }

            // 认为成功的移动了.
            return true;
        }


        /// <summary>
        /// 向上移动.
        /// </summary>
        /// <returns> 移动成功则返回 true, 否则返回false </returns>
        public bool Up()
        {
            if (playerRow == 0)
            {
                // 已经到顶，不能向上移动了.
                return false;
            }
            // 尝试移动.
            return PlayerMoveTo(playerRow, playerCol, playerRow - 1, playerCol);
        }

        /// <summary>
        /// 向下移动.
        /// </summary>
        /// <returns> 移动成功则返回 true, 否则返回false </returns>
        public bool Down()
        {
            if (playerRow == this.MazeRows - 1)
            {
                // 已经到底，不能向下移动了.
                return false;
            }
            // 尝试移动.
            return PlayerMoveTo(playerRow, playerCol, playerRow + 1, playerCol);
        }

        /// <summary>
        /// 向左移动.
        /// </summary>
        /// <returns></returns>
        public bool Left()
        {
            if (playerCol == 0)
            {
                // 已经到最左，不能向左移动了.
                return false;
            }
            // 尝试移动.
            return PlayerMoveTo(playerRow, playerCol, playerRow, playerCol - 1);
        }

        /// <summary>
        /// 向右移动.
        /// </summary>
        /// <returns></returns>
        public bool Rigth()
        {
            if (playerCol == this.MazeColumns - 1)
            {
                // 已经到最右，不能向右移动了.
                return false;
            }
            // 尝试移动.
            return PlayerMoveTo(playerRow, playerCol, playerRow , playerCol + 1);
        }



        /// <summary>
        /// 是否到达终点.
        /// </summary>
        /// <returns></returns>
        public bool IsFinish
        {
            get{
                return (this.mazeItems[playerRow, playerCol] & FINISH_FLAG) != 0;
            }
        }


    }

}
