<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="IIS0010_URLrewriting.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    <h3> 测试 Url Rewrite 的页面 </h3>

    <p>
        <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
    </p>

    <table>
        <tr>
                <th>Server Variable</th>
                <th>Value</th>
        </tr>
        <tr>
                <td>Original URL: </td>
                <td><%= Request.ServerVariables["HTTP_X_ORIGINAL_URL"] %></td>
        </tr>
        <tr>
                <td>Final URL: </td>
                <td><%= Request.ServerVariables["SCRIPT_NAME"] + "?" + Request.ServerVariables["QUERY_STRING"] %></td>
        </tr>
    </table>


    </div>
    </form>
</body>
</html>
