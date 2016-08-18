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


using WPF_0070_Binding.Converter;


namespace WPF_0070_Binding
{
    /// <summary>
    /// Page012_Converter.xaml 的交互逻辑
    /// </summary>
    public partial class Page012_Converter : Page
    {
        public Page012_Converter()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 加载数据.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            List<Plane> planeList = new List<Plane>()
            {
                new Plane() { Category= Category.Bomber, Name="B-1", State = State.Unknown},
                new Plane() { Category= Category.Bomber, Name="B-2", State = State.Unknown},
                new Plane() { Category= Category.Bomber, Name="B-52", State = State.Unknown},

                new Plane() { Category= Category.Fighter, Name="F-22", State = State.Unknown},
                new Plane() { Category= Category.Fighter, Name="Su-47", State = State.Unknown},
                new Plane() { Category= Category.Fighter, Name="J-10", State = State.Unknown},
            };

            this.listBoxPlane.ItemsSource = planeList;
        }


        /// <summary>
        /// 保存.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Plane p in listBoxPlane.Items)
            {
                sb.AppendLine(string.Format("Category={0}, Name={1}, State={2}", p.Category, p.Name, p.State));
            }
            System.IO.File.WriteAllText("PlaneList.txt", sb.ToString());
        }
    }
}
