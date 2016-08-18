<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="W0300_WCF_Ajax.LoginNet.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 登录 </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

<table>
  <tr>
    <td> 用户名 </td>
    <td> <asp:TextBox ID="txtUserName" runat="server">test</asp:TextBox>  </td>
  </tr>


  <tr>
    <td> 密码 </td>
    <td> <asp:TextBox ID="txtPassword" runat="server">test</asp:TextBox>  </td>
  </tr>


  <tr>
    <td colspan="2"> 
        <asp:CheckBox ID="chkAutoLogin" runat="server" Text="30天内自动登录" />  
    </td>
  </tr>


  <tr>
    <td colspan="2">   
        <asp:Button ID="btnLogin" runat="server" Text="登录" onclick="btnLogin_Click" />
    </td>
  </tr>
</table>



    </div>
    </form>
</body>
</html>
