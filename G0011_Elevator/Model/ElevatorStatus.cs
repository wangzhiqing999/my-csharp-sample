using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0011_Elevator.Model
{




    /// <summary>
    /// 电梯的状态.
    /// </summary>
    public abstract class ElevatorStatus
    {
        /// <summary>
        /// 电梯基本数据.
        /// </summary>
        public Elevator ElevatorData { set; get; }


        /// <summary>
        /// 向上.
        /// </summary>
        public virtual bool Up()
        {
            ElevatorData.CurrentFloor++;

            if (ElevatorData.CurrentFloor >= this.ElevatorData.MaxFloor)
            {
                // 到达顶层，状态变更.
                this.ElevatorData.Status = new ElevatorStatusIsTop()
                {
                    ElevatorData = this.ElevatorData,
                };
            }

            return true;
        }


        /// <summary>
        /// 向下.
        /// </summary>
        public virtual bool Down()
        {
            ElevatorData.CurrentFloor--;
            if (ElevatorData.CurrentFloor <= this.ElevatorData.MinFloor)
            {
                // 到达底层，状态变更.
                this.ElevatorData.Status = new ElevatorStatusIsBottom()
                {
                    ElevatorData = this.ElevatorData,
                };
            }
            return true;
        }


    }





    /// <summary>
    /// 电梯的状态 ： 正常状态.
    /// </summary>
    public class ElevatorStatusIsNormal : ElevatorStatus
    {
        /// <summary>
        /// 构造函数.
        /// </summary>
        public ElevatorStatusIsNormal()
        {
        }
    }





    /// <summary>
    /// 电梯的状态： 顶楼.
    /// </summary>
    public class ElevatorStatusIsTop : ElevatorStatus
    {
        /// <summary>
        /// 构造函数.
        /// </summary>
        public ElevatorStatusIsTop()
        {
        }



        /// <summary>
        /// 向上.
        /// </summary>
        public override bool Up()
        {
            // 顶楼无法向上.
            // Do Nothing...
            return false;
        }


        /// <summary>
        /// 向下.
        /// </summary>
        public override bool Down()
        {
            // 底楼只要向下， 状态变更.
            this.ElevatorData.Status = new ElevatorStatusIsNormal()
            {
                ElevatorData = this.ElevatorData,
            };

            return base.Down();
        }
    }




    /// <summary>
    /// 电梯的状态： 底楼.
    /// </summary>
    public class ElevatorStatusIsBottom : ElevatorStatus
    {

        /// <summary>
        /// 构造函数.
        /// </summary>
        public ElevatorStatusIsBottom()
        {
        }



        /// <summary>
        /// 向上
        /// </summary>
        /// <returns></returns>
        public override bool Up()
        {
            // 底楼只要向上， 状态变更.
            this.ElevatorData.Status = new ElevatorStatusIsNormal()
            {
                ElevatorData = this.ElevatorData,
            };

            return base.Up();
        }


        /// <summary>
        /// 向下.
        /// </summary>
        public override bool Down()
        {
            // 底楼无法向下.
            // Do Nothing...
            return false;
        }


    }





    



}
