using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5070_CheckAbleComboBox.UI
{

    /// <summary>
    /// 可以 Check 的 ComboBox
    /// </summary>
    public partial class ComboBoxEx : ComboBox
    {
        #region 内部变量.

        /// <summary>
        /// 用于区分画面上多个选择项目的分割字符.
        /// </summary>
        private static char DivCahr = ',';


        /// <summary>
        /// 当控件下拉列表打开以后.
        /// 实际显示的控件.
        /// </summary>
        private CheckedListBox lst = new CheckedListBox();

        /// <summary>
        /// 最后的失去焦点的时间
        /// </summary>
        private DateTime lastLostFocusDateTime = DateTime.Now;


        /// <summary>
        /// CheckedListBox 控件的显示模式.
        /// </summary>
        private enum CheckedListBoxShowMode
        {
            // 隐藏模式.
            Hide,

            // 显示模式.
            Show,

            // 失去输入焦点模式.
            LostFocus
        };


        /// <summary>
        /// 控件显示标志.
        /// </summary>
        private CheckedListBoxShowMode lstShowFlag = CheckedListBoxShowMode.Hide;


        /// <summary>
        /// 所有的 可选数据列表.
        /// </summary>
        private List<string> checkAbleItemList = new List<string>();


        /// <summary>
        /// 已选择数据列表.
        /// </summary>
        private List<string> checkItemList = new List<string>();


        #endregion 内部变量.





        public ComboBoxEx()
        {
            // 不允许用户直接输入信息.
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            // 只有设置这个属性为OwnerDrawFixed才可能让重画起作用
            this.DrawMode = DrawMode.OwnerDrawFixed;

            // CheckedListBox 控件只要 点一次， 就选择上了
            lst.CheckOnClick = true;

            // 当 CheckedListBox 的选择发生变化的时候，需要作的处理。
            lst.ItemCheck += new ItemCheckEventHandler(lst_ItemCheck);

            // 当 CheckedListBox 失去焦点的时候，需要作的处理.
            lst.LostFocus += new EventHandler(lst_LostFocus);
        }






        #region 属性




        [Description("可选择数据列表"), Category("Data")]
        public List<string> CheckAbleItemList
        {
            set { checkAbleItemList = value; }
            get { return checkAbleItemList; }
        }



        [Description("选定项的值"), Category("Data")]
        public List<string> CheckedItemList
        {
            set { checkItemList = value; }
            get { return checkItemList; }
        }


        #endregion





        #region 覆盖基类方法.


        /// <summary>
        /// 按下鼠标
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.DroppedDown = false;
        }


        /// <summary>
        /// 放开鼠标
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.DroppedDown = false;
            lst.Focus();
        }


        /// <summary>
        /// 打开选项列表，刷新下来菜单
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDropDown(EventArgs e)
        {
            if (lst.Items.Count == 0)
            {
                // 假如数据还没有加载
                // 那么加载.

                lst.BeginUpdate();
                for (int i = 0; i < this.CheckAbleItemList.Count; i++)
                {
                    lst.Items.Add(this.CheckAbleItemList[i]);
                }
                lst.EndUpdate();

                lst.ItemHeight = this.ItemHeight;
                lst.BorderStyle = BorderStyle.FixedSingle;
                lst.Size = new Size(this.DropDownWidth, this.ItemHeight * (this.MaxDropDownItems - 1) - (int)this.ItemHeight / 2);
                lst.Location = new Point(this.Left, this.Top + this.ItemHeight + 6);

                this.Parent.Controls.Add(lst);

                // 加这句话的目的， 是为了避免 控件被别的控件挡住.
                lst.BringToFront();
            }

            if (lstShowFlag == CheckedListBoxShowMode.Hide)
            {
                // 当前未显示，调整为显示.
                lst.Show();
                lst.Focus();

                lstShowFlag = CheckedListBoxShowMode.Show;
            }
            else if (lstShowFlag == CheckedListBoxShowMode.Show)
            {
                // 当前已显示，调整为不显示.
                lst.Hide();
                lstShowFlag = CheckedListBoxShowMode.Hide;
            }
            else if (lstShowFlag == CheckedListBoxShowMode.LostFocus)
            {
                // 当前是 CheckedListBox 失去输入焦点.

                // 对于失去焦点的情况.
                // 需要作判断
                // 因为 可能是点到其它的控件，而  CheckedListBox 失去输入焦点.
                // 也可能是 直接从 CheckedListBox 点到本控件.

                if (DateTime.Now.AddMilliseconds(-250) > lastLostFocusDateTime)
                {
                    // 如果 CheckedListBox 失去焦点的时间
                    // 与本次点击下拉列表的时间
                    // 间隔超过 250 毫秒
                    // 认为是 经过了另外一个控件.
                    // 现在点击回来了，需要显示.
                    lst.Show();
                    lst.Focus();

                    lstShowFlag = CheckedListBoxShowMode.Show;
                }
                else
                {
                    // 是直接从 CheckedListBox 失去焦点
                    // 然后再点击了 本 ComboBox 控件.
                    lstShowFlag = CheckedListBoxShowMode.Hide;
                }
            }
        }




        /// <summary>
        /// 在 this.DropDownStyle = ComboBoxStyle.DropDownList 模式下
        /// 手动绘制 选项数据.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (this.Items.Count > 0)
            {
                Rectangle rectangle = new Rectangle(
                 2, e.Bounds.Top + 2,
                  e.Bounds.Height, e.Bounds.Height - 4);
                e.Graphics.DrawString(
                 this.Items[0].ToString(),
                 this.Font,
                 System.Drawing.Brushes.Black,
                 new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y,
                  e.Bounds.Width, e.Bounds.Height));
            }
        }


        #endregion





        #region CheckedListBox 控件 事件处理.


        /// <summary>
        /// 当 CheckedListBox 的选择发生变化的时候，需要作的处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lst_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked
             && e.NewValue == CheckState.Checked)
            {
                // 原先未选择
                // 现在选择了.
                CheckedItemList.Add(this.CheckAbleItemList[e.Index]);
            }
            else if (e.CurrentValue == CheckState.Checked
             && e.NewValue == CheckState.Unchecked)
            {
                // 原先已选择.
                // 现在未选择.
                CheckedItemList.Remove(this.CheckAbleItemList[e.Index]);
            }
            // 用户选择的数据缓冲.
            StringBuilder buff = new StringBuilder();

            // 遍历 已 Checked 数据列表.
            for (int i = 0; i < CheckedItemList.Count; i++)
            {
                if (i > 0)
                {
                    // 第1个单元以后的处理，需要加分割符号.
                    buff.Append(DivCahr);
                }
                // 加入初始内容.
                buff.Append(CheckedItemList[i].ToString());
            }
            // 设置本控件的 显示数据.
            this.Items.Clear();
            this.Items.Add(buff.ToString());
            this.SelectedIndex = 0;
            this.Text = buff.ToString();
        }


        /// <summary>
        /// 当 CheckedListBox 失去输入焦点的时候，需要作的处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lst_LostFocus(object sender, EventArgs e)
        {
            // 失去输入焦点
            // 那么把自己隐藏起来.
            lst.Hide();
            // 设置本控件的内部标志.
            this.lstShowFlag = CheckedListBoxShowMode.LostFocus;
            // 设置 最后的失去焦点的时间.
            lastLostFocusDateTime = DateTime.Now;
        }


        #endregion

    }
}
