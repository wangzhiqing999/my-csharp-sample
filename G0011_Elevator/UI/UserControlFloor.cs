using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using G0011_Elevator.Model;



namespace G0011_Elevator.UI
{
    public partial class UserControlFloor : UserControl
    {
        public UserControlFloor()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 电梯管理器.
        /// </summary>
        private ElevatorManager myElevatorManager;

        /// <summary>
        /// 设置管理器.
        /// </summary>
        /// <param name="manager"></param>
        public void SetElevatorManager(ElevatorManager manager)
        {
            this.myElevatorManager = manager;
        }





        /// <summary>
        /// 楼层代码.
        /// </summary>
        public int FloorNo { set; get; }


        /// <summary>
        /// 是否是顶层.
        /// </summary>
        public bool IsTopFloor { set; get; }

        /// <summary>
        /// 是否是底层.
        /// </summary>
        public bool IsBottomFloor { set; get; }
        


        /// <summary>
        /// 初始化楼层.
        /// </summary>
        public void InitFloor()
        {
            // 当前楼层信息.
            this.lblFloorNum.Text = String.Format("{0}楼", this.FloorNo);

            // 顶层不能向上.
            this.btnUp.Visible = !IsTopFloor;

            // 底层不能向下.
            this.btnDown.Visible = !IsBottomFloor;
        }




        /// <summary>
        /// 状态变更.
        /// </summary>
        /// <param name="elevator"></param>
        public void StatusChange(Elevator elevator)
        {
            this.lblCurrentFloor.Text = elevator.CurrentInfo;
        }


        /// <summary>
        /// 完成作业.
        /// </summary>
        /// <param name="cmd"></param>
        public void FinishJob(ElevatorCommand cmd)
        {
            if (cmd.StopAtFloorNum == this.FloorNo)
            {
                // 如果 命令代码  与 楼层代码相同.
                if (cmd.StopWhen == Elevator.ElevatorRunningStatus.Up)
                {
                    // 恢复按钮颜色
                    this.btnUp.BackColor = SystemColors.Control;
                }
                else if (cmd.StopWhen == Elevator.ElevatorRunningStatus.Down)
                {
                    // 恢复按钮颜色
                    this.btnDown.BackColor = SystemColors.Control;
                }
            }
        }




        #region 事件.

        /// <summary>
        /// 向上.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            btnUp.BackColor = Color.Orange;
            this.Refresh();

            // 外部命令.
            CommandOutside cmd = new CommandOutside() {
                // 本楼层按的按钮.
                FromFloorNum = this.FloorNo,
                // 方向：向上
                CommandType  = CommandOutside.CommandOutsideType.Up,
            };
            this.myElevatorManager.AddNewOutsideCommand(cmd);
        }


        /// <summary>
        /// 向下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            btnDown.BackColor = Color.Orange;
            this.Refresh();


            // 外部命令.
            CommandOutside cmd = new CommandOutside()
            {
                // 本楼层按的按钮.
                FromFloorNum = this.FloorNo,
                // 方向：向下
                CommandType = CommandOutside.CommandOutsideType.Down,
            };
            this.myElevatorManager.AddNewOutsideCommand(cmd);
        }

        #endregion 事件.
    }
}
