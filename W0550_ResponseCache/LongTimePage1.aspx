<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongTimePage1.aspx.cs" Inherits="W0550_ResponseCache.LongTimePage1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 测试需要长时间加载的页面 </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    测试需要长时间加载的页面
    
    <p>
    本页面没有设置缓存信息，因此，外部每次请求， 都将花费大量的时间。
    </p>

    </div>
    </form>
</body>
</html>
