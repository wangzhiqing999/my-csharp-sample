using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Windows.Interop;


namespace SL_0010_HelloWorld
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();


            List<string> dataList = new List<string>()
            {
                "测试1",
                "测试2",
                "测试3",
                "测试4",
                "测试5",
            };
            this.cboTest.ItemsSource = dataList;




            List<string> dataList2 = new List<string>()
            {
                "测试6",
                "测试7",
                "测试8",
                "测试9",
                "测试10",
            };
            this.lstTest.ItemsSource = dataList2;
        }



        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("控件选择的日期 = " + calTest.SelectedDate, "测试", MessageBoxButton.OK);
        }

        private void btnTest2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("控件选择的日期 = " + dpTest.SelectedDate, "测试", MessageBoxButton.OK);
        }


        /// <summary>
        /// 全屏显示.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFullScreen_Click(object sender, RoutedEventArgs e)
        {
            Content contentObj = Application.Current.Host.Content;
            contentObj.IsFullScreen = !contentObj.IsFullScreen;

            if (contentObj.IsFullScreen)
            {
                btnFullScreen.Content = "退出全屏";
            }
            else
            {
                btnFullScreen.Content = "全屏显示";
            }
        }
    }
}
