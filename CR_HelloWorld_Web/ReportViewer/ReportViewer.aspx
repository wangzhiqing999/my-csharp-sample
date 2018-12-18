<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="CR_HelloWorld_Web.ReportViewer.ReportViewer" %>



<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="pragma" content="no-cache" />
<meta http-equiv="cache-control" content="no-cache" />
<meta http-equiv="expires" content="0" />

    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
