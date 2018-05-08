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


namespace R0100_Rx.UI
{
    public partial class FormNewObservable : Form
    {
        public FormNewObservable()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Return可以创建一个具体的IObservable<T>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("########## Observable.Return ##########");

            var greeting = Observable.Return("Hello world (by Observable.Return)");
            greeting.Subscribe(Console.WriteLine);

        }


        /// <summary>
        /// Create可以创建一个IObservable<T>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            Console.WriteLine("########## Observable.Create ##########");

            var greeting = Observable.Create<string>(observer =>
            {
                observer.OnNext("Hello world (by Observable.Create)");
                return Disposable.Create(() => Console.WriteLine("Observer has unsubscribed"));
            });

            greeting.Subscribe(Console.WriteLine);
        }



        /// <summary>
        /// Range方法可以产生一个指定范围内的IObservable<T>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRange_Click(object sender, EventArgs e)
        {
            Console.WriteLine("########## Observable.Range ##########");

            var range = Observable.Range(1, 10);

            range.Subscribe(Console.WriteLine);
        }



        /// <summary>
        /// Generate 方法是一个折叠操作的逆向操作，又称Unfold方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Console.WriteLine("########## Observable.Generate ##########");

            var range = Observable.Generate(0, x => x < 10, x => x + 2, x => x);

            range.Subscribe(Console.WriteLine);
        }


        /// <summary>
        /// Interval方法可以每隔一定时间产生一个IObservable<T>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInterval_Click(object sender, EventArgs e)
        {
            Console.WriteLine("########## Observable.Interval ##########");

            var interval = Observable.Interval(TimeSpan.FromSeconds(5));

            // 这里写的很简单，一运行就停不下来了...
            interval.Subscribe(Console.WriteLine);
        }




    }
}
