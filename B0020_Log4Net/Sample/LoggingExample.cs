using System;


namespace B0020_Log4Net.Sample
{

	/// <summary>
	/// log4net 例子.
	/// </summary>
	public class LoggingExample
	{
        /// <summary>
        /// log实例.
        /// </summary>
        private static log4net.ILog log = log4net.LogManager.GetLogger("LoggingExample");


		/// <summary>
		/// 测试 Log.
		/// </summary>
		public void TestLog()
		{
            // 测试 INFO 级别的 LOG.
            if (log.IsInfoEnabled)
            {
                log.Info("这个是一个 INFO 级别的日志: 测试开始！");
            }

            // 测试 DEBUG 级别的 LOG
            if (log.IsDebugEnabled)
            {
                log.Debug("这个是一个 DEBUG 级别的日志.");            
            }


            // 测试 WARN 级别的 LOG
            log.Warn("这个是一个 WARN 级别的日志.");


            // 测试 ERROR 级别的 LOG
			try
			{
                MainFunc();
			}
			catch(Exception ex)
			{
				// 发生了异常.
                log.Error("这个是一个 ERROR 级别的日志，发生了异常！", ex);
			}


            // 测试 INFO 级别的 LOG.
            if (log.IsInfoEnabled)
            {
                log.Info("这个是一个 INFO 级别的日志: 测试结束！");
            }

			Console.Write("按任意键退出...");
			Console.ReadLine();
		}


		
        /// <summary>
        /// 主方法.
        /// </summary>
		private void MainFunc()
		{
            SubFunc();
		}

        /// <summary>
        /// 子方法.
        /// </summary>
        private void SubFunc()
        {
            try
            {
                DBAccess();
            }
            catch (Exception ex)
            {
                throw new ArithmeticException("在调用 DBAccess 过程中发生了异常。", ex);
            }
        }

        /// <summary>
        /// 假设这里是数据库访问.
        /// </summary>
		private void DBAccess()
		{
            throw new Exception("DBAccess 发生了异常！");
		}

		
	}
}
