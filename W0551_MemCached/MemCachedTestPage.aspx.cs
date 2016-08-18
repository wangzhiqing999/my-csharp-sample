using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using W0551_MemCached.Model;
using W0551_MemCached.Service;
using W0551_MemCached.ServiceImpl;



namespace W0551_MemCached
{
    public partial class MemCachedTestPage : System.Web.UI.Page
    {

        /// <summary>
        /// 缓存服务.
        /// </summary>
        private ITestDataService memCachedService = new MemCachedTestDataService();



        /// <summary>
        /// 缓存服务.
        /// </summary>
        protected ITestDataService TestDataService
        {
            get
            {
                return memCachedService;
            }
            set
            {
                memCachedService = value;
            }
        }




        /// <summary>
        /// 查询.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            TestData data = TestDataService.GetTestDataByUserName(txtQueryUserName.Text);
            if (data != null)
            {
                this.lblMessage.Text = "结果：";
                this.pnlResult.Visible = true;

                this.txtUserName.Text = data.UserName;
                this.txtUserType.Text = data.UserType.ToString();
                this.txtFirendList.Text = string.Join("\r\n", data.FirendList);
            }
            else
            {
                this.lblMessage.Text = "数据不存在！";
                this.pnlResult.Visible = false;
            }
        }



    }
}