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
        /// Where 只会返回满足过滤条件的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWhere_Click(object sender, EventArgs e)
        {
            var range = Observable.Range(1, 10);

            range
                .Where(p=>p % 2 == 0)
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




        private void btnFirst_Click(object sender, EventArgs e)
        {
            var range = Observable.Range(1, 10);

            range
                .FirstAsync()
                .Subscribe(this.myObserver);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            var range = Observable.Range(1, 10);

            range
                .LastAsync()
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
                formItem.txtResult.AppendText("\r\n");
            }
        }













    }
}
