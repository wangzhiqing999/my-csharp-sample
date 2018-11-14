using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CR_HelloWorld_Web.ReportViewer
{
    public partial class Empty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string reportAddress = "/ReportFiles/testEmpty.rpt";
            string reportLoaclAddress = Server.MapPath(reportAddress);
            this.CrystalReportSource1.Report.FileName = reportLoaclAddress;
        }
    }
}