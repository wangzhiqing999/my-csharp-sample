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
    public partial class FormMerge : Form
    {
        public FormMerge()
        {
            InitializeComponent();
        }



        private void FormMerge_Load(object sender, EventArgs e)
        {

            // 获取数值增加的 可观测对象.
            var addEventStream = this.btnAdd.FromClickEventPattern().Select(_ => 1);

            // 获取数值减少的 可观测对象.
            var subEventStream = this.btnSub.FromClickEventPattern().Select(_ => -1);

            // 获取重置的 可观测对象.
            var resetEventStream = this.btnReset.FromClickEventPattern().Select(_ => 0);


            // 多个可观测对象. 使用 Merge 进行合并.
            var allEventStream = addEventStream.Merge(subEventStream).Merge(resetEventStream);


            // Scan稍显复杂，对事件流做了一个折叠操作，给定了一个初始值，并通过一个函数来对结果和下一个值进行计算处理.
            allEventStream
                .Scan(0, DoMyWork)                
                .Subscribe(x => lblResult.Text = x.ToString());

        }


        private int DoMyWork(int result, int s)
        {
            if (s == 0)
            {
                return 0;
            }
            return result + s;
        }



    }
}
