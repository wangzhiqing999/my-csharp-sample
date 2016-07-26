using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace A5050_UCbo.UI
{
    public partial class MyComboBoxEx : ComboBox
    {
        /// <summary>
        /// 用于模糊匹配的 列表控件.
        /// </summary>
        private System.Windows.Forms.ListBox lbMain;

        /// <summary>
        /// 取得顶级的 父节点.
        /// </summary>
        private Control topParent;

        /// <summary>
        /// 列表控件显示的高度.
        /// </summary>
        private const int MAIN_HEIGHT = 100;

        /// <summary>
        /// 本控件相对于顶级节点的 Left 坐标.
        /// </summary>
        private int topLeft = 0;

        /// <summary>
        /// 本控件相对于顶级节点的 Top 坐标.
        /// </summary>
        private int topTop = 0;


        public MyComboBoxEx()
        {
            InitializeComponent();
            lbMain = new ListBox();

            // 鼠标点击事件.
            lbMain.Click += new EventHandler(lbMain_Click);
            // 键盘按下事件.
            lbMain.KeyDown += new KeyEventHandler(lbMain_KeyDown);

            lbMain.Visible = false;
        }

        public MyComboBoxEx(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            lbMain = new ListBox();
            lbMain.Click += new EventHandler(lbMain_Click);
            lbMain.KeyDown += new KeyEventHandler(lbMain_KeyDown);
            lbMain.Visible = false;
        }


        /// <summary>
        /// 读取到顶层的 父控件.
        /// </summary>
        private void ReadTopParent()
        {


            topParent = this.Parent;
            topLeft = this.Left;
            topTop = this.Top + this.Height + 1;

            if (topParent == null)
            {
                return;
            }

            while (topParent.Parent != null)
            {
				
                if (topParent.Parent is MdiClient)
                {                    
                    // 当 父节点是 MDI 容器的时候， 结束循环.
                    break;                    
                }				
				
                // 相对递增 Left.
                topLeft += topParent.Left + 1;

                // 相对递增 Top.
                topTop += topParent.Top;

                topParent = topParent.Parent;
            }

            // 判断，如果大小超出顶级节点的范围
            // 作切换的处理.
            if (topTop + MAIN_HEIGHT > topParent.Height)
            {
                // 向上展开.
                topTop = topTop - this.Height - 1 - MAIN_HEIGHT;
            }

        }


        /// <summary>
        /// 得到匹配给定字符串的列表
        /// </summary>
        private List<string> GetFillList(string strValue)
        {
            // 预期返回的数组.
            List<string> alReturn = new List<string>();

            // 首先取得数据列表的总数.
            int iCount = this.Items.Count;

            // 取得关键字的长度.
            int iLen = strValue.Length;

            // 用于暂存 列表的文本信息.
            string strSelItem = "";

            // 依次检索 下拉列表中的每一个Item.
            for (int i = 0; i < iCount; i++)
            {
                // 判断下拉列表中元素的数据类型.
                if (this.Items[i] is DataRowView)
                {
                    // 每一行数据是一个 DataRow 
                    // 通过 DataRow 的 DisplayMember 字段来获取.
                    strSelItem = (this.Items[i] as DataRowView)[this.DisplayMember].ToString();
                }
                else
                {
                    if (!String.IsNullOrEmpty(this.DisplayMember)
                        && this.DisplayMember != this.ValueMember)
                    {
                        // 不是  DataRow 的， 但是是通过 数据绑定 DisplayMember 的
                        // 通过反射 获取 具体数据.
                        Type t = this.Items[i].GetType();
                        PropertyInfo propInfo = t.GetProperty(this.DisplayMember);
                        strSelItem = propInfo.GetValue(this.Items[i], null).ToString();
                    }
                    else
                    {
                        // 不是 DataRow 的, 也没有设置 DisplayMember 的
                        // 简单获取 ToString() 方法.
                        strSelItem = this.Items[i].ToString();
                    }
                }

                // 执行到这里的时候， 数据列表中当前行的数据，已经存储到 strSelItem 中了.
                // 下面对数据进行分析处理.
                if (strSelItem.Length < iLen)
                {
                    // 如果 外部输入的数据长度 大于 数据列表的长度
                    // 那么忽略这一行，不进行匹配了
                    // 例如 外部要求 模糊匹配  IBM 3个字符的
                    // 但是当前列 只有 IE 2个字符的
                    // 没有进一步匹配的必要.
                    continue;
                }

                // 当 外部输入的数据长度 小于 数据列表的长度
                // 开始尝试模糊匹配
                // 例如 外部要求 模糊匹配  IE 2个字符的
                // 当前列 只有 IE 2个字符的, 也有 IBM 3 个字符的
                // 这个时候，开始做匹配.
                // 匹配首先尝试 直接的匹配，忽略大小写。 也就是 输入的数据，是不是 字段数据中的一部分。
                // 然后尝试把 “汉字”的字段数据转换为拼音， 看看 输入的数据，是不是 拼音中的一部分。
                if (strSelItem.IndexOf(strValue, 0, StringComparison.OrdinalIgnoreCase) >= 0
                    || GetChineseSpell(strSelItem).IndexOf(strValue, 0, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // 模糊匹配成功的话，加入结果列表.
                    alReturn.Add(strSelItem);
                }
            }
            // 返回匹配成功的结果列表.
            return alReturn;
        }


        /// <summary>
        /// 当点击了 下拉列表中的项目的事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMain_Click(object sender, System.EventArgs e)
        {

            if (lbMain.SelectedItems.Count == 0)
            {
                // 如果没有选择到数据.
                // 那么直接忽略返回.
                // 此操作为了避免 后面的 lbMain.SelectedItem 为 NULL 而导致出错.
                return;
            }

            // 取得 选择到的 字符串.
            string strSel = lbMain.SelectedItem.ToString();

            this.Text = strSel;

            // 根据 字符串， 取得 当前这个字符串， 在 ComboBox列表中，是第几个.
            int iSel = this.FindStringExact(Text);

            // 如果找到了是ComboBox列表中的第几个.
            // 通过设置 ComboBox 列表的 SelectedIndex
            // 完成 ComboBox 控件的正常显示.
            if (iSel != -1)
                this.SelectedIndex = iSel;

            // 使下拉列表不可见.
            lbMain.Visible = false;
        }


        /// <summary>
        /// ComboBox 的 OnTextChanged 事件.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            if (!DesignMode)
            {
                ReadTopParent();

                // 首先是 非设计 模式下才做处理.
                if (Text == "")
                {
                    // 如果什么信息都没有输入
                    // 那么不开启 模糊处理的操作.
                    // 将下拉列表设置为不可见
                    // 然后结束 并 返回.
                    lbMain.Visible = false;
                    return;
                }

                if (topParent == null)
                {
                    lbMain.Visible = false;
                    return;
                }

                if (!topParent.Controls.Contains(lbMain))
                {
                    // 如果 当前 ComboBox 控件的 父控件下，不包含 lbMain 这个控件
                    // 那么 将 lbMain 加入到当前 ComboBox 控件的 父控件下
                    // 并设置相应的坐标，在当前 ComboBox 控件的下面
                    lbMain.Width = this.Width;

                    lbMain.Height = MAIN_HEIGHT;

                    //lbMain.Parent = this.Parent;
                    lbMain.Parent = topParent;

                    //lbMain.Top = this.Top + this.Height + 1;
                    lbMain.Top = topTop;

                    //lbMain.Left = this.Left;
                    lbMain.Left = topLeft;

                    //this.Parent.Controls.Add(lbMain);
                    topParent.Controls.Add(lbMain);

                    lbMain.BringToFront();
                }

                // 得到匹配给定字符串的列表
                List<string> alFill = GetFillList(Text);
                // 清空下拉列表的数据.
                lbMain.Items.Clear();
                // 将匹配后的结果，添加到 下拉列表 中.
                lbMain.Items.AddRange(alFill.ToArray());

                if (lbMain.Items.Count > 0)
                {
                    // 如果 下拉列表中有数据
                    // 首先默认选中第一个.
                    lbMain.SelectedIndex = 0;
                }

                if (!lbMain.Visible && this.Focused)
                {
                    // 如果 当前光标在 ComboBox 控件上面
                    // 但是 下拉列表控件 又不可见的话，使该控件可见.
                    lbMain.Visible = true;
                }
            }
            base.OnTextChanged(e);
        }



        protected override void OnLocationChanged(EventArgs e)
        {
            if (!DesignMode)
            {
                if (lbMain != null)
                {
                    SetlbMainLocation();
                }
            }
        }

        private void SetlbMainLocation()
        {
            lbMain.Visible = false;
            lbMain.Width = this.Width;
            lbMain.Height = 100;
            lbMain.Top = this.Top + this.Height + 1;
            lbMain.Left = this.Left;
            lbMain.BringToFront();
        }

        /// <summary>
        /// 失去输入焦点的事件.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            if (!DesignMode)
            {
                // 非 设计模式下
                // 如果 下拉列表 与  ComboBox 都没有获得输入焦点
                // 那么 下拉列表需要 设置为 不可见.
                if (!lbMain.Focused && !this.Focused)
                    lbMain.Visible = false;
            }
            base.OnLeave(e);
        }

        protected override void OnDropDown(EventArgs e)
        {
            // 当选择了 ComboBox 的下拉的时候
            // 这个时候，就不使用 模糊匹配了
            // 因此，用于模糊匹配的下拉列表
            // 需要设置为不可见.
            lbMain.Visible = false;
            base.OnDropDown(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!DesignMode)
            {
                // 非设计模式下
                // 如果 ComboBox 不可见了
                // 那么下拉列表，也应该不可见.
                if (!this.Visible)
                {
                    if (lbMain != null)
                    {
                        lbMain.Visible = false;
                    }
                }
            }
            base.OnVisibleChanged(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (lbMain.Visible)
            {
                // 当 下拉列表可见的时候
                // 所有对于 ComboBox 的按键处理
                // 要移交给 下拉列表
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left ||
                     e.KeyCode == Keys.Right || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.PageUp)
                {
                    // 上下左右翻页，相当于 记录迁移.
                    lbMain_KeyDown(lbMain, e);
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    // 回车，相当于选择
                    lbMain_Click(lbMain, e);
                    e.Handled = true;
                }
            }
            base.OnKeyDown(e);
        }



        /// <summary>
        /// 下拉列表中 键盘处理的事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.PageUp)
            {
                // 对于 上， 左， 向上翻页， 认为是 向上一条记录的处理.
                if (lbMain.SelectedIndex > 0)
                    lbMain.SelectedIndex = lbMain.SelectedIndex - 1;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.PageDown)
            {
                // 对于 下， 右， 向下翻页， 认为是 向下一条记录的处理.
                if (lbMain.SelectedIndex < lbMain.Items.Count - 1)
                    lbMain.SelectedIndex = lbMain.SelectedIndex + 1;
            }
        }



        /// <summary>
        /// 对话框选项发生变化时的事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UComboBoxEx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // 非设计模式下，将 下拉列表 设置为 不可见.
            if (!DesignMode)
            {
                lbMain.Visible = false;
            }
        }




        #region 中文汉字 与 拼音转换的代码.


        /// <summary>
        /// 取得 中文汉字字符串的 汉语拼音首字母信息.
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        static public string GetChineseSpell(string strText)
        {
            // 取得 源字符串长度.
            int len = strText.Length;
            // 准备用于返回的 缓存信息.
            StringBuilder buff = new StringBuilder();
            // 依次处理每一个字符.
            for (int i = 0; i < len; i++)
            {
                buff.Append(getSpell(strText.Substring(i, 1)));
            }
            // 返回.
            return buff.ToString();
        }

        /// <summary>
        /// 取得 中文汉字字符的 汉语拼音首字母信息.
        /// </summary>
        /// <param name="cnChar"></param>
        /// <returns></returns>
        static public string getSpell(string cnChar)
        {
            // 将传入的 char 信息， 拆分为 byte
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            // 首先判断一下 传入的数据.
            if (arrCN.Length > 1)
            {
                // 传入的大于 1个字节。 应该是双字节字符.
                // 需要拆分
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                // 遇到无法识别的信息
                return "*";
            }
            else
            {
                // 单字节的 英文/数字 信息，直接简单返回.
                return cnChar;
            }
        }


        #endregion



    }
}
