using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;

using System.Threading;



namespace A0331_ThreadAsyncInvoke_EAP.Sample
{



    // 实现支持基于事件的异步模式的组件
    // 参考网页:
    // https://msdn.microsoft.com/zh-cn/library/bz33kx67(v=vs.110).aspx
    // 



    /// <summary>
    /// 质数计算进度的委托.
    /// </summary>
    /// <param name="e"></param>
    public delegate void ProgressChangedEventHandler(ProgressChangedEventArgs e);


    /// <summary>
    /// 质数计算完成的委托.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void CalculatePrimeCompletedEventHandler(object sender,CalculatePrimeCompletedEventArgs e);




    /// <summary>
    /// 质数计算完成的参数.
    /// </summary>
    public class CalculatePrimeCompletedEventArgs :
        AsyncCompletedEventArgs
    {

        /// <summary>
        /// 测试的数值.
        /// </summary>
        private int numberToTestValue = 0;

        /// <summary>
        /// 如果不是质数，它的第一个约数是什么
        /// </summary>
        private int firstDivisorValue = 1;

        /// <summary>
        /// 是否是质数.
        /// </summary>
        private bool isPrimeValue;



        public CalculatePrimeCompletedEventArgs(
            int numberToTest,
            int firstDivisor,
            bool isPrime,
            Exception e,
            bool canceled,
            object state)
            : base(e, canceled, state)
        {
            this.numberToTestValue = numberToTest;
            this.firstDivisorValue = firstDivisor;
            this.isPrimeValue = isPrime;
        }

        public int NumberToTest
        {
            get
            {
                // Raise an exception if the operation failed or 
                // was canceled.
                RaiseExceptionIfNecessary();

                // If the operation was successful, return the 
                // property value.
                return numberToTestValue;
            }
        }

        public int FirstDivisor
        {
            get
            {
                // Raise an exception if the operation failed or 
                // was canceled.
                RaiseExceptionIfNecessary();

                // If the operation was successful, return the 
                // property value.
                return firstDivisorValue;
            }
        }

        public bool IsPrime
        {
            get
            {
                // Raise an exception if the operation failed or 
                // was canceled.
                RaiseExceptionIfNecessary();

                // If the operation was successful, return the 
                // property value.
                return isPrimeValue;
            }
        }
    }


    /// <summary>
    /// 质数计算参数.
    /// </summary>
    public class CalculatePrimeProgressChangedEventArgs :
        ProgressChangedEventArgs
    {
        private int latestPrimeNumberValue = 1;

        public CalculatePrimeProgressChangedEventArgs(
            int latestPrime,
            int progressPercentage,
            object userToken)
            : base(progressPercentage, userToken)
        {
            this.latestPrimeNumberValue = latestPrime;
        }

        public int LatestPrimeNumber
        {
            get
            {
                return latestPrimeNumberValue;
            }
        }
    }



    /// <summary>
    /// 质数计算器类.
    /// </summary>
    public class PrimeNumberCalculator
    {

        /// <summary>
        /// 质数计算进度的委托.
        /// </summary>
        public event ProgressChangedEventHandler ProgressChanged;


        /// <summary>
        /// 质数计算完成的委托.
        /// </summary>
        public event CalculatePrimeCompletedEventHandler CalculatePrimeCompleted;



        /// <summary>
        /// 构造函数.
        /// </summary>
        public PrimeNumberCalculator()
        {

            // 初始化委托
            InitializeDelegates();
        }




        #region 定义私有的委托.


        /// <summary>
        /// 委托：用于向客户端报告进程
        /// </summary>
        private SendOrPostCallback onProgressReportDelegate;


        /// <summary>
        /// 委托：用于向客户端报告完成。
        /// </summary>
        private SendOrPostCallback onCompletedDelegate;


        /// <summary>
        /// 初始化委托.
        /// </summary>
        protected virtual void InitializeDelegates()
        {
            onProgressReportDelegate = new SendOrPostCallback(ReportProgress);

            onCompletedDelegate = new SendOrPostCallback(CalculateCompleted);
        }



        /// <summary>
        /// 声明 PrimeNumberCalculator 类中的一个委托，该类用于处理要异步完成的实际工作。 
        /// 此委托将包装用于测试一个数是否是质数的辅助方法。 
        /// 此委托采用 AsyncOperation 参数，用于跟踪异步操作的生存期。
        /// </summary>
        /// <param name="numberToCheck"></param>
        /// <param name="asyncOp"></param>
        private delegate void WorkerEventHandler(int numberToCheck, AsyncOperation asyncOp);




