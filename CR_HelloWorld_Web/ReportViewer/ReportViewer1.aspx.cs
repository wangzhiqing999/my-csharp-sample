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
            if (!Page.IsPostBack)
            {
                string reportAddress = "/ReportFiles/test.rpt";
                string reportLoaclAddress = Server.MapPath(reportAddress);
                this.CrystalReportSource1.Report.FileName = reportLoaclAddress;


                string userName = ConfigurationManager.AppSettings["Report.UserName"];
                string password = ConfigurationManager.AppSettings["Report.Password"];
                this.CrystalReportSource1.ReportDocument.SetDatabaseLogon(userName, password);

            }
        }


    }
}