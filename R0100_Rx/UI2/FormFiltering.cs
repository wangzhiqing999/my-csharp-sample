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
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Reactive.Concurrency;



namespace R0100_Rx.UI2
{
    public partial class FormFiltering : Form
    {
        public FormFiltering()
        {
            InitializeComponent();
        }


        /// <summary>
        /// IObserver<T>接口表示接收它们 （观察者） 的类。 
        /// </summary>
        private IObserver<int> myObserver;

        /// <summary>
        /// UI 画面，使用的线程.
        /// </summary>
        private IScheduler uiScheduler;


        private void FormFiltering_Load(object sender, EventArgs e)
        {
            myObserver = new MyObserver(this);
            uiScheduler = new ControlScheduler(this);
        }





        /// <summary>
        /// C# 中是 Throttle
        /// http://reactivex.io 文档中，是 Debounce
        /// 
        /// 源Observable每发射一个数据项，
        /// 如果在debounce规定的间隔时间内Observable没有发射新的数据项，
        /// debounce就把这个结果提交给订阅者处理，
        /// 如果在规定的间隔时间内产生了其他结果，
        /// 就忽略掉发射的这个数据,通过制定的时间间隔来限流，
        /// 可以过滤掉发射速率过快的数据项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThrottle_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(30);

            // 用于模拟， 某个时间段， 发生了频繁的操作.
            int[] seconds = {1, 5,6,7,  11,  15,16,17,  21, 25};

            // 时间间隔为 2秒.
            TimeSpan ts = new TimeSpan(0, 0, 2);

            interval
                .Where(p => seconds.Contains(p))
                // 按 2 秒进行 Throttle
                .Throttle(ts)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

        }






        /// <summary>
        /// C# 中是 Where
        /// http://reactivex.io 文档中，是 Filter
        /// 
        /// Where 只会返回满足过滤条件的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWhere_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(10);

            // 这里过滤， 只返回 偶数.
            interval
                .Where(p=>p % 2 == 0)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }

        /// <summary>
        /// C# 中是 OfType
        /// http://reactivex.io 文档中，是 Filter
        /// 
        /// OfType 只会返回满足过滤条件的数据 （以数据类型为条件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOfType_Click(object sender, EventArgs e)
        {
            object[] dataList = { 1, 2, 3, "A", "B", "C", 1.2, 2.3, 3.4,  7L, 8L, 9L};

            var range = dataList.ToObservable();

            // 这里过滤， 只返回 int 类型的数据.
            range
                .OfType<int>()
                .DistinctUntilChanged()
                .Subscribe(this.myObserver);
        }





        /// <summary>
        /// 当我们不需要整个序列时，而是只想取开头或结尾的几个元素，我们可以用take()或takeLast()。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTake_Click(object sender, EventArgs e)
        {
            var range = Observable.Range(1, 10);

            range
                .Take(3)
                .Subscribe(this.myObserver);
        }

        /// <summary>
        /// 当我们不需要整个序列时，而是只想取开头或结尾的几个元素，我们可以用take()或takeLast()。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTakeLast_Click(object sender, EventArgs e)
        {
            var range = Observable.Range(1, 10);

            range
                .TakeLast(3)
                .Subscribe(this.myObserver);
        }


        /// <summary>
        /// Distinct 有且仅有一次
        /// 我们可以对我们的序列使用distinct()函数去掉重复的。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDistinct_Click(object sender, EventArgs e)
        {
            List<int> dataList = new List<int>();
            for(int i = 0; i < 10; i ++){
                dataList.Add(i);
                dataList.Add(i + 1);
                dataList.Add(i);
            }

            var range = dataList.ToObservable();

            range
                .Distinct()
                .Subscribe(this.myObserver);
        }


        /// <summary>
        /// distinctUntilChanged,是用来过滤掉连续的重复数据。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDistinctUntilChanged_Click(object sender, EventArgs e)
        {
            int[] dataList = { 1,1,1,1, 2,2,2, 3,3,3, 1,2,3, 4,4,4,5,6,7,7,7,8,9,9,10};
            
            var range = dataList.ToObservable();

            range
                .DistinctUntilChanged()
                .Subscribe(this.myObserver);
        }


        /// <summary>
        /// elementAt(index)
        /// 将指定索引的数据项提交给订阅者，索引是从0开始，当没有这个索引或者索引为负数会抛异常。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnElementAt_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(10);

            // 使用 ElementAt 获取到数据之后， 就立即结束了.
            interval
                .ElementAt(3)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }






        /// <summary>
        /// First()操作符提交源Observable发射的第一项数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(10);

            interval
                .FirstAsync()
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }


        /// <summary>
        /// Last()操作符与 First() 操作符相反，只提交最后一个数据项给订阅者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(10);

            interval
                .LastAsync()
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }



        /// <summary>
        /// ignoreElements()操作符不提交任何数据给订阅者，只提交终止通知（onError或者onCompeleted）给订阅者，默认不在任何特定的调度器上执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIgnoreElements_Click(object sender, EventArgs e)
        {
            // 每秒1个数据， 共10秒.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(10);

            // IgnoreElements 操作， 则是 10秒后， 只提示结束。
            interval
                .IgnoreElements()
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }



        /// <summary>
        /// 在Observable后面加一个sample()，我们将创建一个新的可观测序列，它将在一个指定的时间间隔里由Observable发射最近一次的数值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSample_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p=>Convert.ToInt32(p));

            // 时间间隔为 5秒.
            TimeSpan ts = new TimeSpan(0, 0, 5);

            interval
                // 只取前60条.
                .Take(60)
                // 按 5 秒进行 Sample
                .Sample(ts)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
            
        }



        /// <summary>
        /// skip(count) 对于源Observable发射的数据项，跳过前count项，将后面的数据项提交给订阅者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSkip_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据. 共取10行.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(10);

            interval
                // 跳过前3个.
                .Skip(3)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }

        /// <summary>
        /// skipLast(count) 对于源Observable发射的数据项，省略最后count项，将前面的数据项提交给订阅者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSkipLast_Click(object sender, EventArgs e)
        {
            // 每秒产生一个数据. 共取10行.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Select(p => Convert.ToInt32(p)).Take(10);

            interval
                // 跳过最后3个.
                .SkipLast(3)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }










        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver : IObserver<int>
        {

            private FormFiltering formItem;


            public MyObserver(FormFiltering formItem)
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



    }
}
