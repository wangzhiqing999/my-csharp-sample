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
using System.Reactive.Joins;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Reactive.Concurrency;


namespace R0100_Rx.UI2
{
    public partial class FormConditionalAndBoolean : Form
    {
        public FormConditionalAndBoolean()
        {
            InitializeComponent();
        }


        /// <summary>
        /// IObserver<T>接口表示接收它们 （观察者） 的类。 
        /// </summary>
        private IObserver<int> myObserver;
        private IObserver<bool> myObserver2;

        /// <summary>
        /// UI 画面，使用的线程.
        /// </summary>
        private IScheduler uiScheduler;


        private void FormConditionalAndBoolean_Load(object sender, EventArgs e)
        {
            myObserver = new MyObserver(this);
            myObserver2 = new MyObserver2(this);
            uiScheduler = new ControlScheduler(this);
        }


        /// <summary>
        /// All : 判断是否所发射的所有数据都满足某个条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAll_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);


            // 注意观察控制台日志. 当不满足条件， All 退出之后，interval 就不再继续了。
            interval
                .All(p=> p<5)                
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver2);
        }


        /// <summary>
        /// Amb ： 你传递多个Observable给Amb时，它只发射其中一个Observable的数据和通知：
        /// 首先发送通知给Amb的那个，不管发射的是一项数据还是一个onError或onCompleted通知。
        /// Amb将忽略和丢弃其它所有Observables的发射物。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAmb_Click(object sender, EventArgs e)
        {
            var greeting1 = Observable.Create<int>(observer =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    observer.OnNext(i*1000);

                    Console.WriteLine("### greeting1 OnNext {0} @ {1:yyyy-MM-dd HH:mm:ss}", i, DateTime.Now);
                }
                observer.OnCompleted();
                return Disposable.Empty;
            });

            var greeting2 = Observable.Create<int>(observer =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(2000);
                    observer.OnNext(i*2000);

                    Console.WriteLine("### greeting2 OnNext {0} @ {1:yyyy-MM-dd HH:mm:ss}", i, DateTime.Now);
                }
                observer.OnCompleted();
                return Disposable.Empty;
            });

            var greeting3 = Observable.Create<int>(observer =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(3000);
                    observer.OnNext(i*3000);

                    Console.WriteLine("### greeting3 OnNext {0} @ {1:yyyy-MM-dd HH:mm:ss}", i, DateTime.Now);
                }
                observer.OnCompleted();
                return Disposable.Empty;
            });


            // 注意：如果用下面这种写法，将导致 3个 跑在一个线程里面。
            // 最后，由参数排在前面的先执行， 排在后面的后执行。
            // var greeting = Observable.Amb(greeting3, greeting2, greeting1);



            // 三个可观察对象，多线程执行.
            var greeting = Observable.Amb(
                greeting3.SubscribeOn(NewThreadScheduler.Default),
                greeting2.SubscribeOn(NewThreadScheduler.Default),
                greeting1.SubscribeOn(NewThreadScheduler.Default)
                );
            

            // 观察控制台 与 WinForm 画面。
            // Amd 接收最早进来的那个 可观察对象的 消息后， 忽略其他的 可观察对象的 消息。
            greeting
                // 可观察对象线程，跑在新的线程上. (注释掉下面这句，将导致画面的卡顿)
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }


        /// <summary>
        /// Contains - 判断所发射的数据是否包含某个值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContains_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);


            // 注意观察控制台日志. 当满足条件， Contains 退出之后，interval 就不再继续了。
            interval
                .Contains(3)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver2);


            // 注意观察控制台日志. 当满足条件， Any 退出之后，interval 就不再继续了。
            interval
                .Any(p=> p >= 8)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver2);

        }




        /// <summary>
        /// DefaultIfEmpty - 如果原始Observable没有发射任何值，就发射一个默认值。
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultIfEmpty_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(3);

            // 有数据的情况下， DefaultIfEmpty 不会触发.
            interval
                .DefaultIfEmpty(999999)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);


            // 无数据，只有一个 OnCompleted
            var empty = Observable.Empty<int>();

            // 无数据的情况下， 使用默认值.
            empty
                .DefaultIfEmpty(88888)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
            
        }



        /// <summary>
        /// SequenceEqual - 对比两个 可观察对象，发送的数据， 顺序/数值 上是否一致.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSequenceEqual_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(5);


            // 直接数字 0开始，长度5.
            var range = Observable.Range(0, 5);


            // 一个 每秒一个数据， 和一个 即时产生5条的。 进行比较。
            interval
                .SequenceEqual(range)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver2);
        }



        /// <summary>
        /// SkipUntil - 丢弃原始Observable发射的数据，直到第二个Observable发射了一项数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSkipUntil_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);

            // 3秒后，才发送第一个数据.
            var greeting = Observable.Create<int>(observer =>
            {
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(3000);
                    Console.WriteLine("### greeting {0} @ {1:yyyy-MM-dd HH:mm:ss}", i, DateTime.Now);
                    observer.OnNext(i);
                }

                observer.OnCompleted();
                return Disposable.Empty;
            });


            interval
                .SkipUntil(greeting)
                // 可观察对象线程，跑在新的线程上. 
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);


        }



        /// <summary>
        /// SkipWhile 当条件不满足时执行，SkipWhile订阅原始的Observable，但是忽略它的发射物，
        /// 直到你指定的某个条件变为false的那一刻，它开始发射原始Observable。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSkipWhile_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);

            interval
                // 这里当数字小于5的时候，一直忽略.
                .SkipWhile(p=>p < 5)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }




        /// <summary>
        /// TakeUntil - 当第二个Observable发射了一项数据或者终止时，丢弃原始Observable发射的任何数据。
        /// 
        /// TakeUntil订阅并开始发射原始Observable，它还监视你提供的第二个Observable。
        /// 如果第二个Observable发射了一项数据或者发射了一个终止通知，TakeUntil返回的Observable会停止发射原始Observable并终止。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTakeUntil_Click(object sender, EventArgs e)
        {

            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);

            // 3秒后，才发送第一个数据.
            var greeting = Observable.Create<int>(observer =>
            {
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(3000);
                    Console.WriteLine("### greeting {0} @ {1:yyyy-MM-dd HH:mm:ss}", i, DateTime.Now);
                    observer.OnNext(i);
                }

                observer.OnCompleted();
                return Disposable.Empty;
            });


            interval
                .TakeUntil(greeting.SubscribeOn(NewThreadScheduler.Default))
                // 可观察对象线程，跑在新的线程上. 
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

        }



        /// <summary>
        /// TakeWhile - 发射Observable发射的数据，直到一个指定的条件不成立。
        /// TakeWhile发射原始Observable，直到你指定的某个条件不成立的那一刻，它停止发射原始Observable，并终止自己的Observable。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTakeWhile_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);

            interval
                // 这里当数字小于5的时候，一直接受.
                .TakeWhile(p => p < 5)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }






        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver : IObserver<int>
        {

            private FormConditionalAndBoolean formItem;


            public MyObserver(FormConditionalAndBoolean formItem)
            {
                this.formItem = formItem;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<int>.OnCompleted()
            {
                formItem.txtResult.AppendText("处理结束！");
                formItem.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<int>.OnError(Exception error)
            {
                formItem.txtResult.AppendText("处理过程中发生了异常！");
                formItem.txtResult.AppendText("\r\n");
            }



            void IObserver<int>.OnNext(int value)
            {
                formItem.txtResult.AppendText(value.ToString());
                formItem.txtResult.AppendText(" ");
                formItem.txtResult.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                formItem.txtResult.AppendText("\r\n");
            }
        }




        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver2 : IObserver<bool>
        {

            private FormConditionalAndBoolean formItem;


            public MyObserver2(FormConditionalAndBoolean formItem)
            {
                this.formItem = formItem;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<bool>.OnCompleted()
            {
                formItem.txtResult.AppendText("处理结束！");
                formItem.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<bool>.OnError(Exception error)
            {
                formItem.txtResult.AppendText("处理过程中发生了异常！");
                formItem.txtResult.AppendText("\r\n");
            }



            void IObserver<bool>.OnNext(bool value)
            {
                formItem.txtResult.AppendText(value.ToString());
                formItem.txtResult.AppendText(" ");
                formItem.txtResult.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                formItem.txtResult.AppendText("\r\n");
            }
        }




    }
}
