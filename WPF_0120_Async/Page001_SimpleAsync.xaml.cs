using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using System.Threading;
using System.Windows.Threading;


namespace WPF_0120_Async
{
    /// <summary>
    /// Page001_SimpleAsync.xaml 的交互逻辑
    /// </summary>
    public partial class Page001_SimpleAsync : Page
    {
        public Page001_SimpleAsync()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 测试 耗时操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            // 异步处理开始时的操作.
            this.UpdateUIWhenStartFetchingWeather();



            //异步任务封装在一个delegate中, 此delegate将运行在后台线程 
            Func<string> asyncAction = this.FetchWeatherFromInternet;


            //在UI线程中得到异步任务的返回值，并更新UI
            //必须在UI线程中执行 
            Action<IAsyncResult> resultHandler = delegate(IAsyncResult asyncResult)
            {
                string weather = asyncAction.EndInvoke(asyncResult);
                this.UpdateUIWhenWeatherFetched(weather);
            };

            //异步任务执行完毕后的callback, 此callback运行在后台线程上. 
            //此callback会异步调用resultHandler来处理异步任务的返回值.
            AsyncCallback asyncActionCallback = delegate(IAsyncResult asyncResult)
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Background, resultHandler, asyncResult);
            };

            //在UI线程中开始异步任务, 
            //asyncAction(后台线程), asyncActionCallback(后台线程)和resultHandler(UI线程)
            //将被依次执行
            asyncAction.BeginInvoke(asyncActionCallback, null);

        }






        /// <summary>
        /// 实际调用 耗时处理的代码.  (将在后台异步执行)
        /// </summary>
        /// <returns></returns>
        private string FetchWeatherFromInternet()
        {
            // Simulate the delay from network access.
            Thread.Sleep(4000);
            String weather = "rainy";
            return weather;
        }



        /// <summary>
        /// 异步处理开始时的操作.
        /// </summary>
        private void UpdateUIWhenStartFetchingWeather()
        {
            // Change the status
            this.btnTest.IsEnabled = false;
            this.tbResult.Text = "正在下载数据中......";
        }


        /// <summary>
        /// 异步处理结束时的操作.
        /// </summary>
        /// <param name="weather"></param>
        private void UpdateUIWhenWeatherFetched(string weather)
        {
            //Update UI text
            this.btnTest.IsEnabled = true;
            this.tbResult.Text = weather;
        }

    }
}
