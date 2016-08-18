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
using System.ComponentModel;



namespace WPF_0120_Async
{
    /// <summary>
    /// Page003_PropertyChanged.xaml 的交互逻辑
    /// </summary>
    public partial class Page003_PropertyChanged : Page
    {

        /// <summary>
        /// 测试的消息
        /// </summary>
        private List<SmsData> mainDataList = new List<SmsData>()
        {
            new SmsData() { Phone = "13000000000", Result=0},
            new SmsData() { Phone = "13000000001", Result=0},
            new SmsData() { Phone = "13000000002", Result=0},
            new SmsData() { Phone = "13000000003", Result=0},
            new SmsData() { Phone = "13000000004", Result=0},
            new SmsData() { Phone = "13000000005", Result=0},
            new SmsData() { Phone = "13000000006", Result=0},
            new SmsData() { Phone = "13000000007", Result=0},
            new SmsData() { Phone = "13000000008", Result=0},
            new SmsData() { Phone = "13000000009", Result=0},
        };




        public Page003_PropertyChanged()
        {
            InitializeComponent();
            this.dgPhoneList.ItemsSource = this.mainDataList;
        }



        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {

                // 单纯为了演示， 在线程中，修改画面控件上面的数据.
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    this.btnSend.IsEnabled = false;
                }));


                // 表格中的数据变更， 通过 INotifyPropertyChanged 实现.
                // 代码只需要变更数据即可， 不需要  变更完数据后， 再去手动修改 画面上面的数据。
                foreach (SmsData data in mainDataList)
                {
                    MockSendSms(data);
                }


                // 单纯为了演示， 在线程中，修改画面控件上面的数据.
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    this.btnSend.IsEnabled = true;
                }));


            }).Start();
        }







        private int tmpIndex = 1;

        /// <summary>
        /// 模拟发送短消息.
        /// </summary>
        /// <param name="smsData"></param>
        public void MockSendSms(SmsData smsData)
        {
            Thread.Sleep(1000);

            smsData.Result = 1;
            smsData.Msgid = String.Format("{0:0000000000}", tmpIndex++);
        }


    }






    /// <summary>
    /// 通过设置 INotifyPropertyChanged.
    /// 对于画面绑定的数据。
    /// 
    /// 在主画面多线程处理的过程中，不需要 
    /// this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
    /// 的方式去 修改画面控件的数值。
    /// 
    /// </summary>
    public class SmsData : INotifyPropertyChanged
    {
        /// <summary>
        /// 手机.
        /// </summary>
        public string Phone { set; get; }



        private int m_Result;

        /// <summary>
        /// 发送结果.
        /// </summary>
        public int Result
        {
            set
            {
                m_Result = value;
                this.OnPropertyChanged("Result");

            }
            get
            {
                return m_Result;
            }
        }



        private string m_Msgid;

        /// <summary>
        /// 消息ID.
        /// </summary>
        public string Msgid
        {
            set
            {
                m_Msgid = value;
                this.OnPropertyChanged("Msgid");
            }
            get
            {
                return m_Msgid;
            }
        }


        public string CsvLine
        {
            get
            {
                return String.Format("{0},{1},{2}", this.Phone, this.Result, this.Msgid);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }


}
