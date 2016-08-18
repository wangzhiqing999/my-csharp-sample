using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;


namespace W0300_WCF_Ajax.jq
{
    public partial class BasicInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// 取得 DropDownList 控件的 SelectedValue
        /// 
        /// 测试目标
        ///     如果 DropDownList 里面的  选择项目， 是 jQuery 在画面上动态加入的。
        ///     那么这里尝试判断， 是否可以正确的读取到数据.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTestDropDownListSelectedValue_Click(object sender, EventArgs e)
        {
            this.lblDropDownListSelectedValue.Text = this.cboABCD.SelectedValue;
        }




        /// <summary>
        /// 取得 CheckBox 控件的 Checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReadCheckBox_Click(object sender, EventArgs e)
        {
            // 注： 因为对于 CheckBox,  每一个 CheckBox 只能有一个唯一的 id
            // 生成 html 的时候， 就生成了不同的 name.
            // 因此只能通过判断，依次获取数据. 
            StringBuilder buff = new StringBuilder();
            if (this.chkA.Checked)
            {
                buff.Append(this.chkA.Text);
                buff.Append(" ");
            }
            if (this.chkB.Checked)
            {
                buff.Append(this.chkB.Text);
                buff.Append(" ");
            }
            if (this.chkC.Checked)
            {
                buff.Append(this.chkC.Text);
                buff.Append(" ");
            }
            if (this.chkD.Checked)
            {
                buff.Append(this.chkD.Text);
                buff.Append(" ");
            }
            this.lblReadCheckBoxResult.Text = buff.ToString();
        }



        /// <summary>
        /// 取得 CheckBoxList 控件的 Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReadCheckBoxList_Click(object sender, EventArgs e)
        {
            // 注： 因为对于 CheckBoxList,  CheckBoxList 只有一个唯一的 id
            // 生成 html 的时候， 多个 input checkbox  生成了不同的 id / name.
            // id 一般是= "控件id_0","控件id_1","控件id_2"......
            // name 一般是= "控件id$0","控件id$1","控件id$2"......

            // 因此只能通过 foreach 判断，都选择了哪些数据. 

            StringBuilder buff = new StringBuilder();
            foreach (ListItem item in this.cblTest.Items)
            {
                if (item.Selected)
                {
                    buff.Append(item.Value);
                    buff.Append(" ");
                }
            }

            this.lblReadCheckBoxListResult.Text = buff.ToString();

        }



    }
}