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

using WPF_0110_Template.Model;

namespace WPF_0110_Template
{
    /// <summary>
    /// Page012_MultiDataTrigger.xaml 的交互逻辑
    /// </summary>
    public partial class Page012_MultiDataTrigger : Page
    {
        public Page012_MultiDataTrigger()
        {
            InitializeComponent();


            InitData();
        }



        private void InitData()
        {
            List<Student> dataList = new List<Student>()
            {
                new Student() {ID= 1, Name="Tom", Age=20},
                new Student() {ID= 2, Name="Tom", Age=21},
                new Student() {ID= 3, Name="Jac", Age=22},
                new Student() {ID= 4, Name="Jason", Age=23},
                new Student() {ID= 5, Name="Kiki", Age=24},
                new Student() {ID= 2, Name="Kiki", Age=25},
            };

            this.listBoxStudent.ItemsSource = dataList;
        }

    }
}
