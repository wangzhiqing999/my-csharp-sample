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
    public partial class FormTakeWhile : Form
    {
        public FormTakeWhile()
        {
            InitializeComponent();
        }

        private void FormTakeWhile_Load(object sender, EventArgs e)
        {
            // 获取可观测对象.
            var aEventStream = this.btnTest.FromClickEventPattern().Select(_ => DateTime.Now);

            aEventStream
                // TakeWhile(p=>p.Second > 5) = 当秒大于5时，继续接受处理，当秒小于5时，结束处理。
                .TakeWhile(p=>p.Second > 5)
                .Subscribe(x => lblResult.Text = x.ToString());

        }
    }
}
