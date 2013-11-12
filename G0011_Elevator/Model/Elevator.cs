using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using log4net;


namespace G0011_Elevator.Model
{


    /// <summary>
    /// 电梯移动事件.
    /// </summary>
    /// <param name="fromFloor"> 从哪个楼层 </param>
    /// <param name="toFloor"> 移动到哪个楼层 </param>
    public delegate void ElevatorMoveHandler(int fromFloor, int toFloor);


    /// <summary>
    /// 电梯开门事件.
    /// </summary>
    /// <param name="openFloor"></param>
    public delegate void ElevatorOpenHandler(int openFloor);


    /// <summary>
    /// 电梯关门事件.
    /// </summary>
    /// <param name="openFloor"></param>
    public delegate void ElevatorCloseHandler(int closeFloor);


    /// <summary>
    /// 任务完成事件.
    /// </summary>
    /// <param name="cmd"></param>
    public delegate void ElevatorJobFinishHandler(ElevatorCommand cmd);


    /// <summary>
    /// 电梯
    /// </summary>
    public class Elevator
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        #region 基本事件定义.

        /// <summary>
        /// 电梯移动事件
        /// </summary>
        public event ElevatorMoveHandler ElevatorMove;


        /// <summary>
        /// 电梯开门.
        /// </summary>
        public event ElevatorOpenHandler ElevatorOpen;


        /// <summary>
        /// 电梯关门.
        /// </summary>
        public event ElevatorCloseHandler ElevatorClose;


        /// <summary>
        /// 任务完成.
        /// </summary>
        public event ElevatorJobFinishHandler ElevatorJobFinish;

        #endregion 基本事件定义.




        /// <summary>
        /// 状态值的枚举.
        /// </summary>
        public enum ElevatorRunningStatus
        {
            /// <summary>
            /// 待机状态.
            /// </summary>
            Ready,


            /// <summary>
            /// 移动向上.
            /// </summary>
            Up,


            /// <summary>
            /// 移动
            /// </summary>
            Down,
        }




        #region 基本属性.


        /// <summary>
        /// 最高楼层.
        /// </summary>
        public int MaxFloor { set; get; }


        /// <summary>
        /// 最低楼层.
        /// </summary>
        public int MinFloor { set; get; }


        /// <summary>
        /// 当前楼层.
        /// </summary>
        public int CurrentFloor { set; get; }




        /// <summary>
        /// 电梯的状态.
        /// </summary>
        public ElevatorStatus Status { set; get; }



        /// <summary>
        /// 电梯运行的状态.
        /// </summary>
        public ElevatorRunningStatus RunningStatus { private set; get; }



        /// <summary>
        /// 需要移动到的楼层列表.
        /// </summary>
        private List<ElevatorCommand> todoList = new List<ElevatorCommand>();


        #endregion







        /// <summary>
        /// 构造函数.
        /// </summary>
        public Elevator(int maxFloor,  int minFloor)
        {
            // 设置最高、最低楼层.
            MaxFloor = maxFloor;
            MinFloor = minFloor;

            // 默认状态 = 待机.
            RunningStatus = ElevatorRunningStatus.Ready;


            // 初始情况下， 电梯处于  底楼状态.
            Status = new ElevatorStatusIsBottom()
            {
                 ElevatorData = this,
            };
        }




