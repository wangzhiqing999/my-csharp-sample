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

namespace WPF_0120_Async
{
    /// <summary>
    /// Page002_IsAsync.xaml 的交互逻辑
    /// </summary>
    public partial class Page002_IsAsync : Page
    {
        public Page002_IsAsync()
        {
            InitializeComponent();
        }
    }




    /// <summary>
    /// 用于测试 异步绑定的数据类.
    /// </summary>
    public class AsyncDataSource
    {
        private string _fastDP;
        private string _slowerDP;
        private string _slowestDP;

        public AsyncDataSource()
        {
        }


        /// <summary>
        /// 比较快可以获取到的数据
        /// </summary>
        public string FastDP
        {
            get { return _fastDP; }
            set { _fastDP = value; }
        }



        /// <summary>
        /// 比较慢可以获取到的数据
        /// </summary>
        public string SlowerDP
        {
            get
            {
                // This simulates a lengthy time before the
                // data being bound to is actualy available.
                System.Threading.Thread.Sleep(3000);
                return _slowerDP;
            }
            set { _slowerDP = value; }
        }



        /// <summary>
        /// 最慢可以获取到的数据
        /// </summary>
        public string SlowestDP
        {
            get
            {
                // This simulates a lengthy time before the
                // data being bound to is actualy available.
                System.Threading.Thread.Sleep(5000);
                return _slowestDP;
            }
            set { _slowestDP = value; }
        }
    }



}
