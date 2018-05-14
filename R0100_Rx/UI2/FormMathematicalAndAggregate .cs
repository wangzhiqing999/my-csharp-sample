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
    public partial class FormMathematicalAndAggregate : Form
    {
        public FormMathematicalAndAggregate()
        {
            InitializeComponent();
        }


        /// <summary>
        /// IObserver<T>接口表示接收它们 （观察者） 的类。 
        /// </summary>
        private IObserver<int> myObserver;
        private IObserver<double> myObserver2;


        /// <summary>
        /// UI 画面，使用的线程.
        /// </summary>
        private IScheduler uiScheduler;


        private void FormMathematicalAndAggregate_Load(object sender, EventArgs e)
        {
            myObserver = new MyObserver(this);
            myObserver2 = new MyObserver2(this);
            uiScheduler = new ControlScheduler(this);
        }


        /// <summary>
        /// Average 计算Observable的发射数字的平均值。
        /// 
        /// Average操作符操作符一个发射数字的Observable，并发射单个值：原始Observable发射的数字序列的平均值。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAverage_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p + 1); }).Take(10);

            // 这里取平均值.
            interval
                .Average()
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver2);
        }


        /// <summary>
        /// 不交错的发射两个或多个Observable的发射物。
        /// Concat操作符连接多个Observable的输出，就好像它们是一个Observable，第一个Observable发射的所有数据在第二个Observable发射的任何数据前面，以此类推。直到前面一个Observable终止，Concat才会订阅额外的一个Observable。
        /// 
        /// 
        /// Merge操作符的功能，与 Concat操作符差不多，它结合两个或多个Observable的发射物，但是数据可能交错，而Concat不会让多个Observable的发射物交错。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConcat_Click(object sender, EventArgs e)
        {
            // 0-4  共5个数字.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(5);

            // 0-40  共5个数字.
            var interval2 = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p * 10); }).Take(5);


            interval
                .Concat(interval2)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);


        }


        /// <summary>
        /// 计算Observable所发射的数据的数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCount_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p + 1); }).Take(10);

            interval
                .Count()
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }



        /// <summary>
        /// 发射的observable中的最大值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMax_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p + 1); }).Take(10);

            interval
                .Max()
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }


        /// <summary>
        /// 发射的observable中的最小值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMin_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p + 1); }).Take(10);

            interval
                .Min()
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }



        /// <summary>
        /// C# 当中是 Aggregate 
        /// http://reactivex.io 文档中， 是 Reduce
        /// 
        /// 按顺序对Observable发射的每项数据应用一个函数并发射最终的值。
        /// Reduce操作符对原始Observable发射数据的第一项应用一个函数，
        /// 然后再将这个函数的返回值与第二项数据一起传递给函数，以此类推，
        /// 持续这个过程知道原始Observable发射它的最后一项数据并终止，此时Reduce返回的Observable发射这个函数返回的最终值。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReduce_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p + 1); }).Take(10);

            interval
                .Aggregate(DoAggregateFunc)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

            
        }

        private int DoAggregateFunc(int x, int y)
        {
            int result = x + y;
            Console.WriteLine("Call DoAggregateFunc ( {0},  {1} ),  return {2}", x, y, result);
            return result;
        }


        /// <summary>
        /// Reduce 与 Scan。
        /// 参数 与 处理逻辑， 看上去基本一样。
        /// 区别在于， Reduce 只会发射一个  最终的结果。
        /// Scan 是每计算一次， 发射一次。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScan_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p + 1); }).Take(10);

            interval
                .Scan(DoAggregateFunc)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }






        /// <summary>
        /// Observable所发射的数据的和.
        /// Sum操作符操作一个发射数值的Observable，仅发射单个值：原始Observable所有数值的和。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSum_Click(object sender, EventArgs e)
        {
            // 0-9  共10个数字.
            var interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); }).Take(10);

            interval
                .Sum()
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }



        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver : IObserver<int>
        {

            private FormMathematicalAndAggregate formItem;


            public MyObserver(FormMathematicalAndAggregate formItem)
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
        class MyObserver2 : IObserver<double>
        {

            private FormMathematicalAndAggregate formItem;


            public MyObserver2(FormMathematicalAndAggregate formItem)
            {
                this.formItem = formItem;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<double>.OnCompleted()
            {
                formItem.txtResult.AppendText("处理结束！");
                formItem.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<double>.OnError(Exception error)
            {
                formItem.txtResult.AppendText("处理过程中发生了异常！");
                formItem.txtResult.AppendText("\r\n");
            }



            void IObserver<double>.OnNext(double value)
            {
                formItem.txtResult.AppendText(value.ToString());
                formItem.txtResult.AppendText(" ");
                formItem.txtResult.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                formItem.txtResult.AppendText("\r\n");
            }
        }








    }
}
