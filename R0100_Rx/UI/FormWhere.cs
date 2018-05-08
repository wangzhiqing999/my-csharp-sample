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
    public partial class FormWhere : Form
    {
        public FormWhere()
        {
            InitializeComponent();
        }

        private void FormWhere_Load(object sender, EventArgs e)
        {
            // 获取可观测对象.
            var aEventStream = this.btnTest.FromClickEventPattern().Select(_ => DateTime.Now);


            aEventStream
                // .Where(p=>p.Second %2 == 0)  仅仅处理 秒为偶数的请求.
                .Where(p=>p.Second %2 == 0)
                .Subscribe(x => lblResult.Text = x.ToString());
        }
    }
}
