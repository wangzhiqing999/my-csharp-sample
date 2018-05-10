using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Reactive;
using System.Reactive.Joins;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Reactive.Concurrency;


namespace R0100_Rx.UI2
{
    public partial class FormCombining : Form
    {
        public FormCombining()
        {
            InitializeComponent();
        }

        /// <summary>
        /// IObserver<T>接口表示接收它们 （观察者） 的类。 
        /// </summary>
        private IObserver<int> myObserver;
        private IObserver<IList<int>> myObserver2;

        /// <summary>
        /// UI 画面，使用的线程.
        /// </summary>
        private IScheduler uiScheduler;


        private void FormCombining_Load(object sender, EventArgs e)
        {
            myObserver = new MyObserver(this);
            myObserver2 = new MyObserver2(this);
            uiScheduler = new ControlScheduler(this);
        }


        /// <summary>
        /// Zip — 打包，使用一个指定的函数将多个Observable发射的数据组合在一起，然后将这个函数的结果作为单项数据发射
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZip_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(5);

            // 每2秒产生一个数据.
            var interva2 = Observable.Interval(TimeSpan.FromSeconds(2)).Select(p => Convert.ToInt32(p * 10)).Take(5);

            // 每3秒产生一个数据.
            var interva3 = Observable.Interval(TimeSpan.FromSeconds(3)).Select(p => Convert.ToInt32(p * 100)).Take(5);


            var interva = Observable.Zip(interval, interva2, interva3);