        /// <summary>
        /// 向上.
        /// </summary>
        private void Up()
        {
            bool result = this.Status.Up();

            // 如果定义了事件，那么触发该事件.
            if (result && ElevatorMove != null)
            {
                ElevatorMove(CurrentFloor - 1, CurrentFloor);
            }

            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("电梯正在由{0}层， 上升到{1}层！", CurrentFloor - 1, CurrentFloor);
            }
        }


        /// <summary>
        /// 向下.
        /// </summary>
        private void Down()
        {
            bool result = this.Status.Down();

            // 如果定义了事件，那么触发该事件.
            if (result && ElevatorMove != null)
            {
                ElevatorMove(CurrentFloor + 1, CurrentFloor);
            }

            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("电梯正在由{0}层， 下降到{1}层！", CurrentFloor + 1, CurrentFloor);
            }

        }




        /// <summary>
        /// 是否处于  待机状态.
        /// </summary>
        public bool IsReady
        {
            get
            {
                return this.RunningStatus == ElevatorRunningStatus.Ready;
            }
        }



        /// <summary>
        /// 当前信息.
        /// </summary>
        public string CurrentInfo
        {
            get
            {
                return String.Format("{0} {1}", this.CurrentFloor, this.RunningStatus);
            }
        
        }





        #region 外部作业处理.


        /// <summary>
        /// 添加一个 内部的命令.
        /// </summary>
        /// <param name="cmd"></param>
        public void AddNewInsideCommand(CommandInside cmd)
        {

            if (logger.IsInfoEnabled)
            {
                logger.InfoFormat("电梯内部的人，按了一个前往{0}层的按钮！", cmd.GotoFloorNum);
            }


            if (cmd.CommandType == CommandInside.CommandInsideType.Goto)
            {
                // 如果内部命令是 “前往指定的楼层”
                // 那么判断， 该楼层是否已经在列表中了.
                var query =
                    from data in todoList
                    where data.StopAtFloorNum == cmd.GotoFloorNum
                    select data;

                if (query.Count() == 0)
                {
                    // 楼层在 todolist 中不存在，需要加入到列表中.

                    // 判断 目标楼层 与 当前楼层之间的 区间。
                    // 从而设置 向上停 或者 向下停.
                    if (this.CurrentFloor > cmd.GotoFloorNum)
                    {
                        // 当前楼层比 目标楼层高.
                        // 需要向下的时候， 停电梯.
                        todoList.Add(new ElevatorCommand()
                        {
                            StopWhen = ElevatorRunningStatus.Down,
                            StopAtFloorNum = cmd.GotoFloorNum
                        });
                    }
                    else if (this.CurrentFloor < cmd.GotoFloorNum)
                    {
                        // 当前楼层比 目标楼层低.
                        // 需要向上的时候， 停电梯.
                        todoList.Add(new ElevatorCommand()
                        {
                            StopWhen = ElevatorRunningStatus.Down,
                            StopAtFloorNum = cmd.GotoFloorNum
                        });
                    }
                    else
                    {
                        // 这个也太着急了， 有急刹车的趋势啊.
                        todoList.Add(new ElevatorCommand()
                        {
                            StopWhen = this.RunningStatus,
                            StopAtFloorNum = cmd.GotoFloorNum
                        });
                    }
                }
            }


            // 基本状态切换.
            SwitchRunningStatus();
        }



        /// <summary>
        /// 添加一个 外部的命令.
        /// </summary>
        /// <param name="cmd"></param>
        public void AddNewOutsideCommand(CommandOutside cmd)
        {
            if (logger.IsInfoEnabled )
            {
                logger.InfoFormat ("电梯外部的人，在{0}层，按了一下{1}的按钮！", cmd.FromFloorNum,  cmd.CommandType);
            }


            // 如果外部命令是 “前往指定的楼层”
            // 那么判断， 该楼层是否已经在列表中了.
            var query =
                from data in todoList
                where data.StopAtFloorNum == cmd.FromFloorNum
                select data;

            if (cmd.CommandType == CommandOutside.CommandOutsideType.Up)
            {
                // 指定楼层上面，按了 向上按钮.
                query = query.Where(p => p.StopWhen == ElevatorRunningStatus.Up);
            }
            else
            {
                // 指定楼层上面，按了 向下按钮.
                query = query.Where(p => p.StopWhen == ElevatorRunningStatus.Down);
            }

            if (query.Count() == 0)
            {
                // todoList 数据列表中没有数据. 
                // 那么 新增命令.

                // 停在哪层楼
                ElevatorCommand newCmd = new ElevatorCommand()
                {
                    StopAtFloorNum = cmd.FromFloorNum,
                };


                // 向上停？ 向下停？
                if (cmd.CommandType == CommandOutside.CommandOutsideType.Up)
                {
                    newCmd.StopWhen = ElevatorRunningStatus.Up;
                }
                else
                {
                    newCmd.StopWhen = ElevatorRunningStatus.Down;
                }

                // 加入列表.
                todoList.Add(newCmd);
            }

            // 基本状态切换.
            SwitchRunningStatus();
        }




        /// <summary>
        /// 完成业务处理.
        /// </summary>
        public void DoJob()
        {


            if (logger.IsInfoEnabled)
            {
                logger.Info("DoJob -- 电梯开始完成 todoList 中的任务！！！");
            }


            // 基本状态切换.
            SwitchRunningStatus();

            if (todoList.Count() == 0 && this.RunningStatus != ElevatorRunningStatus.Ready)
            {
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("没有待完成任务，即将迁移到底层，进入待机状态... 目前楼层:{0}", this.CurrentFloor);
                }

                // 如果没有 待完成任务.
                // 那么迁移到底层，进入待机状态.
                if (this.CurrentFloor > this.MinFloor)
                {
                    // 如果不是底层.
                    // 向下移动.
                    this.Down();
                }
                return;
            }

            
            // 如果有 待完成任务.
            // 根据 电梯当前位置、状态。 判断如何处理.

            // 当前状态为 正在向上.
            if (this.RunningStatus == ElevatorRunningStatus.Up)
            {
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("当前状态为 正在向上！目前楼层:{0}", this.CurrentFloor);
                }

                //  电梯正在向上运行.
                // 获取下一行命令.
                ElevatorCommand nextCmd = this.GetNearestCommand(ElevatorRunningStatus.Up);
                if (nextCmd.StopAtFloorNum > this.CurrentFloor)
                {
                    // 下一个目标还没有到.
                    this.Up();
                    // 结束本单元判断处理.
                    return;
                }
                // 完成一个命令.
                FinishOneCommand(nextCmd);
                return;
            }


            // 当前状态为 正在向下.
            if (this.RunningStatus == ElevatorRunningStatus.Down)
            {
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("当前状态为 正在向下！目前楼层:{0}", this.CurrentFloor);
                }

                //  电梯正在向下运行.

                // 获取下一行命令.
                ElevatorCommand nextCmd = this.GetNearestCommand(ElevatorRunningStatus.Down);
                if (nextCmd.StopAtFloorNum < this.CurrentFloor)
                {
                    // 下一个目标还没有到.
                    this.Down();
                    // 结束本单元判断处理.
                    return;
                }
                // 完成一个命令.
                FinishOneCommand(nextCmd);
                return;
            }
        }




        /// <summary>
        /// 根据当前的 todoList .
        /// 切换运行状态.
        /// </summary>
        private void SwitchRunningStatus()
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("SwitchRunningStatus -- 开始执行状态切换的处理！");
            }


            if (todoList.Count() == 0 )
            {

                if (this.CurrentFloor == this.MinFloor)
                {
                    if (logger.IsDebugEnabled)
                    {
                        logger.DebugFormat("SwitchRunningStatus -- 没事情可以做， 并且已经在底楼， 切换状态为待机.！");
                    }

                    // 如果没事情可以做， 并且已经在底楼， 切换状态为待机.
                    this.RunningStatus = ElevatorRunningStatus.Ready;

                    // 触发一下状态变更事件.
                    if (this.ElevatorMove != null)
                    {
                        ElevatorMove(this.MinFloor, this.MinFloor);
                    }
                }
                else
                {
                    if (logger.IsDebugEnabled)
                    {
                        logger.DebugFormat("SwitchRunningStatus -- 没事情可以做， 正在缓慢向底楼移动！");
                    }

                    this.RunningStatus = ElevatorRunningStatus.Down;
                }

                
                return;
            }


            if (this.RunningStatus == ElevatorRunningStatus.Ready)
            {
                // 电梯处于待机状态， 并且有事情需要做的情况下，切换为向上的状态.
                this.RunningStatus = ElevatorRunningStatus.Up;

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("SwitchRunningStatus -- 电梯处于待机状态， 并且有事情需要做的情况下，切换为向上的状态.！");
                }
                return;
            }


            if (this.RunningStatus == ElevatorRunningStatus.Up
                && this.GetNearestCommand(ElevatorRunningStatus.Up) == null)
            {
                // 已经不存在向上的命令了.
                // 开始切换为向下处理.
                this.RunningStatus = ElevatorRunningStatus.Down;

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("SwitchRunningStatus -- 已经不存在向上的命令了. 开始切换为向下处理.！");
                }
                return;
            }


            if (this.RunningStatus == ElevatorRunningStatus.Down
                && this.GetNearestCommand(ElevatorRunningStatus.Down) == null)
            {
                // 已经不存在向下的命令了.
                // 开始切换为向上处理.
                this.RunningStatus = ElevatorRunningStatus.Up;

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("SwitchRunningStatus -- 已经不存在向下的命令了. 开始切换为向上处理.！");
                }
                return;
            }


        }




        /// <summary>
        /// 完成一个命令.
        /// </summary>
        /// <param name="nextCmd"></param>
        private void FinishOneCommand(ElevatorCommand nextCmd)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("FinishOneCommand -- 完成一个命令： {0}", nextCmd);
            }

            if (ElevatorJobFinish != null)
            {
                ElevatorJobFinish(nextCmd);
            }

            // 下一个目标已到达.
            // 电梯开门.
            if (ElevatorOpen != null)
            {
                ElevatorOpen(this.CurrentFloor);
            }

            // 延迟效果.
            Thread.Sleep(3000);

            // 电梯关门.
            if (ElevatorClose != null)
            {
                ElevatorClose(this.CurrentFloor);
            }

            // 本单元项目已完成处理.
            // 将其从 todoList 中删除.
            todoList.Remove(nextCmd);
        }



        /// <summary>
        /// 获取 最接近当前楼层的 一个命令.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private ElevatorCommand GetNearestCommand(ElevatorRunningStatus status)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("GetNearestCommand -- 获取最接近当前楼层的一个命令：方向= {0}", status);
            }

            if (status == ElevatorRunningStatus.Up
                || status == ElevatorRunningStatus.Ready)
            {

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("GetNearestCommand --电梯正在向上运行.查询目前还有哪些楼层， 要在向上的过程中，停下来的。");
                }

                //  电梯正在向上运行.
                // 查询目前还有哪些楼层， 要在向上的过程中，停下来的。
                var todoQuery =
                    from data in todoList
                    where
                        // 停靠楼层大于当前楼层.
                        data.StopAtFloorNum >= this.CurrentFloor
                        // 向上停靠.
                        && data.StopWhen == ElevatorRunningStatus.Up
                        // 按楼层从小到大排序.
                    orderby data.StopAtFloorNum
                    select data;

                ElevatorCommand result = todoQuery.FirstOrDefault();


                if (result == null)
                {
                    if (logger.IsDebugEnabled)
                    {
                        logger.DebugFormat("GetNearestCommand --不存在正在向上停的楼层， 要在向下楼层进行查询。");
                    }

                    todoQuery =
                        from data in todoList
                        where
                            // 停靠楼层大于当前楼层.
                            data.StopAtFloorNum >= this.CurrentFloor
                            // 向下停靠.
                            && data.StopWhen == ElevatorRunningStatus.Down
                            // 按楼层从大到小排序.
                        orderby data.StopAtFloorNum descending
                        select data;

                    // 也就是要迁移到 最上面那个  按“向下”的按钮.
                    result = todoQuery.FirstOrDefault();
                }



                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("GetNearestCommand -Up-返回结果：{0}", result);
                }

                return result;
            }

            if (status == ElevatorRunningStatus.Down)
            {
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("GetNearestCommand --电梯正在向下运行.查询目前还有哪些楼层， 要在向下的过程中，停下来的。");
                }

                //  电梯正在向下运行.
                // 查询目前还有哪些楼层， 要在向下的过程中，停下来的。
                var todoQuery =
                    from data in todoList
                    where
                        // 停靠楼层小于当前楼层.
                        data.StopAtFloorNum <= this.CurrentFloor
                        // 向下停靠.
                        && data.StopWhen == ElevatorRunningStatus.Down
                        // 按楼层从大到小排序
                    orderby data.StopAtFloorNum descending
                    select data;

                ElevatorCommand result = todoQuery.FirstOrDefault();

                if (result == null)
                {
                    if (logger.IsDebugEnabled)
                    {
                        logger.DebugFormat("GetNearestCommand --不存在正在向下停的楼层， 要在向上楼层进行查询。");
                    }

                    todoQuery =
                       from data in todoList
                       where
                            // 停靠楼层小于当前楼层.
                            data.StopAtFloorNum <= this.CurrentFloor
                            // 向上停靠.
                            && data.StopWhen == ElevatorRunningStatus.Up
                            // 按楼层从小到大排序
                       orderby data.StopAtFloorNum
                       select data;

                    // 也就是要迁移到 最下面那个  按“向上”的按钮.
                    result = todoQuery.FirstOrDefault();
                }


                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("GetNearestCommand -Down-返回结果：{0}", result);
                }

                return result;
            }

            // 其他未知状况下， 简单返回 null
            return null;
        }




        #endregion

    }

}