        /// <summary>
        /// 创建一个集合，用来管理挂起的异步操作的生存期。 
        /// 客户端需要一种方式来跟踪操作的执行和完成情况，此跟踪的实现需要客户端在调用异步方法时传递一个唯一标记或任务 ID。 
        /// PrimeNumberCalculator 组件必须通过将任务 ID 与其对应的调用关联起来以跟踪每个调用。 
        /// 如果客户端传递的任务 ID 不是唯一的，则 PrimeNumberCalculator 组件必须引发一个异常。
        /// </summary>
        private HybridDictionary userStateToLifetime = new HybridDictionary();




        #endregion 定义私有的委托.






        #region 实现公共事件.


        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void CalculateCompleted(object operationState)
        {
            CalculatePrimeCompletedEventArgs e = operationState as CalculatePrimeCompletedEventArgs;
            OnCalculatePrimeCompleted(e);
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void ReportProgress(object state)
        {
            ProgressChangedEventArgs e = state as ProgressChangedEventArgs;
            OnProgressChanged(e);
        }



        protected void OnCalculatePrimeCompleted(CalculatePrimeCompletedEventArgs e)
        {
            if (CalculatePrimeCompleted != null)
            {
                CalculatePrimeCompleted(this, e);
            }
        }

        protected void OnProgressChanged(ProgressChangedEventArgs e)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(e);
            }
        }


        #endregion 实现公共事件.





        #region 实现完成方法.


        // This is the method that the underlying, free-threaded 
        // asynchronous behavior will invoke.  This will happen on
        // an arbitrary thread.
        /// <summary>
        /// 实现完成方法。 它采用六个参数；
        /// 在通过客户端的 CalculatePrimeCompletedEventHandler 返回客户端的 CalculatePrimeCompletedEventArgs 中填充的就是这些参数。 它将客户端的任务 ID 标记从内部集合中移除，然后调用 PostOperationCompleted 结束异步操作的生存期。 
        /// AsyncOperation 会将此调用封送到适合于应用程序模型的线程或上下文。
        /// </summary>
        /// <param name="numberToTest"></param>
        /// <param name="firstDivisor"></param>
        /// <param name="isPrime"></param>
        /// <param name="exception"></param>
        /// <param name="canceled"></param>
        /// <param name="asyncOp"></param>
        private void CompletionMethod(
            int numberToTest,
            int firstDivisor,
            bool isPrime,
            Exception exception,
            bool canceled,
            AsyncOperation asyncOp)
        {
            // If the task was not previously canceled,
            // remove the task from the lifetime collection.
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            // Package the results of the operation in a 
            // CalculatePrimeCompletedEventArgs.
            CalculatePrimeCompletedEventArgs e =
                new CalculatePrimeCompletedEventArgs(
                numberToTest,
                firstDivisor,
                isPrime,
                exception,
                canceled,
                asyncOp.UserSuppliedState);

            // End the task. The asyncOp object is responsible 
            // for marshaling the call.
            asyncOp.PostOperationCompleted(onCompletedDelegate, e);

            // Note that after the call to OperationCompleted, 
            // asyncOp is no longer usable, and any attempt to use it
            // will cause an exception to be thrown.
        }




        #endregion 实现完成方法.







        #region 实现辅助方法.




        // Utility method for determining if a 
        // task has been canceled.

        /// <summary>
        /// 实现 TaskCanceled 实用工具方法。 它会检查任务生存期集合中是否存在给定任务 ID，如果没有找到该任务 ID，则返回 true。
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        private bool TaskCanceled(object taskId)
        {
            return (userStateToLifetime[taskId] == null);
        }




        // This method performs the actual prime number computation.
        // It is executed on the worker thread.

        /// <summary>
        /// 实现 CalculateWorker 方法。 它采用两个参数：一个是要测试的数，一个是 AsyncOperation。
        /// </summary>
        /// <param name="numberToTest"></param>
        /// <param name="asyncOp"></param>
        private void CalculateWorker(
            int numberToTest,
            AsyncOperation asyncOp)
        {
            bool isPrime = false;
            int firstDivisor = 1;
            Exception e = null;

            // Check that the task is still active.
            // The operation may have been canceled before
            // the thread was scheduled.
            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    // Find all the prime numbers up to 
                    // the square root of numberToTest.
                    ArrayList primes = BuildPrimeNumberList(
                        numberToTest,
                        asyncOp);

                    // Now we have a list of primes less than
                    // numberToTest.
                    isPrime = IsPrime(
                        primes,
                        numberToTest,
                        out firstDivisor);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            //CalculatePrimeState calcState = new CalculatePrimeState(
            //        numberToTest,
            //        firstDivisor,
            //        isPrime,
            //        e,
            //        TaskCanceled(asyncOp.UserSuppliedState),
            //        asyncOp);

            //this.CompletionMethod(calcState);

            this.CompletionMethod(
                numberToTest,
                firstDivisor,
                isPrime,
                e,
                TaskCanceled(asyncOp.UserSuppliedState),
                asyncOp);

            //completionMethodDelegate(calcState);
        }



