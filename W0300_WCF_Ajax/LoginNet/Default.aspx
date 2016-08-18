<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="W0300_WCF_Ajax.LoginNet.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>  首页  </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    本画面用于模拟, 如果用户设置了自动登录, 那么打开首页, 就自动用 Cookie 进行登录。






<asp:Panel ID="pnlWithLogin" runat="server">

<h3> 您已登录 </h3>

  <asp:LinkButton ID="lbtnLogout" runat="server" onclick="lbtnLogout_Click">注销</asp:LinkButton>

</asp:Panel>





<asp:Panel ID="pnlWithOutLogin" runat="server">

<h3> 尚未登录 </h3>

 <a href="Login.aspx">  登录  </a> 

</asp:Panel>


    </div>
    </form>
</body>
</html>
