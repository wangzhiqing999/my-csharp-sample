using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0101_Maze.Service
{

    /// <summary>
    /// 移动步骤.
    /// </summary>
    public class MoveStep
    {
        public MoveStep(int i, int j)
        {
            this.Row = i;
            this.Column = j;
        }

        /// <summary>
        /// Row
        /// </summary>
        public int Row { set; get; }

        /// <summary>
        /// Column.
        /// </summary>
        public int Column { set; get; }
    }
}
