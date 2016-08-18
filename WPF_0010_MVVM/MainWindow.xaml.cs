using System.Windows;
using WpfApplication1.ViewModel;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = new MainWindowViewModel();
        }
    }
}
