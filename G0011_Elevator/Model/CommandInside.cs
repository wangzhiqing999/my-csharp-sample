using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0011_Elevator.Model
{
    
    /// <summary>
    /// 内部命令.
    /// 
    /// 
    /// 内部只有  开门、关门、到指定楼层的命令.
    /// </summary>
    public class CommandInside
    {
        public enum CommandInsideType
        {
            Open,
            Close,
            Goto
        };



        /// <summary>
        /// 命令类型.
        /// </summary>
        public CommandInsideType CommandType { set; get; }


        /// <summary>
        /// 需要前往的楼层.
        /// </summary>
        public int GotoFloorNum { set; get; }
    }


}
