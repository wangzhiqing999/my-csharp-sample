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

using WPF_0110_Template.Converter;

namespace WPF_0110_Template
{
    /// <summary>
    /// Page001_DataTemplate.xaml 的交互逻辑
    /// </summary>
    public partial class Page001_DataTemplate : Page
    {
        public Page001_DataTemplate()
        {
            InitializeComponent();


            InitData();
        }


        private void InitData()
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

            this.listBoxTest.ItemsSource = planeList;
        }
    }
}
