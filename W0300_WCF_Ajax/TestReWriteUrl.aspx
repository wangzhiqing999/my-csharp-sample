<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestReWriteUrl.aspx.cs" Inherits="W0300_WCF_Ajax.TestReWriteUrl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h3>  URL 重写测试  </h3>

<pre><code>

相关处理代码， 写在 Global.asax.cs 的 Application_BeginRequest 方法里面

测试之前， 需要修改 C:\Windows\System32\drivers\etc\hosts 文件。

增加下面的测试信息.


127.0.0.1			a.test.cn
127.0.0.1			b.test.cn
127.0.0.1			c.test.cn
127.0.0.1			www.test.cn



</code></pre>


    



    <table>
      <tr>
        <td> 本页面实际接收到的 Url地址 </td>
        <td> <%= Request.Url.ToString() %> </td>
      </tr>


      <tr>
        <td colspan="2"> <a href="http://a.test.cn:56762">测试 a.test.cn </a> </td>
      </tr>

      <tr>
        <td colspan="2"> <a href="http://b.test.cn:56762">测试 b.test.cn</a> </td>
      </tr>

      <tr>
        <td colspan="2"> <a href="http://c.test.cn:56762">测试 c.test.cn </a> </td>
      </tr>

      <tr>
        <td colspan="2"> <a href="http://www.test.cn:56762">测试 www.test.cn </a> </td>
      </tr>

    </table>




    </div>
    </form>
</body>
</html>
