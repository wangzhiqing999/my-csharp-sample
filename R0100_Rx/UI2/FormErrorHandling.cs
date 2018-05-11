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
    public partial class FormErrorHandling : Form
    {
        public FormErrorHandling()
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



        private void FormErrorHandling_Load(object sender, EventArgs e)
        {
            myObserver = new MyObserver(this);
            uiScheduler = new ControlScheduler(this);
        }



        /// <summary>
        /// Catch - 可观察对象， 发出 OnError 了， 那么，切换到另外一个 可观察对象去. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCatch_Click(object sender, EventArgs e)
        {
            var greeting = Observable.Create<int>(observer =>
            {
                observer.OnNext(1);
                Thread.Sleep(1000);

                observer.OnNext(2);
                Thread.Sleep(2000);

                Exception ex = new Exception("测试 OnError");
                observer.OnError(ex);
                Thread.Sleep(2000);

                observer.OnNext(3);
                Thread.Sleep(3000);

                observer.OnCompleted();
                return Disposable.Empty;
            });


            List<int> errorDataList = new List<int>()
            {
                99997, 99998, 99999
            };
            var err = errorDataList.ToObservable();

            List<int> errorDataList2 = new List<int>()
            {
                88887, 88888, 88888
            };
            var err2 = errorDataList2.ToObservable();


            // Catch 意味着，  可观察对象， 发出 OnError 了， 那么，切换到另外一个 可观察对象去. 
            // 与 OnErrorResumeNext 的区别在于， Catch 只能一个， OnErrorResumeNext 可以多个.
            greeting
                .Catch(err)
                // 这里的  .Catch(err2)， 实际上没有效果.
                .Catch(err2)
                // 可观察对象线程，跑在新的线程上.
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);

        }


        /// <summary>
        /// OnErrorResumeNext - 可观察对象， 发出 OnError 了， 那么，切换到另外一个 可观察对象去. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOnErrorResumeNext_Click(object sender, EventArgs e)
        {
            var greeting = Observable.Create<int>(observer =>
            {
                observer.OnNext(1);
                Thread.Sleep(1000);

                observer.OnNext(2);
                Thread.Sleep(2000);

                Exception ex = new Exception("测试 OnError");
                observer.OnError(ex);
                Thread.Sleep(2000);

                observer.OnNext(3);
                Thread.Sleep(3000);

                observer.OnCompleted();
                return Disposable.Empty;
            });


            List<int> errorDataList = new List<int>()
            {
                99997, 99998, 99999
            };
            var err = errorDataList.ToObservable();


            List<int> errorDataList2 = new List<int>()
            {
                88887, 88888, 88888
            };
            var err2 = errorDataList2.ToObservable();



            // OnErrorResumeNext 意味着，  可观察对象， 发出 OnError 了， 那么，切换到另外 N 个 可观察对象去. 
            // 与 Catch 的区别在于， Catch 只能一个， OnErrorResumeNext 可以多个.
            greeting
                .OnErrorResumeNext(err)
                .OnErrorResumeNext(err2)
                // 可观察对象线程，跑在新的线程上.
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }



        /// <summary>
        /// retry的意思就是试着重来，
        /// 当原始Observable发射onError通知时，retry操作符不会让onError通知传递给观察者，
        /// 它会重新订阅这个Observable一次或者多次(意味着重新从头发射数据)，所以可能造成数据项重复发送的情况。 
        /// 
      /// 如果重新订阅了指定的次数还是发射了onError通知，将不再尝试重新订阅，它会把最新的一个onError通知传递给观察者。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetry_Click(object sender, EventArgs e)
        {
            var greeting = Observable.Create<int>(observer =>
            {
                observer.OnNext(1);
                Thread.Sleep(1000);

                observer.OnNext(2);
                Thread.Sleep(2000);

                Exception ex = new Exception("测试 OnError");
                observer.OnError(ex);
                Thread.Sleep(2000);

                observer.OnNext(3);
                Thread.Sleep(3000);

                observer.OnCompleted();
                return Disposable.Empty;
            });


            // 这里测试 Retry 3次
            greeting
                .Retry(3)
                // 可观察对象线程，跑在新的线程上.
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(uiScheduler)
                .Subscribe(this.myObserver);
        }






        /// <summary>
        /// 观察者类.
        /// </summary>
        class MyObserver : IObserver<int>
        {

            private FormErrorHandling formItem;


            public MyObserver(FormErrorHandling formItem)
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
