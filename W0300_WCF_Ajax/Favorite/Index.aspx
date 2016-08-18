<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="W0300_WCF_Ajax.Favorite.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 测试添加到收藏夹 </title>


    <script  type="text/javascript">

        var vBrowserName = '<%=browserName %>';

        //收藏本站
        function AddFavorite(title, url) {
            try {
                // 优先尝试 IE 的处理机制.
                window.external.addFavorite(url, title);
            }
            catch (e) {
                // IE 方式失败，尝试 第2种方式.
                try {
                    window.sidebar.addPanel(title, url, "");
                }
                catch (e) {
                    alert("抱歉，您所使用的浏览器无法完成此操作。\n\n加入收藏失败，请使用Ctrl+D进行添加");
                }
            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    

<h3> 测试添加到收藏夹 </h3>

<p>
客户端浏览器：<%=browserName %>
</p>

<p>
User-Agent: <%=userAgent%>
</p>



<% 
    if (browserName == "Firefox")
    {
%>
<a rel="sidebar"  href="/Favorite/index.aspx" >收藏</a>
<%
    }
    else
    {
%>
<a href="javascript:void(0)" onclick="AddFavorite('测试添加到收藏夹', location.href)">收藏</a>
<%
    }
%>





    </div>
    </form>
</body>
</html>
