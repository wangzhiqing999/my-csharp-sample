<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="W1300_SignalR.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> 登录 </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <ul>
            <li> 
                User Name:
                <asp:TextBox ID="txtUserName" runat="server" Text="Test"></asp:TextBox>
            </li>
            <li>
                Password:
                <asp:TextBox ID="txtPassword" runat="server" Text="123456"></asp:TextBox>
            </li>
            <li>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </li>
        </ul>
        
        

        
    </div>
    </form>
</body>
</html>
