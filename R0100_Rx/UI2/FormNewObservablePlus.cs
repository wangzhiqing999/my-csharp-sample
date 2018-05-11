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
    public partial class FormNewObservablePlus : Form
    {
        public FormNewObservablePlus()
        {
            InitializeComponent();
        }


        /// <summary>
        /// IObserver<T>接口表示接收它们 （观察者） 的类。 
        /// </summary>
        private IObserver<string> myObserver;

        /// <summary>
        /// UI 画面，使用的线程.
        /// </summary>
        private IScheduler uiScheduler;



        private void FormNewObservablePlus_Load(object sender, EventArgs e)
        {
            myObserver = new MyObserver(this);
            uiScheduler = new ControlScheduler(this);
        }



        /// <summary>
        /// Return可以创建一个具体的IObservable<T>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            var greeting = Observable.Return("使用 Observable.Return 创建一个 IObservable<T>， 简单发送一个消息。");

            greeting.Subscribe(this.myObserver);
        }

        /// <summary>
        /// Create可以创建一个IObservable<T>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var greeting = Observable.Create<string>(observer =>
            {
                observer.OnNext("使用 Observable.Create 创建一个 IObservable<T>");
                Thread.Sleep(1000);
                observer.OnNext("自定义 OnNext 的处理...1");
                Thread.Sleep(2000);
                observer.OnNext("自定义 OnNext 的处理...2");
                Thread.Sleep(3000);
                observer.OnNext("自定义 OnNext 的处理...3");
                Thread.Sleep(4000);
                observer.OnCompleted();
                return Disposable.Empty;
            });

            greeting
                // 可观察对象线程，跑在新的线程上.
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }

        /// <summary>
        /// Range方法可以产生一个指定范围内的IObservable<T>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRange_Click(object sender, EventArgs e)
        {
            var range = Observable.Range(1, 10).Select(p => p.ToString());

            range.Subscribe(this.myObserver);
        }

        /// <summary>
        /// Generate 方法是一个折叠操作的逆向操作，又称Unfold方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {

            // 4个参数.
            // 1:初始值.
            // 2:判断条件.
            // 3:累计处理.
            // 4:返回值.
            var range = Observable.Generate(0, x => x < 10, x => x + 2, x => x.ToString());


            range.Subscribe(this.myObserver);
        }

        /// <summary>
        /// Interval所创建的Observable对象会从0开始，每隔固定的时间发射一个数字。
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInterval_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p=>p.ToString());

            interval
                // 为了避免退出时异常，这里简单的只获取前 10 条.
                .Take(10)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }


        /// <summary>
        /// Timer会在指定时间后发射一个数字0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimer_Click(object sender, EventArgs e)
        {
            // 3秒后.
            TimeSpan ts = new TimeSpan(0, 0, 3);

            var timer = Observable.Timer(ts).Select(p=>p.ToString());

            timer
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

        }



        /// <summary>
        /// Start — 创建发射一个函数的返回值的Observable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            var o = Observable.Start<string>(TestFunc);

            o.Subscribe(this.myObserver);
        }

        private string TestFunc()
        {
            return "这是 TestFunc() 函数的返回值！";
        }


        /// <summary>
        /// ToObservable 将集合转换为 发射这些对象的Observable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToObservable_Click(object sender, EventArgs e)
        {
            List<string> testDataList = new List<string>()
            {
                "A", "B", "C", "D", "E"
            };

            var x = testDataList.ToObservable();
            x.Subscribe(this.myObserver);
        }







        /// <summary>
        /// Empty 创建一个不发射任何数据但是正常终止的Observable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmpty_Click(object sender, EventArgs e)
        {
            var empty = Observable.Empty<string>();

            empty.Subscribe(this.myObserver);

        }


        /// <summary>
        /// 创建一个不发射数据也不终止的Observable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNever_Click(object sender, EventArgs e)
        {
            var never = Observable.Never<string>();

            never.Subscribe(this.myObserver);
        }


        /// <summary>
        /// 创建一个不发射数据以一个错误终止的Observable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThrow_Click(object sender, EventArgs e)
        {
            Exception ex = new Exception("测试异常");
            var throws = Observable.Throw<string>(ex);

            throws.Subscribe(this.myObserver);
        }


        /// <summary>
        /// Repeat会将一个Observable对象重复发射，我们可以指定其发射的次数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRepeat_Click(object sender, EventArgs e)
        {
            var greeting = Observable.Return("使用 Observable.Return 创建一个 IObservable<T>， 简单发送一个消息。");

            var repeat = greeting.Repeat(10);

            repeat.Subscribe(this.myObserver);            
        }













        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver : IObserver<string>
        {

            private FormNewObservablePlus formNewObservablePlus;


            public MyObserver(FormNewObservablePlus formHelloWorld)
            {
                this.formNewObservablePlus = formHelloWorld;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<string>.OnCompleted()
            {
                formNewObservablePlus.txtResult.AppendText("处理结束！");
                formNewObservablePlus.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<string>.OnError(Exception error)
            {
                formNewObservablePlus.txtResult.AppendText("处理过程中发生了异常！");
                formNewObservablePlus.txtResult.AppendText("\r\n");
            }



            void IObserver<string>.OnNext(string value)
            {
                formNewObservablePlus.txtResult.AppendText(value);
                formNewObservablePlus.txtResult.AppendText("\r\n");
            }
        }












    }
}
