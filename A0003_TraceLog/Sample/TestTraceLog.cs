using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;

namespace A0003_TraceLog.Sample
{


    /// <summary>
    /// 
    /// Trace 类用于 跟踪代码的执行。
    /// 
    /// 
    /// Trace.WriteLine 等方法 与 Debug.WriteLine 等方法的区别在于：
    /// 
    /// 
    /// Debug.WriteLine 等方法， 
    ///     在 Debug 模式下，是编译到目标可执行代码中的。
    ///     在 Release 模式下，是不编译到目标可执行代码中的。
    /// 
    /// 
    /// 而 Trace.WriteLine 等方法
    ///     在 Release 模式下，是编译到目标可执行代码中的。
    ///     
    /// 
    /// 如果在 Release 模式下， 输出了过多的 调试信息， 可能会影响程序的性能。
    /// 但是某些 Bug， 可能在 Debug 模式下不会发生， 只在 Release 模式下才会出现。
    /// 
    /// 这种情况下，需要依赖 Trace.WriteLine 等方法， 来检测 实际程序执行过程中，某些细节方面的信息。
    /// 
    /// 
    /// 通过在 app.config 文件中，修改配置信息.
    /// 可以根据需要， 打开/关闭 跟踪信息的处理
    /// 
    /// 
    /// </summary>
    public class TestTraceLog
    {

        /// <summary>
        /// 跟踪开关。 
        /// 
        /// 配置信息被定义在 app.config 中.
        /// </summary>
        private BooleanSwitch dataSwitch;


        /// <summary>
        /// 跟踪开关。 
        /// 
        /// 配置信息被定义在 app.config 中.
        /// </summary>
        private TraceSwitch appSwitch;



        /// <summary>
        /// 构造函数.
        /// </summary>
        public TestTraceLog()
        {

            // BooleanSwitch 类型的开关， 只有 一个 Enabled 的 开关定义.
            // 构造 跟踪开关.
            dataSwitch = new BooleanSwitch("DataMessagesSwitch", "开关定义在配置文件中...");

            Console.WriteLine("当前 BooleanSwitch 开关配置：");
            Console.WriteLine("  Enabled: {0}", dataSwitch.Enabled);
            Console.WriteLine();


            // TraceSwitch 类型的开关， 有 Error、Warning、Info、Verbose 四个层次的 开关定义.
            // 构造 跟踪开关.
            appSwitch = new TraceSwitch("TraceLevelSwitch", "开关定义在配置文件中...");

            Console.WriteLine("当前 TraceSwitch 开关配置：");
            Console.WriteLine("  TraceError：{0}", appSwitch.TraceError);
            Console.WriteLine("  TraceWarning：{0}", appSwitch.TraceWarning);
            Console.WriteLine("  TraceInfo：{0}", appSwitch.TraceInfo);
            Console.WriteLine("  TraceVerbose：{0}", appSwitch.TraceVerbose);

        }




        /// <summary>
        /// 购买物品
        /// </summary>
        /// <param name="itemID"> 物品ID </param>
        /// <param name="count"> 数量 </param>
        public void BuyItem(int itemID, int count)
        {

            if (dataSwitch.Enabled)
            {
                Trace.WriteLine(String.Format("调用 BuyItem ({0}, {1})方法开始！", itemID, count));
                Trace.WriteLineIf(itemID <= 0, "传入的参数可能无效，物品ID需要为大于零的数据！");
                Trace.WriteLineIf(count <= 0, "传入的参数可能无效，物品数量需要为大于零的数据！");
            }



            if (appSwitch.TraceError)
            {
                Trace.TraceError("1.错误:  我是一段 跟踪日志...... ");
            }

            if (appSwitch.TraceWarning)
            {
                Trace.TraceWarning("2.警告:  我是一段 跟踪日志...... ");
            }

            if (appSwitch.TraceInfo)
            {
                Trace.TraceInformation("3.信息:  我是一段 跟踪日志...... ");
            }




            // 前面的基本参数检查以后，
            // 后面为 实际的执行业务逻辑的代码.


            Console.WriteLine("购买了{0}个{1}", count, itemID);
            Console.WriteLine();



            // Flush the output.
            Trace.Flush();



        }


    }



}
