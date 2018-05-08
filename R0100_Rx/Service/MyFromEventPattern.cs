using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Reactive.Concurrency;



namespace R0100_Rx.Service
{
    public static class MyFromEventPattern
    {

        /// <summary>
        /// 给按钮追加一个 FromClickEventPattern 方法，获取 单击 事件的可观察者.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static IObservable<EventPattern<EventArgs>> FromClickEventPattern(this Button button)
        {
            return Observable.FromEventPattern<EventArgs>(button, "Click");
        }


        /// <summary>
        /// 给按钮追加一个 FromDoubleClickEventPattern 方法，获取 双击 事件的可观察者.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static IObservable<EventPattern<EventArgs>> FromDoubleClickEventPattern(this Button button)
        {
            return Observable.FromEventPattern<EventArgs>(button, "DoubleClick");
        }


    }
}
