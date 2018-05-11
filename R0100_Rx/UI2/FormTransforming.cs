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
    public partial class FormTransforming : Form
    {
        public FormTransforming()
        {
            InitializeComponent();
        }



        /// <summary>
        /// IObserver<T>接口表示接收它们 （观察者） 的类。 
        /// </summary>
        private IObserver<int> myObserver;

        private IObserver<IList<int>> myObserver2;

        private IObserver<IGroupedObservable<int, int>> myObserver3;

        private IObserver<IObservable<int>> myObserver4;


        /// <summary>
        /// UI 画面，使用的线程.
        /// </summary>
        private IScheduler uiScheduler;



        private void FormTransforming_Load(object sender, EventArgs e)
        {
            myObserver = new MyObserver(this);
            myObserver2 = new MyObserver2(this);
            myObserver3 = new MyObserver3(this);
            myObserver4 = new MyObserver4(this);


            uiScheduler = new ControlScheduler(this);            
        }



        /// <summary>
        /// .Buffer(count: 3)
        /// 意味着，每次打包发送3个数据。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuffer_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10).Select(p => Convert.ToInt32(p + 1));

            interval
                .Buffer(count: 3)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver2);
        }


        /// <summary>
        /// .Buffer(count: 2, skip: 3)
        /// 意味着，每次打包发送2个数据，每次发射一个集合需要跳过几个数据。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBufferSkip_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10).Select(p => Convert.ToInt32(p + 1));

            interval
                .Buffer(count: 2, skip: 3)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver2);
        }



        /// <summary>
        /// GroupBy操作符将原始Observable发射的数据按照key来拆分成一些小的Observable，
        /// 然后这些小的Observable分别发射其所包含的的数据，类似于sql里面的groupBy。
        /// 
        /// 在使用中，我们需要提供一个生成key的规则，所有key相同的数据会包含在同一个小的Observable种。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGroupBy_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10).Select(p => Convert.ToInt32(p + 1));

            interval
                // 这里取 Key 的规则，是 除 2 的余数.
                .GroupBy(p => p % 2)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver3);
        }




        /// <summary>
        /// Scan操作符对一个序列的数据应用一个函数，并将这个函数的结果发射出去作为下个数据应用这个函数时候的第一个参数使用，有点类似于递归操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScan_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10).Select(p => Convert.ToInt32(p + 1));

            interval
                .Scan(0, DoMyWork)
                .Subscribe(this.myObserver);
        }

        private int DoMyWork(int result, int s)
        {
            return result + s;
        }



        /// <summary>
        /// C# 当中是 SelectMany 
        /// http://reactivex.io 文档中， 是 flatMap
        /// 
        /// flatMap操作符用于发射的一个数据序列，而这些数据同时本身拥有发射Observable。
        /// flatMap是以铺平序列的方式，然后合并这些Observables发射的数据，最后将合并后的结果作为最终的Observable。
        /// 但是，flatMap()可能交错的发送事件，最终结果的顺序可能并是不原始Observable发送时的顺序。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectMany_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(5)).Take(3)
                .Select(p => { Console.WriteLine("### interval {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32(p); });

            var interva2 = Observable.Interval(TimeSpan.FromSeconds(1)).Take(3)
                .Select(p => { Console.WriteLine("### interva2 {0} @ {1:yyyy-MM-dd HH:mm:ss}", p, DateTime.Now); return Convert.ToInt32( (p+1) * 10); });

            // 本例子为了显示效果
            // 主的 Observable 间隔时间为 5秒， 共3次。
            // 转换后的 Observable 间隔时间为 1秒， 共3次。
            // 转换后没有发生交错。
            interval
                .SelectMany(interva2)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

            

            // 这里的处理， 与 组合操作中的  Switch 有点相似的地方。
            // 区别在于
            //     flatMap/SelectMany  不会丢弃上一组 未发送的数据.
            //     Switch 则是会丢弃上一组 未发送的数据.
            // 假如数据和本例子一样
            //     主的 Observable 间隔时间为 5秒， 共3次。 转换后的 Observable 间隔时间为 1秒， 共3次。  转换后没有发生交错。
            //     那么。执行的结果，是一样的。

        }




        /// <summary>
        /// C# 当中是 Select
        /// http://reactivex.io 文档中， 是 Map
        /// 
        /// 很基本的操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Take(5)
               .Select(p => Convert.ToInt32(p + 10));


            interval
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

        }




        /// <summary>
        /// window操作符与Buffer操作符类似，但是它发射的是Observable而不是列表。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWindow_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10).Select(p => Convert.ToInt32(p + 1));

            interval
                .Window(count: 3)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver4);
        }


        /// <summary>
        /// window操作符与Buffer操作符类似，但是它发射的是Observable而不是列表。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWindowSkip_Click(object sender, EventArgs e)
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10).Select(p => Convert.ToInt32(p + 1));

            interval
                .Window(count: 2, skip:3)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver4);
        }







        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver : IObserver<int>
        {

            private FormTransforming formItem;


            public MyObserver(FormTransforming formItem)
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

            private FormTransforming formItem;


            public MyObserver2(FormTransforming formItem)
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
                formItem.txtResult.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                formItem.txtResult.AppendText("\r\n");
            }
        }


        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver3 : IObserver<IGroupedObservable<int, int>>
        {

            private FormTransforming formItem;


            public MyObserver3(FormTransforming formItem)
            {
                this.formItem = formItem;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<IGroupedObservable<int, int>>.OnCompleted()
            {
                formItem.txtResult.AppendText("处理结束！");
                formItem.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<IGroupedObservable<int, int>>.OnError(Exception error)
            {
                formItem.txtResult.AppendText("处理过程中发生了异常！");
                formItem.txtResult.AppendText("\r\n");
            }



            void IObserver<IGroupedObservable<int, int>>.OnNext(IGroupedObservable<int, int> value)
            {
                formItem.txtResult.AppendText("Key = " + value.Key + "(只处理 Key=0 的明细)");
                formItem.txtResult.AppendText("\r\n");
                if (value.Key == 0)
                {
                    value
                        // 观察者线程，跑到 WinForm 控件的线程上.
                        .ObserveOn(this.formItem.uiScheduler)
                        .Subscribe(this.formItem.myObserver);
                }
            }


        }



        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver4 : IObserver<IObservable<int>>
        {

            private FormTransforming formItem;


            public MyObserver4(FormTransforming formItem)
            {
                this.formItem = formItem;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<IObservable<int>>.OnCompleted()
            {
                formItem.txtResult.AppendText("处理结束！");
                formItem.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<IObservable<int>>.OnError(Exception error)
            {
                formItem.txtResult.AppendText("处理过程中发生了异常！");
                formItem.txtResult.AppendText("\r\n");
            }



            void IObserver<IObservable<int>>.OnNext(IObservable<int> value)
            {
                formItem.txtResult.AppendText("# OnNext 执行！");
                formItem.txtResult.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                formItem.txtResult.AppendText("\r\n");

                value
                    // 观察者线程，跑到 WinForm 控件的线程上.
                    .ObserveOn(this.formItem.uiScheduler)
                    .Subscribe(this.formItem.myObserver);
            }
        }









    }
}
