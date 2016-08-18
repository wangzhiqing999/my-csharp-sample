<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestError.aspx.cs" Inherits="W0300_WCF_Ajax.TestError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 异常画面测试 </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

<h4> 异常画面迁移 </h4>



<pre>
<code>

配置异常画面的迁移， 主要需要在 Web.config 里面设置 
customErrors mode="On" defaultRedirect="Error/ErrorPage.aspx"

对于特定代码的异常（例如 404 异常）， 需要设置
error statusCode="404" redirect="Error/Error404.aspx" 



需要注意的是:
仅仅为了测试这个 功能的时候， 把 mode="On" 
发布到正式使用的服务器上面的时候， 建议把 mode="RemoteOnly"
否则 服务器上面， 不能查看具体的错误信息了。




上面仅仅是 出错时， 页面迁移的处理。
代码方面，需要在 Application_Error 里面去写 相关的日志处理的代码.


</code>
</pre>





<table>
  
  
  <tr>
    <td> 
        <a href="index123.htm"> 一个不存在的页面，用于测试 404 错误！ </a> 
    </td>
  </tr>


  <tr>
    <td> 
        <a href="Global.asax"> 一个不允许访问的文件，用于测试 403 错误！ </a> 
    </td>
  </tr>

  
  <tr>
    <td>
        <asp:Button ID="btnTestException" runat="server" Text="测试后台抛异常 用于测试 500 错误" 
            onclick="btnTestException_Click" />
    </td>
  </tr>


</table>


    </div>
    </form>
</body>
</html>
