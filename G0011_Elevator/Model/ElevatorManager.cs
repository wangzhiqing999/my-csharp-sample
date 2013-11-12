using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


using log4net;


namespace G0011_Elevator.Model
{

    /// <summary>
    /// 电梯的管理.
    /// </summary>
    public class ElevatorManager
    {


        /// <summary>
        /// 日志处理类.
        /// </summary>
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// 初始化一个 电梯数据.
        /// </summary>
        public Elevator myElevator = new Elevator(6, 1);



        /// <summary>
        /// 用于 锁定 生产 / 消费 的数据队列 的对象.
        /// </summary>
        //static object locker = new object();


        /// <summary>
        /// 电梯运行处理代码.
        /// </summary>
        public void ElevatorRunning()
        {

            if (logger.IsInfoEnabled)
            {
                logger.Info("电梯开始运行！！！");
            }



            while (true)
            {

                // 当电梯处于 并且没有任何命令的情况下.
                if (myElevator.IsReady)
                {

                    if (logger.IsInfoEnabled)
                    {
                        logger.Info("电梯开始休眠！！！");
                    }

                    // 电梯处于 待机状态.
                    // 等待通知.           
                    Thread.Sleep(1000);
                    continue;
                }


                // 如果电梯不处于 待机模式
                // 完成它该做的事情.
                myElevator.DoJob();   
            }
        }



        /// <summary>
        /// 启动多线程处理.
        /// </summary>
        public void StartUp()
        {
            Thread t1 = new Thread(ElevatorRunning);
            t1.Start();
        }






        /// <summary>
        /// 楼层上面 按了 上/下的按钮.
        /// </summary>
        /// <param name="cmd"></param>
        public void AddNewOutsideCommand(CommandOutside cmd)
        {
            this.myElevator.AddNewOutsideCommand(cmd);
        }


        /// <summary>
        /// 电梯内部 按了指定楼层的按钮.
        /// </summary>
        /// <param name="cmd"></param>
        public void AddNewInsideCommand(CommandInside cmd)
        {
            this.myElevator.AddNewInsideCommand(cmd);
        }

    }
}
