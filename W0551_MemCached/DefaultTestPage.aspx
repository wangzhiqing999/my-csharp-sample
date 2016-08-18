<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultTestPage.aspx.cs" Inherits="W0551_MemCached.DefaultTestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <table>
            <tr>
                <td>
                    用户名:
                </td>
                <td>
                    <asp:TextBox ID="txtQueryUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click" />
                </td>
            </tr>
        </table>

        <hr />

        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

        <asp:Panel ID="pnlResult" runat="server" Visible="False">

        <table>
            <tr>
                <td>
                    用户名:
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    用户类型:
                </td>
                <td>
                    <asp:TextBox ID="txtUserType" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    好友列表:
                </td>
                <td>
                    <asp:TextBox ID="txtFirendList" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>




        </table>

        </asp:Panel>
        

    </div>
    </form>
</body>
</html>
