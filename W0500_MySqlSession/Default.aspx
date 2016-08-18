<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="W0500_MySqlSession.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 测试  Session 数据存储到  MySQL 数据库中  </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


<table>
  <tr>
    <td> 写入 Session </td>
    <td> 
        <asp:TextBox ID="txtSessionValue" runat="server"></asp:TextBox>
    </td>
    <td>
        <asp:Button ID="btnWriteSession" runat="server" Text="写入" 
            onclick="btnWriteSession_Click" />
    </td>
  </tr>

  <tr>
    <td> 读取 Session </td>
    <td>
        <asp:Button ID="btnReadSession" runat="server" Text="读取" 
            onclick="btnReadSession_Click" />
    </td>
    <td>
        <asp:Label ID="lblSessionValue" runat="server" Text="-"></asp:Label>
    </td>
  </tr>
</table>

    


<hr />

步骤：

<ul>
  <li> 安装   MySQL for Visual Studio </li>
  <li> NuGet 引用 MySql.Web， 会自动包含 MySql.Data </li>
  <li> 选择网站项目，点击 MySQL Website Configuration Tool  </li>
  <li> 在 session 的地方， 输入相关信息 </li>

  <li> 也可以只 NuGet 引用 MySql.Web ， 然后复制本项目的 Web.Config 文件中的相关数据过去 </li>
</ul>



    </div>
    </form>
</body>
</html>
