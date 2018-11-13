<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer2.aspx.cs" Inherits="MyReport.Mvc.ReportViewer.ReportViewer2" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>   </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

        <CR:CrystalReportViewer ID="crReportViewer" runat="server" 
            DisplayToolbar="true"
            HasSearchButton="false"
            HasExportButton="false"
            HasCrystalLogo="false"
            HasDrillUpButton="false"

            DisplayStatusbar="false"

            DisplayPage="true"


            EnableDrillDown="false"
            HasToggleGroupTreeButton="false"
            HasToggleParameterPanelButton="false"
            ToolPanelWidth="0"

            Width="1280"

            AutoDataBind="true" />


    </div>
    </form>
</body>
</html>
