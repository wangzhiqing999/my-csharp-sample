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
    public partial class FormHelloWorld : Form
    {
        public FormHelloWorld()
        {
            InitializeComponent();
        }

        private void btnHelloWorld_Click(object sender, EventArgs e)
        {
            DoHelloWorld();
        }



        private void DoHelloWorld()
        {
            //  IObservable<T>接口表示发送通知 （提供程序）
            IObservable<string> myObservable = Observable.Create((Func<IObserver<string>, IDisposable>)DoJobs);

            // IObserver<T>接口表示接收它们 （观察者） 的类。 
            IObserver<string> myObserver = new HelloWorldObserver(this);


            // 使用这个， 需要 NuGet 添加 System.Reactive.Windows.Forms
            ControlScheduler cs = new ControlScheduler(this);

            myObservable
                // 可观察对象线程，跑在新的线程上.
                .SubscribeOn(NewThreadScheduler.Default)
                // 观察者线程，跑到 WinForm 控件的线程上.
                .ObserveOn(cs)
                .Subscribe(myObserver);

        }



        public IDisposable DoJobs(IObserver<string> ob)
        {            
            for (int i = 0; i < 10; i++)
            {
                string helloworldMsg = String.Format("Hello World ! {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                ob.OnNext(helloworldMsg);
                Thread.Sleep(1000);
            }
            // 完成处理.
            ob.OnCompleted();
            return Disposable.Empty;
        }



        /// <summary>
        /// 观察者类.
        /// </summary>
        class HelloWorldObserver : IObserver<string>
        {

            private FormHelloWorld formHelloWorld;


            public HelloWorldObserver(FormHelloWorld formHelloWorld)
            {
                this.formHelloWorld = formHelloWorld;
            }


            /// <summary>
            /// 通知观察者提供程序已完成发送基于推送的通知。
            /// </summary>
            void IObserver<string>.OnCompleted()
            {
                formHelloWorld.txtResult.AppendText("处理结束！");
                formHelloWorld.txtResult.AppendText("\r\n");
            }


            /// <summary>
            /// 通知观察者提供程序遇到错误情况。
            /// </summary>
            /// <param name="error"></param>
            void IObserver<string>.OnError(Exception error)
            {
                formHelloWorld.txtResult.AppendText("处理过程中发生了异常！");
                formHelloWorld.txtResult.AppendText("\r\n");
            }



            void IObserver<string>.OnNext(string value)
            {
                formHelloWorld.txtResult.AppendText(value);
                formHelloWorld.txtResult.AppendText("\r\n");
            }
        }

    }
    
}
