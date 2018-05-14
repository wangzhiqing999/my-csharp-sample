using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Reactive.Concurrency;



namespace R0100_Rx.UI2
{
    public partial class FormConnectable : Form
    {
        public FormConnectable()
        {
            InitializeComponent();
        }



        /// <summary>
        /// IObserver<T>接口表示接收它们 （观察者） 的类。 
        /// </summary>
        private IObserver<int> myObserver;
        private IObserver<int> myObserver1;
        private IObserver<int> myObserver2;

        /// <summary>
        /// UI 画面，使用的线程.
        /// </summary>
        private IScheduler uiScheduler;



        private void FormConnectable_Load(object sender, EventArgs e)
        {
            myObserver = new MyObserver(this);

            myObserver1 = new MyObserver(this, "TEST1");
            myObserver2 = new MyObserver(this, "TEST2");

            uiScheduler = new ControlScheduler(this);     
        }




        /// <summary>
        /// Publish
        /// 将普通的Observable转换为可连接的Observable。
        /// 可连接的Observable (connectable Observable)与普通的Observable差不多，不过它并不会在被订阅时开始发射数据，
        /// 而是直到使用了Connect操作符时才会开始。用这种方法，你可以在任何时候让一个Observable开始发射数据。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPublish_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10)
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p + 1); });


            // 将普通的Observable转换为可连接的Observable。
            var pub = interval.Publish();


            pub
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver1);


            pub
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver2);


            pub.Connect();


            // 测试一个 在 Connect 运行一段时间之后， 才进来订阅的。
            // 这个操作，会导致画面卡顿3秒.
            Thread.Sleep(3000);

            pub
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver);
        }




        /// <summary>
        /// 对比操作， 不使用 Publish + Connect 的情况下.
        /// 
        /// 注意观察控制台日志
        /// 不使用 Publish + Connect 的情况下， 每个数据，都发射了2次。 分别单独发送给不同的订阅者。
        /// 
        /// 使用 Publish + Connect 的情况下， 每个数据，发射了1次。 同时发送给多个订阅者。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoPublic_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10)
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p + 1); });


            interval
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver1);


            interval
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver2);

        }



        /// <summary>
        /// 如果在将一个Observable转换为可连接的Observable之前对它使用Replay操作符，
        /// 产生的这个可连接Observable将总是发射完整的数据序列给任何未来的观察者，
        /// 即使那些观察者在这个Observable开始给其它观察者发射数据之后才订阅。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplay_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10)
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p + 1); });


            // 将普通的Observable转换为可连接的Observable。
            // 注意： 如果写成  interval.Replay().Publish(); 好像就无效了.
            var pub = interval.Replay();


            pub
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver1);


            pub
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver2);


            pub.Connect();


            // 测试一个 在 Connect 运行一段时间之后， 才进来订阅的。
            // 这个操作，会导致画面卡顿3秒.
            Thread.Sleep(3000);


            // 注意： 这里是使用了 Replay() 的可观察对象.  3秒后， 还是能获取全部数据的。
            pub                
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver);
        }




        /// <summary>
        /// RefCount
        /// 将可连接的Observable转换成普通的Observalbe，当订阅被取消后重新订阅不会重新执行。让一个可连接的Observable表现得像一个普通的Observable
        /// 
        /// 一个可连接的Observable与普通的Observable差不多，
        /// 除了这一点：可连接的Observable在被订阅时并不开始发射数据，只有在它的connect()被调用时才开始。
        /// 用这种方法，你可以等所有的潜在订阅者都订阅了这个Observable之后才开始发射数据。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefCount_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10)
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p + 1); });



            // 将普通的Observable转换为可连接的Observable。
            var pub = interval.Publish();


            // 将可连接的Observable转换成普通的Observalbe
            var normal = pub.RefCount();


            pub
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver1);


            pub
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver2);


            pub.Connect();


            // 测试一个 在 Connect 运行一段时间之后， 才进来订阅的。
            // 这个操作，会导致画面卡顿3秒.
            Thread.Sleep(3000);


            // 注意： 这里是使用了 RefCount() 的普通的Observalbe.
            normal
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver);


        }






        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver : IObserver<int>
        {

            private FormConnectable formItem;


            private string name;


            public MyObserver(FormConnectable formItem, string name = "TEST")
            {
                this.formItem = formItem;
                this.name = name;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<int>.OnCompleted()
            {
                formItem.txtResult.AppendText(this.name);
                formItem.txtResult.AppendText(" : 处理结束！");
                formItem.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<int>.OnError(Exception error)
            {
                formItem.txtResult.AppendText(this.name);
                formItem.txtResult.AppendText(" : 处理过程中发生了异常！");
                formItem.txtResult.AppendText("\r\n");
            }



            void IObserver<int>.OnNext(int value)
            {
                formItem.txtResult.AppendText(this.name);
                formItem.txtResult.AppendText(" : ");
                formItem.txtResult.AppendText(value.ToString());
                formItem.txtResult.AppendText(" ");
                formItem.txtResult.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                formItem.txtResult.AppendText("\r\n");
            }
        }






    }
}
