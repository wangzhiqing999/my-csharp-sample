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

namespace WPF_0080_RoutedEvent
{
    /// <summary>
    /// Page001_Bubble.xaml 的交互逻辑
    /// </summary>
    public partial class Page001_Bubble : Page
    {
        public Page001_Bubble()
        {
            InitializeComponent();
        }



        private void ReportTimeHandler(object sender, ReportTimeEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            string timeStr = e.ClickTime.ToLongTimeString();
            string content = String.Format("{0} 到达 {1}", timeStr, element.Name);
            this.listBox.Items.Add(content);
        }


    }
}
