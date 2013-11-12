using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0011_Elevator.Model
{
    /// <summary>
    /// 外部命令.
    /// 
    /// 外部只有  上，下 的命令.
    /// </summary>
    public class CommandOutside
    {
        public enum CommandOutsideType
        {
            Up,
            Down
        };


        /// <summary>
        /// 命令类型.
        /// </summary>
        public CommandOutsideType CommandType { set; get; }


        /// <summary>
        /// 命令来自的楼层.
        /// </summary>
        public int FromFloorNum { set; get; }
    }

}
