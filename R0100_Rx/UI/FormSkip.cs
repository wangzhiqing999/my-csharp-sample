using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Reactive.Concurrency;

using R0100_Rx.Service;



namespace R0100_Rx.UI
{
    public partial class FormSkip : Form
    {
        public FormSkip()
        {
            InitializeComponent();
        }

        private void FormSkip_Load(object sender, EventArgs e)
        {
            // 获取可观测对象.
            var aEventStream = this.btnTest.FromClickEventPattern().Select(_ => "触发事件@" + DateTime.Now.ToString("HH:mm:ss"));


            aEventStream
                // Skip(5) = 忽略前5个. 后续的正常处理.
                .Skip(5)
                .Subscribe(x => lblResult.Text = x.ToString());
        }
    }
}