            interva
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver2);


        }


        /// <summary>
        /// Merge — 将多个Observable发射的数据组合并成一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMerege_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(5);

            // 每2秒产生一个数据.
            var interva2 = Observable.Interval(TimeSpan.FromSeconds(2)).Select(p => Convert.ToInt32(p * 10)).Take(5);

            // 每3秒产生一个数据.
            var interva3 = Observable.Interval(TimeSpan.FromSeconds(3)).Select(p => Convert.ToInt32(p * 100)).Take(5);


            var interva = Observable.Merge(interval, interva2, interva3);


            interva
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver);
        }



        /// <summary>
        /// Join — 无论何时，如果一个Observable发射了一个数据项，
        /// 只要在另一个Observable发射的数据项定义的时间窗口内，就将两个Observable发射的数据合并发射
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJoin_Click(object sender, EventArgs e)
        {
            // 每2秒产生一个数据. (共计10个, 总耗时20秒)
            var interva2 = Observable.Interval(TimeSpan.FromSeconds(2)).Select(p => Convert.ToInt32(p)).Take(10);

            // 每3秒产生一个数据. (共计5个， 总耗时15秒)
            var interva3 = Observable.Interval(TimeSpan.FromSeconds(3)).Select(p => Convert.ToInt32(p)).Take(5);

            // 5个参数.
            // 参数1：左可观测对象源.
            // 参数2：右可观测对象源.
            // 参数3：左可观测对象的生存周期
            // 参数4：右可观测对象的生存周期
            // 参数5：两个可观测对象的数据， 如何计算/组合成一个数据。 （最终向外发送的数据，是组合后的）
            var interva = Observable.Join<int, int, int, int, int>(
                left :interva2,
                right: interva3,
                leftDurationSelector: GetLeftDurationSelector,
                rightDurationSelector: GetRightDurationSelector,
                resultSelector: DoJoinWork);
            
            // Join 的操作
            // 左边和右边， 都在不断的发送数据。（由参数1  和  参数2 决定）
            // 每发送一个数据， 都存在一定的生存周期。（由参数3  和  参数4 决定）
            // 左边发送一个数据后， 会去右边， 找到， 在生存周期内的所有数据， 进行排列组合， 去调用组合的函数 (由参数5决定)
            // 右边发送一个数据后， 会去左边， 找到， 在生存周期内的所有数据， 进行排列组合， 去调用组合的函数 (由参数5决定)

            interva
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver);
        }


        /// <summary>
        /// 获取左边数据的生存周期. 
        /// 如果简单使用 Observable.Return 的话， 整个过程，将不会返回任何结果。
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private IObservable<int> GetLeftDurationSelector(int x)
        {
            Console.WriteLine("GetLeftDurationSelector : {0}  @{1:yyyy-MM-dd HH:mm:ss}", x, DateTime.Now);
            return Observable.Timer(new TimeSpan(0, 0, 2)).Select(p=> Convert.ToInt32(p));
        }

        /// <summary>
        /// 获取右边数据的生存周期. 
        /// 如果简单使用 Observable.Return 的话， 整个过程，将不会返回任何结果。
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private IObservable<int> GetRightDurationSelector(int y)
        {
            Console.WriteLine("GetRightDurationSelector : {0}  @{1:yyyy-MM-dd HH:mm:ss}", y, DateTime.Now);
            return Observable.Timer(new TimeSpan(0, 0, 3)).Select(p => Convert.ToInt32(p));
        }


        private int DoJoinWork(int x, int y)
        {
            return x * 1000 + y;
        }






        /// <summary>
        /// combineLatest()函数有点像zip()函数的特殊形式。
        /// zip()作用于最近未打包的两个Observables。
        /// combineLatest()作用于最近发射的数据项
        /// 
        /// 当两个Observables中的任何一个发射了一个数据时，通过一个指定的函数组合每个Observable发射的最新数据（一共两个数据），然后发射这个函数的结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCombineLatest_Click(object sender, EventArgs e)
        {
            // 每2秒产生一个数据. (共计10个, 总耗时20秒)
            var interva2 = Observable.Interval(TimeSpan.FromSeconds(2)).Select(p => Convert.ToInt32(p)).Take(10);

            // 每3秒产生一个数据. (共计5个， 总耗时15秒)
            var interva3 = Observable.Interval(TimeSpan.FromSeconds(3)).Select(p => Convert.ToInt32(p)).Take(5);


            var interva = Observable.CombineLatest(interva2, interva3);

            interva
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver2);
        }



        /// <summary>
        /// And - Then - When 的操作.
        /// 本例子的操作， 运行效果， 与 Zip 一致。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAndThenWhen_Click(object sender, EventArgs e)
        {
            // 每2秒产生一个数据. (共计10个, 总耗时20秒)
            var interva2 = Observable.Interval(TimeSpan.FromSeconds(2)).Select(p => Convert.ToInt32(p)).Take(10);
            // 每3秒产生一个数据. (共计5个， 总耗时15秒)
            var interva3 = Observable.Interval(TimeSpan.FromSeconds(3)).Select(p => Convert.ToInt32(p)).Take(5);


            // 使用 And 创建 Pattern 对象.
            Pattern<int, int> pattern = Observable.And(interva2, interva3);

            // 使用刚创建的Pattern对象， Then 创建 Plan 对象.
            Plan<int> plan = pattern.Then(DoJoinWork);


            Observable.When(plan)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver);
        }






        /// <summary>
        /// 有这样一个复杂的场景就是在一个subscribe-unsubscribe的序列里我们能够从一个Observable自动取消订阅来订阅一个新的Observable。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            // 每1秒产生一个数据.
            IObservable<int> interva2 = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(10);

            // 每5秒产生一组数据. 共5组.
            IObservable<IObservable<int>> interva3 = Observable.Interval(TimeSpan.FromSeconds(5)).Select(p => interva2).Take(5);

            // 有5组 IObservable<int>,  在一个 IObservable<IObservable<int>> 之中。
            // 每当新的一组 IObservable<int> 来的时候， 丢弃上一组 未发送的数据.
            // 直到最后一组 IObservable<int> 的最后一个 int 数据处理完毕后， 全部结束.

            Observable.Switch(interva3)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver);
        }





        /// <summary>
        /// StartWith — 在发射原来的Observable的数据序列之前，先发射一个指定的数据序列或数据项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartWith_Click(object sender, EventArgs e)
        {
            // 每1秒产生一个数据.
            IObservable<int> interva2 = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(10);

            interva2.StartWith(99, 98, 97)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(myObserver);

        }







        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver : IObserver<int>
        {

            private FormCombining formItem;


            public MyObserver(FormCombining formItem)
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
        class MyObserver2 : IObserver<IList<int>>
        {

            private FormCombining formItem;


            public MyObserver2(FormCombining formItem)
            {
                this.formItem = formItem;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<IList<int>>.OnCompleted()
            {
                formItem.txtResult.AppendText("处理结束！");
                formItem.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<IList<int>>.OnError(Exception error)
            {
                formItem.txtResult.AppendText("处理过程中发生了异常！");
                formItem.txtResult.AppendText("\r\n");
            }



            void IObserver<IList<int>>.OnNext(IList<int> value)
            {
                foreach (var item in value)
                {
                    formItem.txtResult.AppendText(item.ToString());
                    formItem.txtResult.AppendText("\r\n");
                }
                formItem.txtResult.AppendText("\r\n");
            }
        }












    }
}
