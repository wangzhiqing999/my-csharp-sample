using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CR_HelloWorld_Web.ReportViewer
{
    public partial class ReportViewer1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string reportAddress = "/ReportFiles/test.rpt";
            string reportLoaclAddress = Server.MapPath(reportAddress);
            this.CrystalReportSource1.Report.FileName = reportLoaclAddress;


            // 设置数据库登陆名/密码 的代码， 不能放在 if (!Page.IsPostBack) 里面
            // 否则，遇到 有参数的报表，在提交报表参数之后，将弹出登录窗口。
            string userName = ConfigurationManager.AppSettings["Report.UserName"];
            string password = ConfigurationManager.AppSettings["Report.Password"];
            this.CrystalReportSource1.ReportDocument.SetDatabaseLogon(userName, password);



            if (!Page.IsPostBack)
            {
                this.CrystalReportViewer1.RefreshReport();
            }

        }


    }
}