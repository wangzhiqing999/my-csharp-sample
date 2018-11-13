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


            if (!Page.IsPostBack)
            {

                ReportDocument rd = new ReportDocument();

                // 加载报表文件.
                string reportAddress = "/ReportFiles/test.rpt";
                string reportLoaclAddress = Server.MapPath(reportAddress);

                // 加载报表.
                rd.Load(reportLoaclAddress);

                string userName = ConfigurationManager.AppSettings["Report.UserName"];
                string password = ConfigurationManager.AppSettings["Report.Password"];

                // 用户名、密码
                rd.SetDatabaseLogon(userName, password);

                // rd.Refresh();

                // 数据源绑定.
                crReportViewer.ReportSource = rd;


                crReportViewer.RefreshReport();
            }

        }
    }
}