using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0101_Maze.Service
{
    /// <summary>
    /// 移动方向.
    /// </summary>
    public enum MoveDirection
    {
        /// <summary>
        /// 无法移动.
        /// </summary>
        None = 0,

        /// <summary>
        /// 向左移动.
        /// </summary>
        Left =1,

        /// <summary>
        /// 向上移动.
        /// </summary>
        Up = 2,

        /// <summary>
        /// 向右移动.
        /// </summary>
        Right = 3,

        /// <summary>
        /// 向下移动.
        /// </summary>
        Down = 4,
    }
}
