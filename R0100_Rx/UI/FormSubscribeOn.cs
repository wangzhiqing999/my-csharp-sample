using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Reactive.Concurrency;

namespace R0100_Rx.UI
{
    public partial class FormSubscribeOn : Form
    {
        public FormSubscribeOn()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 获取测试的 可观察对象.
        /// </summary>
        /// <returns></returns>
        private IObservable<int> GetTestObservableSource()
        {
            IObservable<int> source = Observable.Create<int>(
                o =>
                {
                    Console.WriteLine("Invoked on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
                    o.OnNext(1);
                    Thread.Sleep(500);
                    o.OnNext(2);
                    Thread.Sleep(500);
                    o.OnNext(3);
                    Thread.Sleep(500);
                    o.OnCompleted();
                    Console.WriteLine("Finished on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
                    return Disposable.Empty;
                });

            return source;
        }

        



        /// <summary>
        /// 默认情况下，不使用 .SubscribeOn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWithoutSubscribeOn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("########## 不使用 .SubscribeOn :{0} ##########", Thread.CurrentThread.ManagedThreadId);
            var source = GetTestObservableSource();

            source.Subscribe(o => Console.WriteLine("Received {1} on threadId:{0}", Thread.CurrentThread.ManagedThreadId, o),
                () => Console.WriteLine("OnCompleted on threadId:{0}", Thread.CurrentThread.ManagedThreadId));
        }


        /// <summary>
        /// 使用 .SubscribeOn(NewThreadScheduler.Default)
        /// 在新线程中调度工作（asynchronous，no-block） 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewThreadScheduler_Click(object sender, EventArgs e)
        {
            Console.WriteLine("########## 使用 .SubscribeOn(NewThreadScheduler.Default) :{0} ##########", Thread.CurrentThread.ManagedThreadId);
            var source = GetTestObservableSource();

            source
                .SubscribeOn(NewThreadScheduler.Default)
                .Subscribe(o => Console.WriteLine("Received {1} on threadId:{0}", Thread.CurrentThread.ManagedThreadId, o),
                () => Console.WriteLine("OnCompleted on threadId:{0}", Thread.CurrentThread.ManagedThreadId));
        }


        /// <summary>
        /// 使用 .SubscribeOn(ThreadPoolScheduler.Instance)
        /// 在线程池中调度工作（asynchronous，no-block）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThreadPoolScheduler_Click(object sender, EventArgs e)
        {
            Console.WriteLine("########## 使用 .SubscribeOn(ThreadPoolScheduler.Instance) :{0} ##########", Thread.CurrentThread.ManagedThreadId);
            var source = GetTestObservableSource();

            source
                .SubscribeOn(ThreadPoolScheduler.Instance)
                .Subscribe(o => Console.WriteLine("Received {1} on threadId:{0}", Thread.CurrentThread.ManagedThreadId, o),
                () => Console.WriteLine("OnCompleted on threadId:{0}", Thread.CurrentThread.ManagedThreadId));
        }




        /// <summary>
        /// 使用 SubscribeOn 与 ObserveOn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubscribeOnObserveOn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("########## 使用 SubscribeOn 与 ObserveOn :{0} ##########", Thread.CurrentThread.ManagedThreadId);

            IScheduler thread1 = new NewThreadScheduler(x => new Thread(x) { Name = "可观察对象线程" });
            IScheduler thread2 = new NewThreadScheduler(x => new Thread(x) { Name = "观察者线程" });


            var source = GetTestObservableSource();

            source
                .SubscribeOn(thread1)            
                .ObserveOn(thread2)
                .Subscribe(o => Console.WriteLine("Received {2} on threadId:{0} / {1}", Thread.CurrentThread.Name,Thread.CurrentThread.ManagedThreadId, o),
                () => Console.WriteLine("OnCompleted on threadId:{0} / {1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId));
        }






    }
}
