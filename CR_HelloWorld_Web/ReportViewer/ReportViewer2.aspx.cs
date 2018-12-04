using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrystalDecisions.CrystalReports.Engine;


namespace MyReport.Mvc.ReportViewer
{
    public partial class ReportViewer2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();

            // 加载报表文件.
            string reportAddress = "/ReportFiles/test.rpt";
            string reportLoaclAddress = Server.MapPath(reportAddress);

            // 加载报表.
            rd.Load(reportLoaclAddress);


            // 设置数据库登陆名/密码 的代码， 不能放在 if (!Page.IsPostBack) 里面
            // 否则，遇到 有参数的报表，在提交报表参数之后，将弹出登录窗口。
            string userName = ConfigurationManager.AppSettings["Report.UserName"];
            string password = ConfigurationManager.AppSettings["Report.Password"];
            // 用户名、密码
            rd.SetDatabaseLogon(userName, password);


            // 数据源绑定.
            crReportViewer.ReportSource = rd;



            if (!Page.IsPostBack)
            {
                crReportViewer.RefreshReport();
            }

        }
    }
}