        // This method computes the list of prime numbers used by the
        // IsPrime method.

        /// <summary>
        /// 返回 质数的列表.
        /// </summary>
        /// <param name="numberToTest"></param>
        /// <param name="asyncOp"></param>
        /// <returns></returns>
        private ArrayList BuildPrimeNumberList(
            int numberToTest,
            AsyncOperation asyncOp)
        {
            ProgressChangedEventArgs e = null;
            ArrayList primes = new ArrayList();
            int firstDivisor;
            int n = 5;

            // Add the first prime numbers.
            primes.Add(2);
            primes.Add(3);


            // Do the work.
            // 每次循环，都调用 TaskCanceled 方法，当该方法返回 true 时它就会退出。
            while (n < numberToTest &&
                   !TaskCanceled(asyncOp.UserSuppliedState))
            {

                if (IsPrime(primes, n, out firstDivisor))
                {
                    // Report to the client that a prime was found.
                    e = new CalculatePrimeProgressChangedEventArgs(
                        n,
                        (int)((float)n / (float)numberToTest * 100),
                        asyncOp.UserSuppliedState);

                    asyncOp.Post(this.onProgressReportDelegate, e);

                    primes.Add(n);

                    // Yield the rest of this time slice.
                    Thread.Sleep(0);
                }



                // Skip even numbers.
                // 这里排除掉偶数.
                n += 2;
            }

            return primes;
        }





        // This method tests n for primality against the list of 
        // prime numbers contained in the primes parameter.

        /// <summary>
        /// 实现 IsPrime。 
        /// 它采用三个参数：已知质数列表、要测试的数和找到的第一个约数的输出参数。 
        /// 根据质数列表，它确定测试数是不是质数。
        /// </summary>
        /// <param name="primes">已知质数列表</param>
        /// <param name="n">要测试的数</param>
        /// <param name="firstDivisor">第一个约数</param>
        /// <returns>测试数是不是质数</returns>
        private bool IsPrime(
            ArrayList primes,
            int n,
            out int firstDivisor)
        {
            bool foundDivisor = false;
            bool exceedsSquareRoot = false;

            int i = 0;
            int divisor = 0;
            firstDivisor = 1;

            // Stop the search if:
            // there are no more primes in the list,
            // there is a divisor of n in the list, or
            // there is a prime that is larger than 
            // the square root of n.
            while (
                (i < primes.Count) &&
                !foundDivisor &&
                !exceedsSquareRoot)
            {
                // The divisor variable will be the smallest 
                // prime number not yet tried.
                divisor = (int)primes[i++];

                // Determine whether the divisor is greater
                // than the square root of n.
                if (divisor * divisor > n)
                {
                    exceedsSquareRoot = true;
                }
                // Determine whether the divisor is a factor of n.
                else if (n % divisor == 0)
                {
                    firstDivisor = divisor;
                    foundDivisor = true;
                }
            }

            return !foundDivisor;
        }




        #endregion 实现辅助方法.









        #region 实现启动和取消功能.


        // This method starts an asynchronous calculation. 
        // First, it checks the supplied task ID for uniqueness.
        // If taskId is unique, it creates a new WorkerEventHandler 
        // and calls its BeginInvoke method to start the calculation.
        public virtual void CalculatePrimeAsync(
            int numberToTest,
            object taskId)
        {
            // Create an AsyncOperation for taskId.
            AsyncOperation asyncOp =
                AsyncOperationManager.CreateOperation(taskId);

            // Multiple threads will access the task dictionary,
            // so it must be locked to serialize access.
            lock (userStateToLifetime.SyncRoot)
            {
                if (userStateToLifetime.Contains(taskId))
                {
                    throw new ArgumentException(
                        "Task ID parameter must be unique",
                        "taskId");
                }

                userStateToLifetime[taskId] = asyncOp;
            }

            // Start the asynchronous operation.
            WorkerEventHandler workerDelegate = new WorkerEventHandler(CalculateWorker);
            workerDelegate.BeginInvoke(
                numberToTest,
                asyncOp,
                null,
                null);
        }



        // This method cancels a pending asynchronous operation.
        public void CancelAsync(object taskId)
        {
            AsyncOperation asyncOp = userStateToLifetime[taskId] as AsyncOperation;
            if (asyncOp != null)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(taskId);
                }
            }
        }




        #endregion 实现启动和取消功能.


    }


}
