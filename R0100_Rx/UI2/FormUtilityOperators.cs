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
    public partial class FormUtilityOperators : Form
    {
        public FormUtilityOperators()
        {
            InitializeComponent();
        }



        /// <summary>
        /// IObserver<T>接口表示接收它们 （观察者） 的类。 
        /// </summary>
        private IObserver<int> myObserver;

        private IObserver<Notification<int>> myObserver2;

        private IObserver<TimeInterval<int>> myObserver3;

        private IObserver<Timestamped<int>> myObserver4;
        
        
        /// <summary>
        /// UI 画面，使用的线程.
        /// </summary>
        private IScheduler uiScheduler;




        private void FormUtilityOperators_Load(object sender, EventArgs e)
        {
            myObserver = new MyObserver(this);
            myObserver2 = new MyObserver2(this);
            myObserver3 = new MyObserver3(this);
            myObserver4 = new MyObserver4(this);
            uiScheduler = new ControlScheduler(this);
        }



        /// <summary>
        /// delay的意思就是延迟，这个操作符会延迟一段指定的时间再发射Observable的数据。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelay_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);

            // 时间间隔 5 秒
            TimeSpan timespan = new TimeSpan(0, 0, 5);

            // 这里可以同时观察 控制台的输出，  与 WinForm 的输出。
            // 来明确， Delay 操作是如何生效的。
            interval
                .Delay(timespan)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

        }


        /// <summary>
        /// delaySubscription是延迟订阅原始Observable，这样也能达到数据延迟发射的效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelaySubscription_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);

            // 时间间隔 5 秒
            TimeSpan timespan = new TimeSpan(0, 0, 5);

            // 这里可以同时观察 控制台的输出，  与 WinForm 的输出。
            // 来观察， Delay 与 DelaySubscription 操作的区别。
            interval
                .DelaySubscription(timespan)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }


        /// <summary>
        /// Do操作符就是为原始Observable的生命周期事件注册一个回调，当Observable的某个事件发生时就会调用这些回调。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDo_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);

            // 感觉上来说，Do 之类的操作， 就是拿来在 可观察对象 上面， 做日志的处理.
            interval
                .Do(p => Console.WriteLine("### interval Do {0}", p))
                .Finally(() => Console.WriteLine("### interval Finally!"))
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }




        /// <summary>
        /// Materialize将来自原始Observable的通知（onNext/onError/onComplete）都转换为一个Notification对象，然后再按原来的顺序一次发射出去。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaterialize_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);


            interval
                .Materialize()
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver2);
        }


        /// <summary>
        /// Dematerialize操作符是Materialize的逆向过程，它将Materialize转换的结果还原成它原本的形式（ 将Notification对象还原成Observable的通知）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDematerialize_Click(object sender, EventArgs e)
        {

            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);


            interval
                // 先 Materialize
                .Materialize()
                // 后 Dematerialize
                .Dematerialize()
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }



        /// <summary>
        /// 可以使用observeOn操作符指定Observable在哪个调度器上发送通知给观察者（调用观察者的onNext,onCompleted,onError方法）。
        /// 一般我们可以指定在主线程中观察，这样就可以修改UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnObserveOn_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(10);


            // 其实本例子可以不写的。
            // 因为之前的大部分测试， 都是让 观察者线程，跑到 WinForm 控件的线程上.
            // 否则一运行， 就抛异常了.
            interval
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

        }

        /// <summary>
        /// 指定Observable自身在哪个调度器上执行（即在那个线程上运行），如果Observable需要执行耗时操作，一般我们可以让其在新开的一个子线程上运行.
        /// 否则的话， 会造成画面的卡顿。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubscribeOn_Click(object sender, EventArgs e)
        {
            var greeting = Observable.Create<int>(observer =>
            {
                observer.OnNext(1);
                Thread.Sleep(1000);

                observer.OnNext(2);
                Thread.Sleep(2000);

                observer.OnNext(3);
                Thread.Sleep(3000);

                observer.OnCompleted();
                return Disposable.Empty;
            });


            greeting
                // 可观察对象线程，跑在新的线程上. (注释掉下面这句，将导致画面的卡顿)
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

        }


        /// <summary>
        /// TimeInterval操作符拦截原始Observable发射的数据项，替换为两个连续发射物之间流逝的时间长度。 
        /// 也就是说这个使用这个操作符后发射的不再是原始数据，而是原始数据发射的时间间隔。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimeInterval_Click(object sender, EventArgs e)
        {
            var greeting = Observable.Create<int>(observer =>
            {
                observer.OnNext(1);
                Thread.Sleep(1000);

                observer.OnNext(2);
                Thread.Sleep(2000);

                observer.OnNext(3);
                Thread.Sleep(3000);

                observer.OnCompleted();
                return Disposable.Empty;
            });


            greeting
                .TimeInterval()
                // 可观察对象线程，跑在新的线程上. (注释掉下面这句，将导致画面的卡顿)
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver3);
        }




        /// <summary>
        /// C# 里面是 Synchronize
        /// http://reactivex.io 那里是 Serialize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerialize_Click(object sender, EventArgs e)
        {
            var greeting = Observable.Create<int>(observer =>
            {
                Task.Run(new Action(() => GetOnNext(observer, 1)));
                Task.Run(new Action(() => GetOnNext(observer, 5)));
                Task.Run(new Action(() => GetOnNext(observer, 10)));

                return Disposable.Empty;
            });

            greeting
                // 这个要跑多个线程的，很难验证执行效果。
                .Synchronize()
                // 可观察对象线程，跑在新的线程上. (注释掉下面这句，将导致画面的卡顿)
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

        }

        private void GetOnNext(IObserver<int> observer, int i)
        {
            observer.OnNext(i + 1);
            Thread.Sleep(100 * (i + 1));

            observer.OnNext(i + 2);
            Thread.Sleep(100 * (i + 2));

            observer.OnNext(i + 3);
            Thread.Sleep(100 * (i + 3));

            observer.OnCompleted();
        }



        /// <summary>
        /// Timeout 如果原始Observable过了指定的一段时长没有发射任何数据，Timeout操作符会以一个onError通知终止这个Observable，或者继续一个备用的Observable。
        /// 
        /// 本方法测试 以一个onError通知终止这个Observable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimeout_Click(object sender, EventArgs e)
        {
            var greeting = Observable.Create<int>(observer =>
            {
                for (int i = 1; i < 10; i++)
                {
                    observer.OnNext(i);
                    Thread.Sleep(1000 * i);
                }
                observer.OnCompleted();
                return Disposable.Empty;
            });

            // 时间间隔 3 秒
            TimeSpan timespan = new TimeSpan(0, 0, 3);

            greeting
                // 设置超时.
                .Timeout(timespan)
                // 可观察对象线程，跑在新的线程上. (注释掉下面这句，将导致画面的卡顿)
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

        }

        /// <summary>
        /// Timeout 如果原始Observable过了指定的一段时长没有发射任何数据，Timeout操作符会以一个onError通知终止这个Observable，或者继续一个备用的Observable。
        /// 
        /// 本方法测试 继续一个备用的Observable。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimeoutOther_Click(object sender, EventArgs e)
        {
            var greeting = Observable.Create<int>(observer =>
            {
                for (int i = 1; i < 10; i++)
                {
                    observer.OnNext(i);
                    Thread.Sleep(1000 * i);
                }
                observer.OnCompleted();
                return Disposable.Empty;
            });

            // 时间间隔 3 秒
            TimeSpan timespan = new TimeSpan(0, 0, 3);

            greeting
                // 设置超时.
                .Timeout(timespan, Observable.Range(1001, 3))
                // 可观察对象线程，跑在新的线程上. (注释掉下面这句，将导致画面的卡顿)
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }


        /// <summary>
        /// Timestamp 将一个发射T类型数据的Observable转换为一个发射类型为Timestamped的数据的Observable，每一项都包含数据的发射时间。
        /// 也就是把Observable发射的数据重新包装了一下，将数据发射的时间打包一起发射出去，这样观察者不仅能得到数据，还能得到数据的发射时间。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimestamp_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(10);

            interval
                .Timestamp()
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver4);
        }



        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver : IObserver<int>
        {

            private FormUtilityOperators formItem;


            public MyObserver(FormUtilityOperators formItem)
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
        class MyObserver2 : IObserver<Notification<int>>
        {

            private FormUtilityOperators formItem;


            public MyObserver2(FormUtilityOperators formItem)
            {
                this.formItem = formItem;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<Notification<int>>.OnCompleted()
            {
                formItem.txtResult.AppendText("处理结束！");
                formItem.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<Notification<int>>.OnError(Exception error)
            {
                formItem.txtResult.AppendText("处理过程中发生了异常！");
                formItem.txtResult.AppendText("\r\n");
            }



            void IObserver<Notification<int>>.OnNext(Notification<int> value)
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
        class MyObserver3 : IObserver<TimeInterval<int>>
        {

            private FormUtilityOperators formItem;


            public MyObserver3(FormUtilityOperators formItem)
            {
                this.formItem = formItem;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<TimeInterval<int>>.OnCompleted()
            {
                formItem.txtResult.AppendText("处理结束！");
                formItem.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<TimeInterval<int>>.OnError(Exception error)
            {
                formItem.txtResult.AppendText("处理过程中发生了异常！");
                formItem.txtResult.AppendText("\r\n");
            }



            void IObserver<TimeInterval<int>>.OnNext(TimeInterval<int> value)
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
        class MyObserver4 : IObserver<Timestamped<int>>
        {

            private FormUtilityOperators formItem;


            public MyObserver4(FormUtilityOperators formItem)
            {
                this.formItem = formItem;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<Timestamped<int>>.OnCompleted()
            {
                formItem.txtResult.AppendText("处理结束！");
                formItem.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<Timestamped<int>>.OnError(Exception error)
            {
                formItem.txtResult.AppendText("处理过程中发生了异常！");
                formItem.txtResult.AppendText("\r\n");
            }



            void IObserver<Timestamped<int>>.OnNext(Timestamped<int> value)
            {
                formItem.txtResult.AppendText(value.ToString());
                formItem.txtResult.AppendText(" ");
                formItem.txtResult.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                formItem.txtResult.AppendText("\r\n");
            }
        }







    }
}
