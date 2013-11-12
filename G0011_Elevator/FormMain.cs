using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using G0011_Elevator.Model;
using G0011_Elevator.UI;



namespace G0011_Elevator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            myFloorArray[0] = this.ucFloor1;
            myFloorArray[1] = this.ucFloor2;
            myFloorArray[2] = this.ucFloor3;
            myFloorArray[3] = this.ucFloor4;
            myFloorArray[4] = this.ucFloor5;
            myFloorArray[5] = this.ucFloor6;


            // 电梯移动事件绑定.
            manager.myElevator.ElevatorMove += new ElevatorMoveHandler(my_ElevatorMove);
            manager.myElevator.ElevatorOpen += new ElevatorOpenHandler(my_ElevatorOpen);
            manager.myElevator.ElevatorClose += new ElevatorCloseHandler(my_ElevatorClose);
            manager.myElevator.ElevatorJobFinish += new ElevatorJobFinishHandler(my_ElevatorJobFinish);
        }



        /// <summary>
        /// 6层楼.
        /// </summary>
        private UserControlFloor[] myFloorArray = new UserControlFloor[6];



        /// <summary>
        /// 电梯管理类.
        /// </summary>
        private ElevatorManager manager = new ElevatorManager();


        /// <summary>
        /// 多线程处理.
        /// </summary>
        Thread mytElevator;


        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {

            // 设置楼层属性.
            for (int i = 0; i < myFloorArray.Length; i++)
            {
                // 楼层代码.
                myFloorArray[i].FloorNo = i + 1;

                // 底楼.
                if (i == 0)
                {
                    myFloorArray[i].IsBottomFloor = true;
                }

                // 顶楼.
                if (i == myFloorArray.Length - 1)
                {
                    myFloorArray[i].IsTopFloor = true;
                }

                // 电梯管理类.
                myFloorArray[i].SetElevatorManager(manager);

                // 初始化.
                myFloorArray[i].InitFloor();

                // 填充效果.
                myFloorArray[i].Dock = DockStyle.Fill;
            }


            // 设置电梯属性.
            this.ucElevato.SetElevatorManager(manager);



            // 启动多线程处理.
            mytElevator  = new Thread(manager.ElevatorRunning);            
            mytElevator.Start();                       
        }



        /// <summary>
        /// 关闭.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 结束多线程处理.
            mytElevator.Abort();
        }





        #region 相关事件处理.


        /// <summary>
        /// 电梯移动事件
        /// </summary>
        /// <param name="fromFloor"></param>
        /// <param name="toFloor"></param>
        private void my_ElevatorMove(int fromFloor, int toFloor)
        {
            Invoke(new Action(() =>
            {
                for (int i = 0; i < myFloorArray.Length; i++)
                {
                    myFloorArray[i].StatusChange(manager.myElevator);
                }

                ucElevato.StatusChange(manager.myElevator);


                this.Refresh();

            }));

            // 模拟延迟 3秒.
            Thread.Sleep(3000);

        }


        /// <summary>
        /// 开门.
        /// </summary>
        /// <param name="openFloor"></param>
        private void my_ElevatorOpen(int openFloor)
        {
            Invoke(new Action(() =>
           {
               ucElevato.OpenDoor();

               this.Refresh();
           }));

            // 模拟延迟 2秒.
            Thread.Sleep(2000);



        }



        /// <summary>
        /// 关门.
        /// </summary>
        /// <param name="openFloor"></param>
        private void my_ElevatorClose(int closeFloor)
        {
            Invoke(new Action(() =>
          {
              ucElevato.CloseDoor();

              this.Refresh();

          }));

        }


        /// <summary>
        /// 任务完成事件.
        /// </summary>
        /// <param name="cmd"></param>
        private void my_ElevatorJobFinish(ElevatorCommand cmd)
        {
            Invoke(new Action(() =>
          {
              for (int i = 0; i < myFloorArray.Length; i++)
              {
                  myFloorArray[i].FinishJob(cmd);
              }

              ucElevato.FinishJob(cmd);


              this.Refresh();

          }));

            // 模拟延迟 1秒.
            Thread.Sleep(1000);
        }


        #endregion







    }
}
