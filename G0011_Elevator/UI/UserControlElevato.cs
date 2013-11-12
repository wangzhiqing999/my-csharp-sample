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
    public partial class UserControlElevato : UserControl
    {
        public UserControlElevato()
        {
            InitializeComponent();

            buttonArray[0] = this.btnGoto1;
            buttonArray[1] = this.btnGoto2;
            buttonArray[2] = this.btnGoto3;
            buttonArray[3] = this.btnGoto4;
            buttonArray[4] = this.btnGoto5;
            buttonArray[5] = this.btnGoto6;
        }


        private Button[] buttonArray = new Button[6];


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
        /// 状态变更.
        /// </summary>
        /// <param name="elevator"></param>
        public void StatusChange(Elevator elevator)
        {
            this.lblCurrentFloor.Text = elevator.CurrentInfo;
        }


        /// <summary>
        /// 开门
        /// </summary>
        public void OpenDoor()
        {
            this.lblDoorInfo.Text = "开  门";
            this.lblDoorInfo.BackColor = Color.Orange;
            this.Refresh();
        }


        /// <summary>
        /// 关门.
        /// </summary>
        public void CloseDoor()
        {
            this.lblDoorInfo.Text = "关  门";
            this.lblDoorInfo.BackColor = Color.Transparent;
            this.Refresh();
        }



        /// <summary>
        /// 完成作业.
        /// </summary>
        /// <param name="cmd"></param>
        public void FinishJob(ElevatorCommand cmd)
        {
            buttonArray[cmd.StopAtFloorNum - 1].BackColor = SystemColors.Control;
        }




        /// <summary>
        /// 楼层按钮事件处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoto1_Click(object sender, EventArgs e)
        {
            // 取得按钮对象.
            Button btn = sender as Button;

            btn.BackColor = Color.Orange ;

            // 取得按钮上的数字.
            int gotoNum = Convert.ToInt32(btn.Text);

            // 构造命令
            CommandInside cmd = new CommandInside()
            {
                // 前往指定楼层.
                CommandType = CommandInside.CommandInsideType.Goto,
                GotoFloorNum = gotoNum
            };

            // 加入内部命令.
            this.myElevatorManager.AddNewInsideCommand(cmd);
        }





    }
}
