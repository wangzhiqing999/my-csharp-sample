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

namespace WPF_0100_Resource
{
    /// <summary>
    /// Page003_PropertiesResources.xaml 的交互逻辑
    /// </summary>
    public partial class Page003_PropertiesResources : Page
    {
        public Page003_PropertiesResources()
        {
            InitializeComponent();

            // 资源信息， 在项目上右键， 属性。  然后在资源窗口的 属性 Tab 上面进行添加/修改操作.
            // 最终数据会被存储到 Resources.resx 文件当中。


            this.textBlockPassword.Text = Properties.Resources.Password;
        }
    }
}
