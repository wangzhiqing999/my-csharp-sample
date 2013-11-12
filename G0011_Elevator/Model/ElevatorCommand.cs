using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0011_Elevator.Model
{


    /// <summary>
    /// 电梯处理的命令.
    /// </summary>
    public class ElevatorCommand
    {

        /// <summary>
        /// 需要在哪一层楼层停下来.
        /// </summary>
        public int StopAtFloorNum { set; get; }



        /// <summary>
        /// 什么情况下停下来. (向上停？  还是向下停？)
        /// </summary>
        public Elevator.ElevatorRunningStatus StopWhen { set; get; }




        /// <summary>
        /// 调试信息.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("命令：{0} At {1}", StopWhen, StopAtFloorNum);
        }

    }
}
