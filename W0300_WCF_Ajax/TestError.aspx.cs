using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W0300_WCF_Ajax
{
    public partial class TestError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// 测试后台抛异常.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTestException_Click(object sender, EventArgs e)
        {
            throw new Exception("测试异常！");
        }




    }
}