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
    public partial class FormAll : Form
    {
        public FormAll()
        {
            InitializeComponent();
        }

        private void FormAll_Load(object sender, EventArgs e)
        {
            // 获取可观测对象.
            var aEventStream = this.btnTest.FromClickEventPattern().Select(_ => DateTime.Now);

            aEventStream
                // All(p=>p.Second < 30) = 当秒小于30时，全部跳过， 大于等于30时， 结束处理. （也就是仅仅处理一次，就结束了）
                .All(p => p.Second < 30)
                .Subscribe(x => lblResult.Text = x.ToString());
        }
    }
}
